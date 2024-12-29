using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Common.Interfaces.Database;
using Shiptech.Application.Common.Interfaces.Services;
using Shiptech.Domain.Constants;
using Shiptech.Domain.Entities;
using Shiptech.Domain.Factories;

namespace Shiptech.Application.Assortments.Commands.CreateAssortment;

public record CreateAssortmentCommand(
    char Position,
    ushort PrefabricationQuantity,
    ushort PrefabricationLength,
    double PrefabricationWeight,
    ushort AssemblyQuantity,
    ushort AssemblyLength,
    double AssemblyWeight,
    char PG,
    string? ValveNumber,
    string? CutAngle,
    string? Comment,
    Ulid IsoId,
    Ulid AssortmentDictionaryId) : IRequest
{
}

public class CreateAssortmentCommandValidator : AbstractValidator<CreateAssortmentCommand>
{
    public CreateAssortmentCommandValidator(IIsoService isoService,
        IAssortmentDictionaryService assortmentDictionaryService)
    {
        RuleFor(x => x.Position)
            .NotEmpty()
            .NotNull()
            .WithErrorCode("CREATE_ASSORTMENT_400_POSITION")
            .WithMessage("Nazwa pozycji nie może być pusta!")
            .Must(char.IsLetter)
            .WithErrorCode("CREATE_ASSORTMENT_400_POSITION")
            .WithMessage(x => $"Niepoprawna pozycja {x.Position}! Wymagany 1 znak");

        RuleFor(x => x.PrefabricationQuantity)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CREATE_ASSORTMENT_400_PREFABRICATION_QUANTITY")
            .WithMessage("Ilość prefabrykacji nie może być puste!")
            .Must(x => x > 0)
            .WithErrorCode("CREATE_ASSORTMENT_400_PREFABRICATION_QUANTITY")
            .WithMessage(x => $"Ilość prefabrykacji {x.PrefabricationQuantity} jest < 0!");

        RuleFor(x => x.PrefabricationLength)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CREATE_ASSORTMENT_400_PREFABRICATION_LENGTH")
            .WithMessage("Długość prefabrykacji nie może być pusta!")
            .Must(x => x > 0)
            .WithErrorCode("CREATE_ASSORTMENT_400_PREFABRICATION_LENGTH")
            .WithMessage(x => $"Długość prefabrykacji {x.PrefabricationLength}mm jest < 0!");

        RuleFor(x => x.PrefabricationWeight)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CREATE_ASSORTMENT_400_PREFABRICATION_WEIGHT")
            .WithMessage("Waga prefabrykacji nie może być pusta!")
            .Must(x => x > 0)
            .WithErrorCode("CREATE_ASSORTMENT_400_PREFABRICATION_WEIGHT")
            .WithMessage(x => $"Waga prefabrykacji {x.PrefabricationWeight}kg jest < 0!");

        RuleFor(x => x.AssemblyQuantity)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CREATE_ASSORTMENT_400_ASSEMBLY_QUANTITY")
            .WithMessage("Ilość montażowa nie może być puste!")
            .Must(x => x > 0)
            .WithErrorCode("CREATE_ASSORTMENT_400_ASSEMBLY_QUANTITY")
            .WithMessage(x => $"Ilość montażowa {x.AssemblyQuantity} jest < 0!");

        RuleFor(x => x.AssemblyLength)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CREATE_ASSORTMENT_400_ASSEMBLY_LENGTH")
            .WithMessage("Długość montażowa nie może być pusta!")
            .Must(x => x > 0)
            .WithErrorCode("CREATE_ASSORTMENT_400_ASSEMBLY_LENGTH")
            .WithMessage(x => $"Długość montażowa {x.AssemblyLength}mm jest < 0!");

        RuleFor(x => x.AssemblyWeight)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CREATE_ASSORTMENT_400_ASSEMBLY_WEIGHT")
            .WithMessage("Waga montażowa nie może być pusta!")
            .Must(x => x > 0)
            .WithErrorCode("CREATE_ASSORTMENT_400_ASSEMBLY_WEIGHT")
            .WithMessage(x => $"Waga montażowa {x.AssemblyWeight}kg jest < 0!");

        RuleFor(x => x.PG)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CREATE_ASSORTMENT_400_PG")
            .WithMessage("P/G nie może być puste!")
            .Must(x => x is PG.Straight or PG.Curved)
            .WithErrorCode("CREATE_ASSORTMENT_400_PG")
            .WithMessage(x => $"Niepoprawne P/G {x.PG}! Wymagane P/G.");

        When(x => x.ValveNumber is not null, () =>
        {
            RuleFor(x => x.ValveNumber)
                .NotNull()
                .NotEmpty()
                .WithErrorCode("CREATE_ASSORTMENT_400_VALVE_NUMBER")
                .WithMessage("Numer zaworu nie może być pusty!");
        });

        When(x => x.CutAngle is not null, () =>
        {
            RuleFor(x => x.CutAngle)
                .NotNull()
                .NotEmpty()
                .WithErrorCode("CREATE_ASSORTMENT_400_CUT_ANGLE")
                .WithMessage("Kąt cięcia nie może być pusty!");
        });

        When(x => x.Comment is not null, () =>
        {
            RuleFor(x => x.Comment)
                .NotNull()
                .NotEmpty()
                .WithErrorCode("CREATE_ASSORTMENT_400_COMMENT")
                .WithMessage("Komentarz nie może być pusty!");
        });

        RuleFor(x => x.IsoId)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("UPDATE_ASSORTMENT_400_ISO_ID")
            .WithMessage("Identyfikator asortymentu nie może być pusty!")
            .MustAsync(async (x, _) => await isoService.ExistsById(x))
            .WithMessage(x => $"{x.IsoId} nie istnieje w bazie!")
            .WithErrorCode("UPDATE_ASSORTMENT_404_ISO_ID");

        RuleFor(x => x.AssortmentDictionaryId)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("UPDATE_ASSORTMENT_400_ASSORTMENT_DICTIONARY_ID")
            .WithMessage("Identyfikator asortymentu nie może być pusty!")
            .MustAsync(async (x, _) => await assortmentDictionaryService.ExistsById(x))
            .WithMessage(x => $"{x.AssortmentDictionaryId} nie istnieje w bazie!")
            .WithErrorCode("UPDATE_ASSORTMENT_404_ASSORTMENT_DICTIONARY_ID");
    }
}

public class CreateAssortmentCommandHandler : IRequestHandler<CreateAssortmentCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IAssortmentFactory _factory;

    public CreateAssortmentCommandHandler(IApplicationDbContext context, IAssortmentFactory factory)
    {
        _context = context;
        _factory = factory;
    }

    public async Task Handle(CreateAssortmentCommand request, CancellationToken cancellationToken)
    {
        (char position, ushort prefabricationQuantity, ushort prefabricationLength, double prefabricationWeight,
            ushort assemblyQuantity, ushort assemblyLength, double assemblyWeight, char pg, string? valveNumber,
            string? cutAngle, string? comment, Ulid isoId,
            Ulid assortmentDictionaryId) = request;

        Iso iso = await _context.Isos.FirstAsync(x => x.Id == isoId, cancellationToken);
        Domain.Entities.AssortmentDictionary assortmentDictionary =
            await _context.AssortmentDictionaries.FirstAsync(x => x.Id == assortmentDictionaryId, cancellationToken);
        Assortment assortment = _factory.Create(Ulid.NewUlid(), position, prefabricationQuantity, prefabricationLength,
            prefabricationWeight, assemblyQuantity, assemblyLength, assemblyWeight, pg, valveNumber, cutAngle, comment,
            iso, assortmentDictionary);

        await _context.Assortments.AddAsync(assortment, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
