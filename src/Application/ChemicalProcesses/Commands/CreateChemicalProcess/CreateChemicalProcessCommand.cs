using FluentValidation;
using MediatR;
using Shiptech.Application.Common.Interfaces.Database;
using Shiptech.Domain.Entities;
using Shiptech.Domain.Factories;

namespace Shiptech.Application.ChemicalProcesses.Commands.CreateChemicalProcess;

public record CreateChemicalProcessCommand(string Code, string Name) : IRequest
{
}

public class CreateChemicalProcessCommandValidator : AbstractValidator<CreateChemicalProcessCommand>
{
    public CreateChemicalProcessCommandValidator()
    {
        RuleFor(x => x.Code)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CREATE_CHEMICAL_PROCESS_400_ID")
            .WithMessage("Kod procesu chemicznego nie może być puste!");

        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CREATE_CHEMICAL_PROCESS_400_NAME")
            .WithMessage("Nazwa procesu chemicznego nie może być pusta!");
    }
}

public class CreateChemicalProcessCommandHandler : IRequestHandler<CreateChemicalProcessCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IChemicalProcessFactory _factory;

    public CreateChemicalProcessCommandHandler(IApplicationDbContext context, IChemicalProcessFactory factory)
    {
        _context = context;
        _factory = factory;
    }

    public async Task Handle(CreateChemicalProcessCommand request, CancellationToken cancellationToken)
    {
        (string? code, string? name) = request;

        ChemicalProcess? chemicalProcess = _factory.Create(Ulid.NewUlid(), code, name);

        await _context.ChemicalProcesses.AddAsync(chemicalProcess, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
