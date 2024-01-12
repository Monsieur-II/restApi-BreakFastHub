using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BreakFastHub.Contracts.BreakFast;
using BreakFastHub.Models;
using BreakFastHub.ServiceErrors;
using BreakFastHub.Services.BreakFasts;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BreakFastHub.Controllers
{
    public class BreakFastController : ApiController
    {
        private readonly IBreakFastService _breakFastService;

        public BreakFastController(IBreakFastService breakFastService)
        {
            _breakFastService = breakFastService;
        }

        [HttpPost]
        public IActionResult CreateBreakFast(CreateBreakFastRequest request)
        {
            ErrorOr<BreakFast> requestToBreakfastResult = BreakFast.From(request);

            if (requestToBreakfastResult.IsError)
            {
                return Problem(requestToBreakfastResult.Errors);
            }

            var breakfast = requestToBreakfastResult.Value;
            ErrorOr<Created> createBreakfastResult = _breakFastService.CreateBreakFast(breakfast);

            if (createBreakfastResult.IsError)
            {
                return Problem(createBreakfastResult.Errors);
            }

            return createBreakfastResult.Match(
                created => CreatedAtGetBreakfast(breakfast),
                errors => Problem(errors)
            );
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetBreakFast(Guid id)
        {
            // Get the breakfast with corresponding id from database
            ErrorOr<BreakFast> getBreakfastResult = _breakFastService.GetBreakFast(id);

            // If getBreakfastResult is an error return a problem
            // if it is a breakfast object, map it to Api response and return
            return getBreakfastResult.Match(
                breakfast => Ok(MapBreakfastResponse(breakfast)),
                errors => Problem(errors)
            );
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpsertBreakFast(UpsertBreakFastRequest request, Guid id)
        {
            ErrorOr<BreakFast> requestToBreakfastResult = BreakFast.From(id, request);

            if (requestToBreakfastResult.IsError)
            {
                return Problem(requestToBreakfastResult.Errors);
            }

            var breakfast = requestToBreakfastResult.Value;
            int status = _breakFastService.DicHas(id);
            ErrorOr<Updated> upsertBreakfastResult = _breakFastService.UpsertBreakFast(breakfast);

            return upsertBreakfastResult.Match(
                upserted => (status == 0) ? CreatedAtGetBreakfast(breakfast) : NoContent(),
                errors => Problem(errors)
            );
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteBreakFast(Guid id)
        {
            ErrorOr<Deleted> deleteBreakfastResult = _breakFastService.DeleteBreakFast(id);

            return deleteBreakfastResult.Match(deleted => NoContent(), errors => Problem(errors));
        }

        private static BreakFastResponse MapBreakfastResponse(BreakFast breakfast)
        {
            return new BreakFastResponse(
                breakfast.Id,
                breakfast.Name,
                breakfast.Description,
                breakfast.StartDateTime,
                breakfast.EndDateTime,
                breakfast.LastModifiedDateTime,
                breakfast.Savory,
                breakfast.Sweet
            );
        }

        private CreatedAtActionResult CreatedAtGetBreakfast(BreakFast breakfast)
        {
            return CreatedAtAction(
                actionName: nameof(GetBreakFast),
                routeValues: new { id = breakfast.Id },
                value: MapBreakfastResponse(breakfast)
            );
        }
    }
}
