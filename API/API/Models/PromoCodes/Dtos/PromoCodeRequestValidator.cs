using FluentValidation;

namespace API.Models.PromoCodes.Dtos
{
    public class PromoCodeRequestValidator : AbstractValidator<PromoCodeRequestDto>
    {
        public PromoCodeRequestValidator()
        {
            RuleFor(request => request.Description)
                .NotNull().WithMessage("Description is required.")
                .NotEmpty().WithMessage("Description cannot be empty.");

            RuleFor(request => request.Code)
                .NotNull();

            RuleFor(request => request.StartDate)
                .NotEmpty().WithMessage("Start Date is required.")
                .GreaterThanOrEqualTo(DateTime.UtcNow.AddSeconds(-25)).WithMessage("Start Date must be greater than or equal to current date.");

            RuleFor(request => request.EndDate)
                .NotEmpty().WithMessage("End Date is Required.")
                .GreaterThan(request => request.StartDate).WithMessage("End Date must be after Start Date.");

            RuleFor(request => request.Amount)
                .GreaterThan(0).WithMessage("Amount must be greater than 0.");

            RuleFor(request => request.Amount)
            .LessThanOrEqualTo(100).WithMessage("Amount must be less than or equal to 100 when Type is '%'.")
            .When(request => request.Type == "%");

            RuleFor(request => request.Type)
                .NotNull().WithMessage("Type is required.")
                .NotEmpty().WithMessage("Type cannot be empty.")
                .Must(type => type == "%" || type == "$").WithMessage("Type must be either '%' or '$'.");
        }
    }
}
