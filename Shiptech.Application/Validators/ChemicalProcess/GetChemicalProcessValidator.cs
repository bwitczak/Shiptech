using FluentValidation;
using Shiptech.Application.Commands;
using Shiptech.Application.Queries;
using Shiptech.Application.Services;

namespace Shiptech.Application.Validators.ChemicalProcess;

public class GetChemicalProcessValidator :AbstractValidator<GetChemicalProcess>
{
    public GetChemicalProcessValidator(IChemicalProcessReadService service)
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("DELETE_CHEMICAL_PROCESS_400_ID")
            .WithMessage("Identyfikator procesu chemicznego nie może być pusty!")
            .MustAsync(async (x, _) => await service.ExistsById(x))
            .WithMessage(x => $"{x.Id} nie istnieje w bazie!")
            .WithErrorCode("DELETE_CHEMICAL_PROCESS_404_ID");
    }
}