using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Common.Interfaces.Database;
using Shiptech.Application.Common.Interfaces.Services;

namespace Shiptech.Application.ChemicalProcesses.Commands.DeleteChemicalProcess;

public record DeleteChemicalProcessCommand(Ulid Id) : IRequest
{
}

public class DeleteChemicalProcessCommandValidator : AbstractValidator<DeleteChemicalProcessCommand>
{
    public DeleteChemicalProcessCommandValidator(IChemicalProcessService service)
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

public class DeleteChemicalProcessCommandHandler : IRequestHandler<DeleteChemicalProcessCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteChemicalProcessCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteChemicalProcessCommand request, CancellationToken cancellationToken)
    {
        var chemicalProcess = await _context.ChemicalProcesses.AsNoTracking()
            .SingleAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

        _context.ChemicalProcesses.Remove(chemicalProcess);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
