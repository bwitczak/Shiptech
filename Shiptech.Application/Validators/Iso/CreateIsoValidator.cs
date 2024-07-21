using FluentValidation;
using Shiptech.Application.Commands;
using Shiptech.Application.Services;
using Shiptech.Application.Validators.Consts;

namespace Shiptech.Application.Validators.Iso;

public class CreateIsoValidator : AbstractValidator<CreateIso>
{
    public CreateIsoValidator(IIsoReadService service)
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CREATE_ISO_400_NAME")
            .WithMessage("Nazwa ISO nie może być pusta!");
        
        RuleFor(x => x.IsoRevision)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CREATE_ISO_400_REVISION")
            .WithMessage("Nazwa rewizji nie może być pusta!")
            .Must(char.IsLetterOrDigit)
            .WithErrorCode("CREATE_ISO_400_REVISION")
            .WithMessage(x => $"Niepoprawna rewizja {x.IsoRevision}! Wymagany 1 znak");

        RuleFor(x => x.System)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CREATE_ISO_400_SYSTEM")
            .WithMessage("Nazwa systemu nie może być pusta!")
            .Must(x => x.Split("-").Length == 1 && x.Split("-").Length == 2)
            .WithErrorCode("CREATE_ISO_400_SYSTEM")
            .WithMessage(x => $"Niepoprawny format systemu izometryka {x.System}! Wymagany format XXX lub XXX-XXX");
        
        RuleFor(x => x.Class)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CREATE_ISO_400_CLASS")
            .WithMessage("Nazwa klasy nie może być pusta!")
            .Must(x => x.Length == 6)
            .WithErrorCode("CREATE_ISO_400_CLASS")
            .WithMessage(x => $"Nie poprawna klasa {x.Class}! Wymagane 6 znaków");

        When(x => x.Atest is not null, () =>
        {
            RuleFor(x => x.Atest)
                .Must(x => x is AtestConsts.None or AtestConsts.Yes or AtestConsts.No)
                .WithErrorCode("CREATE_ISO_400_ATEST")
                .WithMessage(x => $"Nie poprawny atest {x.Atest}! Wymagane Tak/Nie/Puste");
        });

        When(x => x.KzmNumber is not null, () =>
        {
            RuleFor(x => x.KzmNumber)
                .Must(x => x.Length == 6)
                .WithErrorCode("CREATE_ISO_400_KZM_NUMBER")
                .WithMessage(x => $"Niepoprawny format numeru KZM {x.KzmNumber}! Wymagane 6 znaków");
        });

        When(x => x.KzmDate is not null, () =>
        {
            RuleFor(x => x.KzmDate)
                .NotNull()
                .NotEmpty()
                .WithErrorCode("CREATE_ISO_400_KZM_DATE")
                .WithMessage("Data KZM nie może być pusta!");
        });
    }
}