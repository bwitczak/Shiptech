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
            .WithErrorCode("SHIP_400_ID")
            .WithMessage("Nazwa statku nie może być pusta!")
            .Must((x, id) => x.Id == id)
            .WithErrorCode("SHIP_400_ID")
            .WithMessage(x =>$"{x.Id} nie istnieje w bazie!");

        RuleFor(x => x.Orderer)
            .NotNull()
            .NotEmpty()
            .WithMessage("Nazwa zamawiającego nie może być pusta!")
            .WithErrorCode("SHIP_400_ORDERER")
            .MustAsync(async (x, _) => !await service.ExistsByOrderer(x))
            .WithMessage(x => $"{x.Orderer} już istnieje w bazie!")
            .WithErrorCode("SHIP_409_ORDERER");
    }
}