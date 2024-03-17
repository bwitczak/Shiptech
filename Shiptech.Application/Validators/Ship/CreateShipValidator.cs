using FluentValidation;
using FluentValidation.Results;
using Shiptech.Application.Commands;
using Shiptech.Application.Exceptions;
using Shiptech.Application.Services;

namespace Shiptech.Application.Validators.Ship;

public class CreateShipValidator : AbstractValidator<CreateShip>
{
    public CreateShipValidator(IShipReadService service)
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("SHIP_400_ID")
            .WithMessage("Nazwa statku nie może być pusta!");

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