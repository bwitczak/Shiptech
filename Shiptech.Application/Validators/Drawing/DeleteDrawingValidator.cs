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
            .WithErrorCode("DRAWING_400_ID")
            .WithMessage("Nazwa rysunku nie może być pusta!")
            .MustAsync(async (x, _) => await service.ExistsById(x))
            .WithMessage(x => $"{x.Id} już istnieje w bazie!")
            .WithErrorCode("DRAWING_409_ID");
    }
}