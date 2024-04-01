using FluentValidation;
using Shiptech.Application.Commands;
using Shiptech.Application.Services;
using Shiptech.Application.Validators.Consts;

namespace Shiptech.Application.Validators.AssortmentDictionary;

public class UpdateAssortmentDictionaryValidator : AbstractValidator<UpdateAssortmentDictionary>
{
    public UpdateAssortmentDictionaryValidator(IAssortmentDictionaryReadService service)
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
            .Must(x => x is UnitConsts.Kg or UnitConsts.Szt)
            .WithErrorCode("UPDATE_ASSORTMENT_DICTIONARY_400_UNIT")
            .WithMessage(x => $"Niepoprawna sekcja {x.Unit}! Wymagane kg/szt.");
        
        RuleFor(x => x.Amount)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("UPDATE_ASSORTMENT_DICTIONARY_400_AMOUNT")
            .WithMessage("Ilość nie może być pusta!")
            .Must(x => x > 0.0)
            .WithErrorCode("UPDATE_ASSORTMENT_DICTIONARY_400_AMOUNT")
            .WithMessage(x => $"Ilość {x.Amount}{x.Unit} jest < 0!");
        
        RuleFor(x => x.Weight)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("UPDATE_ASSORTMENT_DICTIONARY_400_WEIGHT")
            .WithMessage("Waga nie może być pusta!")
            .Must(x => x > 0.0)
            .WithErrorCode("UPDATE_ASSORTMENT_DICTIONARY_400_WEIGHT")
            .WithMessage(x => $"Waga {x.Amount}{x.Unit} jest < 0!");
        
        // TODO: Material validator
        // TODO: Kind validator
        
        RuleFor(x => x.Length)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("UPDATE_ASSORTMENT_DICTIONARY_400_LENGTH")
            .WithMessage("Długość nie może być puste!")
            .Must(x => x > 0.0)
            .WithErrorCode("UPDATE_ASSORTMENT_DICTIONARY_400_LENGTH")
            .WithMessage(x => $"Długość {x.Length}{x.Unit} jest < 0!");

        RuleFor(x => x.RO)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("UPDATE_ASSORTMENT_DICTIONARY_400_RO")
            .WithMessage("RO nie może być puste!");
    }
}