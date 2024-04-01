using FluentValidation;
using Shiptech.Application.Commands;
using Shiptech.Application.Services;

namespace Shiptech.Application.Validators.Drawing;

public class DeleteDrawingValidator : AbstractValidator<DeleteDrawing>
{
    public DeleteDrawingValidator(IDrawingReadService service)
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("DELETE_DRAWING_400_ID")
            .WithMessage("Identyfikator rysunku nie może być pusty!")
            .MustAsync(async (x, _) => await service.ExistsById(x))
            .WithMessage(x => $"{x.Id} nie istnieje w bazie!")
            .WithErrorCode("DELETE_DRAWING_404_ID");
    }
}