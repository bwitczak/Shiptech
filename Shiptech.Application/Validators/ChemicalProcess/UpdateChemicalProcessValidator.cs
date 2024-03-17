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
            .WithMessage("Kod procesu chemicznego nie może być pusta!")
            .MustAsync(async (x, _) => !await service.ExistsById(x))
            .WithMessage(x => $"{x.Id} już istnieje w bazie!")
            .WithErrorCode("CHEMICAL_PROCESS_409_ID");

        RuleFor(x => x.ChemicalProcessName)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CHEMICAL_PROCESS_400_NAME")
            .WithMessage("Nazwa procesu chemicznego nie może być pusta!");
    }
}