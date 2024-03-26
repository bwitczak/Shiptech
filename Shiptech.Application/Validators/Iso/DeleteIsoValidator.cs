using FluentValidation;
using Shiptech.Application.Commands;
using Shiptech.Application.Services;

namespace Shiptech.Application.Validators.Iso;

public class DeleteIsoValidator : AbstractValidator<DeleteIso>
{
    public DeleteIsoValidator(IIsoReadService service)
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("ISO_400_ID")
            .WithMessage("Nazwa izometryka nie może być pusta!")
            .MustAsync(async (x, _) => await service.ExistsById(x))
            .WithMessage(x => $"{x.Id} nie istnieje w bazie!")
            .WithErrorCode("ISO_404_ID");
    }
}