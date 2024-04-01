using FluentValidation;
using Shiptech.Application.Commands;
using Shiptech.Application.Queries;
using Shiptech.Application.Services;

namespace Shiptech.Application.Validators.Drawing;

public class GetDrawingValidator : AbstractValidator<GetDrawing>
{
    public GetDrawingValidator(IDrawingReadService service)
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("GET_DRAWING_400_ID")
            .WithMessage("Identyfikator rysunku nie może być pusty!")
            .MustAsync(async (x, _) => await service.ExistsById(x))
            .WithMessage(x => $"{x.Id} nie istnieje w bazie!")
            .WithErrorCode("GET_DRAWING_404_ID");
    }
}