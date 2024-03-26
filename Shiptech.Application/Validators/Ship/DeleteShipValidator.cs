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
            .MustAsync(async (x, _) => await service.ExistsById(x))
            .WithErrorCode("SHIP_404_ID")
            .WithMessage(x =>$"{x.Id} nie istnieje w bazie!");
    }
}