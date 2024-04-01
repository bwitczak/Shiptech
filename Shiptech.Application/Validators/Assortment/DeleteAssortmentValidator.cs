using FluentValidation;
using Shiptech.Application.Commands;
using Shiptech.Application.Services;

namespace Shiptech.Application.Validators.Assortment;

public class DeleteAssortmentValidator : AbstractValidator<DeleteAssortment>
{
    public DeleteAssortmentValidator(IAssortmentReadService service)
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("DELETE_ASSORTMENT_400_ID")
            .WithMessage("Identyfikator asortymentu nie może być pusty!")
            .MustAsync(async (x, _) => await service.ExistsById(x))
            .WithMessage(x => $"{x.Id} nie istnieje w bazie!")
            .WithErrorCode("ASSORTMENT_404_ID");
    }
}