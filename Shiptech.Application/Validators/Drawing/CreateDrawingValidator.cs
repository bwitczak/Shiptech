using FluentValidation;
using Shiptech.Application.Commands;
using Shiptech.Application.Services;
using Shiptech.Application.Validators.Consts;

namespace Shiptech.Application.Validators.Drawing;

public class CreateDrawingValidator : AbstractValidator<CreateDrawing>
{
    public CreateDrawingValidator(IDrawingReadService service)
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CREATE_DRAWING_400_NAME")
            .WithMessage("Nazwa rysunku nie może być pusta!");
        
        RuleFor(x => x.DrawingRevision)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CREATE_DRAWING_400_REVISION")
            .WithMessage("Nazwa rewizji nie może być pusta!")
            .Must(char.IsLetterOrDigit)
            .WithErrorCode("CREATE_DRAWING_400_REVISION")
            .WithMessage(x => $"Niepoprawna rewizja {x.DrawingRevision}! Wymagany 1 znak");

        RuleFor(x => x.Lot)
            .Must(x =>
            {
                if (!int.TryParse(x, out var number))
                {
                    return false;
                }
                
                return number is >= 100 and <= 999;
            })
            .WithErrorCode("CREATE_DRAWING_400_LOT")
            .WithMessage(x => $"Niepoprawny lot {x.Lot}! Wymagane > 99 oraz < 1000");
        
        RuleFor(x => x.Block)
            .Must(x =>
            {
                if (!int.TryParse(x, out var number))
                {
                    return false;
                }
                
                return number is >= 100 and <= 999;
            })
            .WithErrorCode("CREATE_DRAWING_400_BLOCK")
            .WithMessage(x => $"Niepoprawny blok {x.Block}! Wymagane > 99 oraz < 1000");
        
        RuleForEach(x => x.Section)
            .Must(x =>
            {
                if (!int.TryParse(x, out var number))
                {
                    return false;
                }
                
                return number is >= 100 and <= 999;
            })
            .WithErrorCode("CREATE_DRAWING_400_SECTION")
            .WithMessage(x => $"Niepoprawna sekcja {x.Section}! Wymagane > 999 oraz < 10000");

        RuleFor(x => x.Stage)
            .Must(x => x is StageConsts.None or StageConsts.Odp or StageConsts.Ods or StageConsts.Odi)
            .WithErrorCode("CREATE_DRAWING_400_STAGE")
            .WithMessage(x => $"Niepoprawna sekcja {x.Stage}! Wymagane ODP/ODS/ODI/Puste");

        RuleFor(x => x.CreationDate)
            .NotNull()
            .WithErrorCode("CREATE_DRAWING_400_DATE")
            .WithMessage("Data utworzenia nie może być pusta!");
        
        RuleFor(x => x.Author)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CREATE_DRAWING_400_AUTHOR")
            .WithMessage("Autor nie może być pusty!");
    }
}