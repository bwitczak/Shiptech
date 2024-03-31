using FluentValidation;
using Shiptech.Application.Commands;
using Shiptech.Application.Services;

namespace Shiptech.Application.Validators.ChemicalProcess;

public class DeleteChemicalProcessValidator : AbstractValidator<DeleteChemicalProcess>
{
    public DeleteChemicalProcessValidator(IChemicalProcessReadService service)
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CHEMICAL_PROCESS_400_ID")
            .WithMessage("Identyfikator procesu chemicznego nie może być pusty!")
            .MustAsync(async (x, _) => await service.ExistsById(x))
            .WithMessage(x => $"{x.Id} nie istnieje w bazie!")
            .WithErrorCode("CHEMICAL_PROCESS_404_ID");
    }
}