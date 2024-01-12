using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BreakFastHub.Models;
using BreakFastHub.ServiceErrors;
using ErrorOr;

namespace BreakFastHub.Services.BreakFasts;

public class BreakFastService : IBreakFastService
{
    private readonly Dictionary<Guid, BreakFast> _breakfasts = new();

    public ErrorOr<Created> CreateBreakFast(BreakFast breakfast)
    {
        _breakfasts.Add(breakfast.Id, breakfast);
        return Result.Created;
    }

    public ErrorOr<BreakFast> GetBreakFast(Guid id)
    {
        if (_breakfasts.TryGetValue(id, out var breakfast))
        {
            return breakfast;
        }
        return Errors.Breakfast.NotFound;
    }

    public ErrorOr<Deleted> DeleteBreakFast(Guid id)
    {
        _breakfasts.Remove(id);
        return Result.Deleted;
    }

    public ErrorOr<Updated> UpsertBreakFast(BreakFast breakfast)
    {
        _breakfasts[breakfast.Id] = breakfast;

        return Result.Updated;
    }

    public int DicHas(Guid id)
    {
        return _breakfasts.ContainsKey(id) ? 1 : 0;
    }
}
