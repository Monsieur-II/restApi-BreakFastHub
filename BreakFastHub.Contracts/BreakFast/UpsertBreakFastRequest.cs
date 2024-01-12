namespace BreakFastHub.Contracts.BreakFast;

public record UpsertBreakFastRequest(
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    List<string> Savory,
    List<string> Sweet
);
