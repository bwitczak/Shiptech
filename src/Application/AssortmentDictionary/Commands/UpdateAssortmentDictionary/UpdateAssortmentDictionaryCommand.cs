using FluentValidation;
using MediatR;
using Shiptech.Application.Common.Interfaces.Database;
using Shiptech.Application.Common.Interfaces.Services;
using Shiptech.Domain.Constants;
using Shiptech.Domain.Factories;
using Unit = Shiptech.Domain.Constants.Unit;

namespace Shiptech.Application.AssortmentDictionary.Commands.UpdateAssortmentDictionary;

public record UpdateAssortmentDictionaryCommand(
    Ulid Id,
    string Number,
    string Name,
    string Distinguishing,
    string Unit,
    double? Amount,
    double? Weight,
    string? Material,
    string? Kind,
    ushort? DN1,
    ushort? DN2,
    ushort? Length,
    string RO,
    string? Comment) : IRequest
{
}

public class UpdateAssortmentDictionaryCommandValidator : AbstractValidator<UpdateAssortmentDictionaryCommand>
{
    public UpdateAssortmentDictionaryCommandValidator(IAssortmentDictionaryService service)
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("UPDATE_ASSORTMENT_DICTIONARY_400_ID")
            .WithMessage("Identyfikator asortymentu nie może być pusty!")
            .MustAsync(async (x, _) => await service.ExistsById(x))
            .WithMessage(x => $"{x.Id} nie istnieje w bazie!")
            .WithErrorCode("UPDATE_ASSORTMENT_DICTIONARY_404_ID");

        RuleFor(x => x.Number)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("UPDATE_ASSORTMENT_DICTIONARY_400_NUMBER")
            .WithMessage("Numer asortymentu nie może być pusty!");

        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("UPDATE_ASSORTMENT_DICTIONARY_400_NAME")
            .WithMessage("Nazwa asortymentu nie może być pusta!");

        RuleFor(x => x.Distinguishing)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("UPDATE_ASSORTMENT_DICTIONARY_400_DISTINGUISHING")
            .WithMessage("Wyróżnik nie może być pusty!");

        RuleFor(x => x.Unit)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("UPDATE_ASSORTMENT_DICTIONARY_400_UNIT")
            .WithMessage("Jednostka nie może być pusta!")
            .Must(x => x is Unit.KG or Unit.PIECE)
            .WithErrorCode("UPDATE_ASSORTMENT_DICTIONARY_400_UNIT")
            .WithMessage(x => $"Niepoprawna sekcja {x.Unit}! Wymagane kg/szt.");

        When(x => x.Amount is not null, () =>
        {
            RuleFor(x => x.Amount)
                .NotNull()
                .NotEmpty()
                .WithErrorCode("UPDATE_ASSORTMENT_DICTIONARY_400_AMOUNT")
                .WithMessage("Ilość nie może być pusta!")
                .Must(x => x > 0.0)
                .WithErrorCode("UPDATE_ASSORTMENT_DICTIONARY_400_AMOUNT")
                .WithMessage(x => $"Ilość {x.Amount}{x.Unit} jest < 0!");
        });

        When(x => x.Weight is not null, () =>
        {
            RuleFor(x => x.Weight)
                .NotNull()
                .NotEmpty()
                .WithErrorCode("UPDATE_ASSORTMENT_DICTIONARY_400_WEIGHT")
                .WithMessage("Waga nie może być pusta!")
                .Must(x => x > 0.0)
                .WithErrorCode("UPDATE_ASSORTMENT_DICTIONARY_400_WEIGHT")
                .WithMessage(x => $"Waga {x.Amount}{x.Unit} jest < 0!");
        });

        When(x => x.Material is not null, () =>
        {
            RuleFor(x => x.Material)
                .NotNull()
                .NotEmpty()
                .WithErrorCode("UPDATE_ASSORTMENT_DICTIONARY_400_Material")
                .WithMessage("Materiał nie może być pusty!");
        });

        When(x => x.Kind is not null, () =>
        {
            RuleFor(x => x.Kind)
                .NotNull()
                .NotEmpty()
                .WithErrorCode("UPDATE_ASSORTMENT_DICTIONARY_400_Kind")
                .WithMessage("Gatunek nie może być pusty!");
        });

        When(x => x.DN1 is not null, () =>
        {
            RuleFor(x => x.DN1)
                .Must(x => x > 0.0 && x <= 1000)
                .WithErrorCode("UPDATE_ASSORTMENT_DICTIONARY_400_DN1")
                .WithMessage(x => "DN1 jest < 0 lub powyżej 1000!");
        });

        When(x => x.DN2 is not null, () =>
        {
            RuleFor(x => x.DN2)
                .Must(x => x > 0.0 && x <= 1000)
                .WithErrorCode("UPDATE_ASSORTMENT_DICTIONARY_400_DN1")
                .WithMessage(x => "DN2 jest < 0 lub powyżej 1000!");
        });

        When(x => x.Length is not null, () =>
        {
            RuleFor(x => x.Length)
                .NotNull()
                .NotEmpty()
                .WithErrorCode("UPDATE_ASSORTMENT_DICTIONARY_400_LENGTH")
                .WithMessage("Długość nie może być puste!")
                .Must(x => x > 0.0)
                .WithErrorCode("UPDATE_ASSORTMENT_DICTIONARY_400_LENGTH")
                .WithMessage(x => $"Długość {x.Length}{x.Unit} jest < 0!");
        });

        RuleFor(x => x.RO)
            .Must(x => x is RO.PIPE or RO.ARMATURE)
            .WithErrorCode("UPDATE_ASSORTMENT_DICTIONARY_400_RO")
            .WithMessage(x => "RO musi mieć wartość Rura lub Armatura!");
    }
}

public class UpdateAssortmentDictionaryCommandHandler : IRequestHandler<UpdateAssortmentDictionaryCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IAssortmentDictionaryFactory _factory;

    public UpdateAssortmentDictionaryCommandHandler(IApplicationDbContext context, IAssortmentDictionaryFactory factory)
    {
        _context = context;
        _factory = factory;
    }

    public async Task Handle(UpdateAssortmentDictionaryCommand request, CancellationToken cancellationToken)
    {
        (Ulid id, string? number, string? name, string? distinguishing, string? unit, double? amount, double? weight,
                string? material, string? kind, ushort? dn1, ushort? dn2, ushort? length, string? ro, string? comment) =
            request;

        Domain.Entities.AssortmentDictionary? updated = _factory.Create(id, number, name, distinguishing, unit, amount,
            weight, material, kind,
            dn1, dn2, length, ro, comment);

        _context.AssortmentDictionaries.Update(updated);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
