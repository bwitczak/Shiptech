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
            .WithErrorCode("ASSORTMENT_400_ID")
            .WithMessage("Nazwa asortymentu nie może być pusta!")
            .MustAsync(async (x, _) => !await service.ExistsById(x))
            .WithMessage(x => $"{x.Id} już istnieje w bazie!")
            .WithErrorCode("ASSORTMENT_409_ID");
    }
}