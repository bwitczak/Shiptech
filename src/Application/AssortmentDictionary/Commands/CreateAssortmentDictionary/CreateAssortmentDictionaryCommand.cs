using FluentValidation;
using MediatR;
using Shiptech.Application.Common.Interfaces.Database;
using Shiptech.Domain.Constants;
using Shiptech.Domain.Factories;
using Unit = Shiptech.Domain.Constants.Unit;

namespace Shiptech.Application.AssortmentDictionary.Commands.CreateAssortmentDictionary;

public record CreateAssortmentDictionaryCommand(
    string Number,
    string Name,
    string? Distinguishing,
    string Unit,
    double? Amount,
    double? Weight,
    string? Material,
    string? Kind,
    string? DN1,
    string? DN2,
    ushort? Length,
    string? RA,
    string? NS,
    string? Comment) : IRequest
{
}

public class CreateAssortmentDictionaryCommandValidator : AbstractValidator<CreateAssortmentDictionaryCommand>
{
    public CreateAssortmentDictionaryCommandValidator()
    {
        RuleFor(x => x.Number)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CREATE_ASSORTMENT_DICTIONARY_400_NUMBER")
            .WithMessage("Numer asortymentu nie może być pusty!");

        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CREATE_ASSORTMENT_DICTIONARY_400_NAME")
            .WithMessage("Nazwa asortymentu nie może być pusta!");

        When(x => x.Distinguishing is not null, () =>
        {
            RuleFor(x => x.Distinguishing)
                .NotNull()
                .NotEmpty()
                .WithErrorCode("CREATE_ASSORTMENT_DICTIONARY_400_DISTINGUISHING")
                .WithMessage("Wyróżnik nie może być pusty!");
        });

        RuleFor(x => x.Unit)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CREATE_ASSORTMENT_DICTIONARY_400_UNIT")
            .WithMessage("Jednostka nie może być pusta!")
            .Must(x => x is Unit.KG or Unit.PIECE)
            .WithErrorCode("CREATE_ASSORTMENT_DICTIONARY_400_UNIT")
            .WithMessage(x => $"Niepoprawna sekcja {x.Unit}! Wymagane kg/szt.");

        When(x => x.Amount is not null, () =>
        {
            RuleFor(x => x.Amount)
                .NotNull()
                .NotEmpty()
                .WithErrorCode("CREATE_ASSORTMENT_DICTIONARY_400_AMOUNT")
                .WithMessage("Ilość nie może być pusta!")
                .Must(x => x > 0.0)
                .WithErrorCode("CREATE_ASSORTMENT_DICTIONARY_400_AMOUNT")
                .WithMessage(x => $"Ilość {x.Amount}{x.Unit} jest < 0!");
        });

        When(x => x.Weight is not null, () =>
        {
            RuleFor(x => x.Weight)
                .NotNull()
                .NotEmpty()
                .WithErrorCode("CREATE_ASSORTMENT_DICTIONARY_400_WEIGHT")
                .WithMessage("Waga nie może być pusta!")
                .Must(x => x > 0.0)
                .WithErrorCode("CREATE_ASSORTMENT_DICTIONARY_400_WEIGHT")
                .WithMessage(x => $"Waga {x.Amount}{x.Unit} jest < 0!");
        });

        When(x => x.Material is not null, () =>
        {
            RuleFor(x => x.Material)
                .NotNull()
                .NotEmpty()
                .WithErrorCode("CREATE_ASSORTMENT_DICTIONARY_400_Material")
                .WithMessage("Materiał nie może być pusty!");
        });

        When(x => x.Kind is not null, () =>
        {
            RuleFor(x => x.Kind)
                .NotNull()
                .NotEmpty()
                .WithErrorCode("CREATE_ASSORTMENT_DICTIONARY_400_Kind")
                .WithMessage("Gatunek nie może być pusty!");
        });

        When(x => x.DN1 is not null, () =>
        {
            RuleFor(x => x.DN1)
                .Must(x =>
                {
                    if (!double.TryParse(x, out double number))
                    {
                        return false;
                    }

                    return number is > 0 and <= 1000;
                })
                .WithErrorCode("CREATE_ASSORTMENT_DICTIONARY_400_DN1")
                .WithMessage(x => "DN1 jest < 0 lub powyżej 1000!");
        });

        When(x => x.DN2 is not null, () =>
        {
            RuleFor(x => x.DN2)
                .Must(x =>
                {
                    if (!double.TryParse(x, out double number))
                    {
                        return false;
                    }

                    return number is > 0 and <= 1000;
                })
                .WithErrorCode("CREATE_ASSORTMENT_DICTIONARY_400_DN1")
                .WithMessage(x => "DN2 jest < 0 lub powyżej 1000!");
        });

        When(x => x.Length is not null, () =>
        {
            RuleFor(x => x.Length)
                .NotNull()
                .NotEmpty()
                .WithErrorCode("CREATE_ASSORTMENT_DICTIONARY_400_LENGTH")
                .WithMessage("Długość nie może być puste!")
                .Must(x => x > 0.0)
                .WithErrorCode("CREATE_ASSORTMENT_DICTIONARY_400_LENGTH")
                .WithMessage(x => $"Długość {x.Length}{x.Unit} jest < 0!");
        });

        When(x => x.RA is not null, () =>
        {
            RuleFor(x => x.RA)
                .Must(x => x is RA.PIPE or RA.ARMATURE)
                .WithErrorCode("CREATE_ASSORTMENT_DICTIONARY_400_RO")
                .WithMessage(x => "RA musi mieć wartość Rura lub Armatura!");
        });

        When(x => x.NS is not null, () =>
        {
            RuleFor(x => x.NS)
                .NotNull()
                .NotEmpty()
                .WithErrorCode("CREATE_ASSORTMENT_DICTIONARY_400_NS")
                .WithMessage("NS nie może być puste!");
        });

        When(x => x.Comment is not null, () =>
        {
            RuleFor(x => x.Comment)
                .NotNull()
                .NotEmpty()
                .WithErrorCode("CREATE_ASSORTMENT_DICTIONARY_400_COMMENT")
                .WithMessage("Komentarz nie może być pusty!");
        });
    }
}

public class CreateAssortmentDictionaryCommandHandler : IRequestHandler<CreateAssortmentDictionaryCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IAssortmentDictionaryFactory _factory;

    public CreateAssortmentDictionaryCommandHandler(IApplicationDbContext context, IAssortmentDictionaryFactory factory)
    {
        _context = context;
        _factory = factory;
    }

    public async Task Handle(CreateAssortmentDictionaryCommand request, CancellationToken cancellationToken)
    {
        (string? number, string? name, string? distinguishing, string? unit, double? amount, double? weight,
                string? material, string? kind, string? dn1, string? dn2, ushort? length, string? ra, string? ns,
                string? comment) =
            request;

        Domain.Entities.AssortmentDictionary? assortmentDictionary = _factory.Create(Ulid.NewUlid(), number, name,
            distinguishing, unit, amount, weight, material, kind,
            dn1, dn2, length, ra, ns, comment);

        await _context.AssortmentDictionaries.AddAsync(assortmentDictionary, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
