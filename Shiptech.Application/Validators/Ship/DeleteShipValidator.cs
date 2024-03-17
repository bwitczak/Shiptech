using FluentValidation;
using Shiptech.Application.Commands;
using Shiptech.Application.Services;

namespace Shiptech.Application.Validators.Ship;

public class DeleteShipValidator : AbstractValidator<DeleteShip>
{
    public DeleteShipValidator(IShipReadService service)
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("SHIP_400_ID")
            .WithMessage("Nazwa statku nie może być pusta!")
            .Must((x, id) => x.Id == id)
            .WithErrorCode("SHIP_400_ID")
            .WithMessage(x =>$"{x.Id} nie istnieje w bazie!");
    }
}