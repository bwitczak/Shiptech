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
            .WithMessage("Kod procesu chemicznego nie może być pusta!")
            .MustAsync(async (x, _) => !await service.ExistsById(x))
            .WithMessage(x => $"{x.Id} już istnieje w bazie!")
            .WithErrorCode("CHEMICAL_PROCESS_409_ID");
    }
}