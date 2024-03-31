using FluentValidation;
using Shiptech.Application.Commands;
using Shiptech.Application.Services;

namespace Shiptech.Application.Validators.ChemicalProcess;

public class CreateChemicalProcessValidator : AbstractValidator<CreateChemicalProcess>
{
    public CreateChemicalProcessValidator(IChemicalProcessReadService service)
    {
        RuleFor(x => x.ChemicalProcessCode)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CHEMICAL_PROCESS_400_ID")
            .WithMessage("Kod procesu chemicznego nie może być puste!");

        RuleFor(x => x.ChemicalProcessName)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CHEMICAL_PROCESS_400_NAME")
            .WithMessage("Nazwa procesu chemicznego nie może być pusta!");
    }
}