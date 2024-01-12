using ErrorOr;

namespace BreakFastHub.ServiceErrors;

public static class Errors
{
    public static class Breakfast
    {
        public static Error InvalidName =>
            Error.Validation(
                code: "Breakfast.InvalidName",
                description: $"Breakfast name must be at least {Models.BreakFast.MinNameLength}"
                    + $" characters long and at most {Models.BreakFast.MaxNameLength} characters long."
            );

        public static Error InvalidDescription =>
            Error.Validation(
                code: "Breakfast.InvalidDescription",
                description: $"Breakfast description must be at least {Models.BreakFast.MinDescriptionLength}"
                    + $" characters long and at most {Models.BreakFast.MaxDescriptionLength} characters long."
            );

        public static Error NotFound =>
            Error.NotFound(code: "Breakfast.NotFound", description: "Breakfast not found");
    }
}
