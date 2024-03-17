using FluentValidation;
using Shiptech.Application.Commands;
using Shiptech.Application.Services;
using Shiptech.Application.Validators.Consts;

namespace Shiptech.Application.Validators.Iso;

public class CreateIsoValidator : AbstractValidator<CreateIso>
{
    public CreateIsoValidator(IIsoReadService service)
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("ISO_400_ID")
            .WithMessage("Nazwa izometryka nie może być pusta!")
            .MustAsync(async (x, _) => !await service.ExistsById(x))
            .WithMessage(x => $"{x.Id} już istnieje w bazie!")
            .WithErrorCode("ISO_409_ID");
        
        RuleFor(x => x.IsoRevision)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("ISO_400_REVISION")
            .WithMessage("Nazwa rewizji nie może być pusta!")
            .Must(char.IsLetterOrDigit)
            .WithErrorCode("ISO_400_REVISION")
            .WithMessage(x => $"Niepoprawna rewizja {x.IsoRevision}! Wymagany 1 znak");

        RuleFor(x => x.System)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("ISO_400_SYSTEM")
            .WithMessage("Nazwa systemu nie może być pusta!")
            .Must(x => x.Split("-").Length == 1 && x.Split("-").Length == 2)
            .WithErrorCode("ISO_400_SYSTEM")
            .WithMessage(x => $"Niepoprawny format systemu izometryka {x.System}! Wymagany format XXX lub XXX-XXX");
        
        RuleFor(x => x.Class)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("ISO_400_CLASS")
            .WithMessage("Nazwa klasy nie może być pusta!")
            .Must(x => x.Length == 6)
            .WithErrorCode("ISO_400_CLASS")
            .WithMessage(x => $"Nie poprawna klasa {x.Class}! Wymagane 6 znaków");
        
        RuleFor(x => x.Atest)
            .Must(x => x is AtestConsts.None or AtestConsts.Yes or AtestConsts.No)
            .WithErrorCode("ISO_400_ATEST")
            .WithMessage(x => $"Nie poprawny atest {x.Atest}! Wymagane Tak/Nie/Puste");
        
        RuleFor(x=>x.KzmNumber)
            .Must(x => x.Length == 6)
            .WithErrorCode("ISO_400_KZM_NUMBER")
            .WithMessage(x => $"Niepoprawny format numeru KZM {x.KzmNumber}! Wymagane 6 znaków");
    }
}