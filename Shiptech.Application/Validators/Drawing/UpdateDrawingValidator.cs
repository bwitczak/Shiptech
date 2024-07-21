using FluentValidation;
using Shiptech.Application.Commands;
using Shiptech.Application.Services;
using Shiptech.Application.Validators.Consts;

namespace Shiptech.Application.Validators.Drawing;

public class UpdateDrawingValidator : AbstractValidator<UpdateDrawing>
{
    public UpdateDrawingValidator(IDrawingReadService service)
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("UPDATE_DRAWING_400_ID")
            .WithMessage("Identyfikator rysunku nie może być pusty!")
            .MustAsync(async (x, _) => await service.ExistsById(x))
            .WithMessage(x => $"{x.Id} nie istnieje w bazie!")
            .WithErrorCode("UPDATE_DRAWING_404_ID");

           RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("UPDATE_DRAWING_400_NAME")
            .WithMessage("Nazwa rysunku nie może być pusta!");
        
        RuleFor(x => x.DrawingRevision)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("UPDATE_DRAWING_400_REVISION")
            .WithMessage("Nazwa rewizji nie może być pusta!")
            .Must(char.IsLetterOrDigit)
            .WithErrorCode("UPDATE_DRAWING_400_REVISION")
            .WithMessage(x => $"Niepoprawna rewizja {x.DrawingRevision}! Wymagany 1 znak");

        When(x => x.Lot is not null, () =>
        {
            RuleFor(x => x.Lot)
                .Must(x =>
                {
                    if (!int.TryParse(x, out var number))
                    {
                        return false;
                    }
                
                    return number is >= 100 and <= 999;
                })
                .WithErrorCode("UPDATE_DRAWING_400_LOT")
                .WithMessage(x => $"Niepoprawny lot {x.Lot}! Wymagane > 99 oraz < 1000");
        });

        When(x => x.Block is not null, () =>
        {
            RuleFor(x => x.Block)
                .Must(x => x!.Length == 3)
                .WithErrorCode("UPDATE_DRAWING_400_BLOCK")
                .WithMessage(x => $"Niepoprawny blok {x.Block}! Wymagane > 99 oraz < 1000");
        });

        When(x => x.Section is not null, () =>
        {
            RuleForEach(x => x.Section)
                .Must(x =>
                {
                    if (!int.TryParse(x, out var number))
                    {
                        return false;
                    }

                    return number is >= 100 and <= 999;
                })
                .WithErrorCode("UPDATE_DRAWING_400_SECTION")
                .WithMessage(x => $"Niepoprawna sekcja {x.Section}! Wymagane > 999 oraz < 10000");
        });

        When(x => x.Stage is not null, () =>
        {
            RuleFor(x => x.Stage)
                .Must(x => x is StageConsts.None or StageConsts.Odp or StageConsts.Ods or StageConsts.Odi)
                .WithErrorCode("UPDATE_DRAWING_400_STAGE")
                .WithMessage(x => $"Niepoprawna sekcja {x.Stage}! Wymagane ODP/ODS/ODI/Puste");
        });

        RuleFor(x => x.CreationDate)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("UPDATE_DRAWING_400_DATE")
            .WithMessage("Data utworzenia nie może być pusta!");
        
        RuleFor(x => x.Author)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("UPDATE_DRAWING_400_AUTHOR")
            .WithMessage("Autor nie może być pusty!");
    }
}