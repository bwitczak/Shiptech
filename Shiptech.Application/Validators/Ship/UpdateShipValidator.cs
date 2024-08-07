using FluentValidation;
using FluentValidation.Results;
using Shiptech.Application.Commands;
using Shiptech.Application.Services;

namespace Shiptech.Application.Validators.Ship;

public class UpdateShipValidator : AbstractValidator<UpdateShip>
{
    public UpdateShipValidator(IShipReadService service)
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("UPDATE_SHIP_400_ID")
            .WithMessage("Identyfikator statku nie może być pusty!")
            .MustAsync(async (x, _) => await service.ExistsById(x))
            .WithMessage(x => $"{x.Id} nie istnieje w bazie!")
            .WithErrorCode("UPDATE_SHIP_404_ID");

        RuleFor(x => x.Orderer)
            .NotNull()
            .NotEmpty()
            .WithMessage("Nazwa zamawiającego nie może być pusta!")
            .WithErrorCode("UPDATE_SHIP_400_ORDERER")
            .MustAsync(async (x, _) => !await service.ExistsByOrderer(x))
            .WithMessage(x => $"{x.Orderer} już istnieje w bazie!")
            .WithErrorCode("UPDATE_SHIP_409_ORDERER");
    }
}