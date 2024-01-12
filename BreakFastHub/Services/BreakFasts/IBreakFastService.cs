using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BreakFastHub.Contracts.BreakFast;
using BreakFastHub.Models;
using ErrorOr;

namespace BreakFastHub.Services.BreakFasts
{
    public interface IBreakFastService
    {
        ErrorOr<Created> CreateBreakFast(BreakFast breakfast);
        ErrorOr<Deleted> DeleteBreakFast(Guid id);
        ErrorOr<BreakFast> GetBreakFast(Guid id);
        ErrorOr<Updated> UpsertBreakFast(BreakFast breakfast);
        int DicHas(Guid id);
    }
}
