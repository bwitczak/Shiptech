using FluentValidation;
using Shiptech.Application.Commands;
using Shiptech.Application.Queries;
using Shiptech.Application.Services;

namespace Shiptech.Application.Validators.Ship;

public class GetShipWithPagedDrawingsValidator : AbstractValidator<GetShipWithPagedDrawings>
{
    public GetShipWithPagedDrawingsValidator(IShipReadService service)
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("GET_SHIP_400_ID")
            .WithMessage("Identyfikator statku nie może być pusty!")
            .MustAsync(async (x, _) => await service.ExistsById(x))
            .WithErrorCode("GET_SHIP_404_ID")
            .WithMessage(x =>$"{x.Id} nie istnieje w bazie!");
    }
}