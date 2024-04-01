using FluentValidation;
using Shiptech.Application.Commands;
using Shiptech.Application.Services;

namespace Shiptech.Application.Validators.Assortment;

public class CreateAssortmentValidator : AbstractValidator<CreateAssortment>
{
    public CreateAssortmentValidator(IAssortmentReadService service)
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("ASSORTMENT_400_NAME")
            .WithMessage("Nazwa asortymentu nie może być pusta!");
        
        RuleFor(x => x.Position)
            .NotEmpty()
            .NotNull()
            .WithErrorCode("ASSORTMENT_400_POSITION")
            .WithMessage("Nazwa pozycji nie może być pusta!")
            .Must(char.IsLetter)
            .WithErrorCode("ASSORTMENT_400_POSITION")
            .WithMessage(x => $"Niepoprawna pozycja {x.Position}! Wymagany 1 znak");

        RuleFor(x => x.DrawingLength)
            .Must(x => x > 0)
            .WithErrorCode("ASSORTMENT_400_DRAWING_LENGTH")
            .WithMessage(x => $"Długość rysunku {x.DrawingLength}mm jest < 0!");

        RuleFor(x => x.Addition)
            .Must(x => x > 0)
            .WithErrorCode("ASSORTMENT_400_ADDITION")
            .WithMessage(x => $"Naddatek {x.Addition}mm jest < 0!");
        
        RuleFor(x => x.TechnologicalAddition)
            .Must(x => x > 0)
            .WithErrorCode("ASSORTMENT_400_TECHNOLOGICAL_ADDITION")
            .WithMessage(x => $"Długość technologicznego naddatku {x.TechnologicalAddition}mm jest < 0!");
            
        RuleFor(x => x.Stage)
            .Must(x =>
            {
                if (!int.TryParse($"{x}", out var number))
                {
                    return false;
                }
                
                return number is 1 or 2 or 3;
            })
            .WithErrorCode("ASSORTMENT_400_STAGE")
            .WithMessage(x => $"Niepoprawna faza {x.Stage}! Wymagane 1, 2 or 3");
        
        RuleFor(x => x.D15I)
            .Must(x => x is > 0 and <= 90)
            .WithErrorCode("ASSORTMENT_400_TECHNOLOGICAL_D15I")
            .WithMessage(x => $"Niepoprawny kąt 1.5D {x.D15I}! Wymagane > 0 oraz <= 90");
        
        RuleFor(x => x.D15II)
            .Must(x => x is > 0 and <= 90)
            .WithErrorCode("ASSORTMENT_400_TECHNOLOGICAL_D15II")
            .WithMessage(x => $"Niepoprawny kąt 1.5D {x.D15II}! Wymagane > 0 oraz <= 90");
        
        RuleFor(x => x.D1I)
            .Must(x => x is > 0 and <= 90)
            .WithErrorCode("ASSORTMENT_400_TECHNOLOGICAL_D1I")
            .WithMessage(x => $"Niepoprawny kąt 1D {x.D1I}! Wymagane > 0 oraz <= 90");
        
        RuleFor(x => x.D1II)
            .Must(x => x is > 0 and <= 90)
            .WithErrorCode("ASSORTMENT_400_TECHNOLOGICAL_D1II")
            .WithMessage(x => $"Niepoprawny kąt 1D {x.D1II}! Wymagane > 0 oraz <= 90");

        RuleFor(x => x.PrefabricationQuantity)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("ASSORTMENT_400_PREFABRICATION_QUANTITY")
            .WithMessage("Ilość prefabrykacji nie może być puste!")
            .Must(x => x > 0)
            .WithErrorCode("ASSORTMENT_400_PREFABRICATION_QUANTITY")
            .WithMessage(x => $"Ilość prefabrykacji {x.PrefabricationQuantity} jest < 0!");
        
        RuleFor(x => x.PrefabricationLength)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("ASSORTMENT_400_PREFABRICATION_LENGTH")
            .WithMessage("Długość prefabrykacji nie może być pusta!")
            .Must(x => x > 0)
            .WithErrorCode("ASSORTMENT_400_PREFABRICATION_LENGTH")
            .WithMessage(x => $"Długość prefabrykacji {x.PrefabricationLength}mm jest < 0!");
        
        RuleFor(x => x.PrefabricationWeight)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("ASSORTMENT_400_PREFABRICATION_WEIGHT")
            .WithMessage("Waga prefabrykacji nie może być pusta!")
            .Must(x => x > 0)
            .WithErrorCode("ASSORTMENT_400_PREFABRICATION_WEIGHT")
            .WithMessage(x => $"Waga prefabrykacji {x.PrefabricationWeight}kg jest < 0!");
        
        RuleFor(x => x.AssemblyQuantity)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("ASSORTMENT_400_ASSEMBLY_QUANTITY")
            .WithMessage("Ilość montażowa nie może być puste!")
            .Must(x => x > 0)
            .WithErrorCode("ASSORTMENT_400_ASSEMBLY_QUANTITY")
            .WithMessage(x => $"Ilość montażowa {x.AssemblyQuantity} jest < 0!");
        
        RuleFor(x => x.AssemblyLength)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("ASSORTMENT_400_ASSEMBLY_LENGTH")
            .WithMessage("Długość montażowa nie może być pusta!")
            .Must(x => x > 0)
            .WithErrorCode("ASSORTMENT_400_ASSEMBLY_LENGTH")
            .WithMessage(x => $"Długość montażowa {x.AssemblyLength}mm jest < 0!");
        
        RuleFor(x => x.AssemblyWeight)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("ASSORTMENT_400_ASSEMBLY_WEIGHT")
            .WithMessage("Waga montażowa nie może być pusta!")
            .Must(x => x > 0)
            .WithErrorCode("ASSORTMENT_400_ASSEMBLY_WEIGHT")
            .WithMessage(x => $"Waga montażowa {x.AssemblyWeight}kg jest < 0!");
    }
}