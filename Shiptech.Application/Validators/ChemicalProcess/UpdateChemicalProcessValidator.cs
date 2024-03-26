using FluentValidation;
using Shiptech.Application.Commands;
using Shiptech.Application.Services;

namespace Shiptech.Application.Validators.ChemicalProcess;

public class UpdateChemicalProcessValidator : AbstractValidator<UpdateChemicalProcess>
{
    public UpdateChemicalProcessValidator(IChemicalProcessReadService service)
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CHEMICAL_PROCESS_400_ID")
            .WithMessage("Identyfikator procesu chemicznego nie może być pusty!")
            .MustAsync(async (x, _) => await service.ExistsById(x))
            .WithMessage(x => $"{x.Id} nie istnieje w bazie!")
            .WithErrorCode("CHEMICAL_PROCESS_404_ID");

        RuleFor(x => x.ChemicalProcessCode)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CHEMICAL_PROCESS_400_CODE")
            .WithMessage("Kod procesu chemicznego nie może być pusty!");

        RuleFor(x => x.ChemicalProcessName)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CHEMICAL_PROCESS_400_NAME")
            .WithMessage("Nazwa procesu chemicznego nie może być pusta!");
    }
}