using FluentValidation;
using Shiptech.Application.Commands;
using Shiptech.Application.Queries;
using Shiptech.Application.Services;

namespace Shiptech.Application.Validators.Ship;

public class GetShipValidator : AbstractValidator<GetShip>
{
    public GetShipValidator(IShipReadService service)
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