using FluentValidation;
using MediatR;
using Shiptech.Application.Common.Interfaces.Database;
using Shiptech.Application.Common.Interfaces.Services;
using Shiptech.Domain.Entities;
using Shiptech.Domain.Factories;

namespace Shiptech.Application.ChemicalProcesses.Commands.UpdateChemicalProcess;

public record UpdateChemicalProcessCommand(Ulid Id, string Code, string Name) : IRequest
{
}

public class UpdateChemicalProcessCommandValidator : AbstractValidator<UpdateChemicalProcessCommand>
{
    public UpdateChemicalProcessCommandValidator(IChemicalProcessService service)
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("UPDATE_CHEMICAL_PROCESS_400_ID")
            .WithMessage("Identyfikator procesu chemicznego nie może być pusty!")
            .MustAsync(async (x, _) => await service.ExistsById(x))
            .WithMessage(x => $"{x.Id} nie istnieje w bazie!")
            .WithErrorCode("UPDATE_CHEMICAL_PROCESS_404_ID");

        RuleFor(x => x.Code)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("UPDATE_CHEMICAL_PROCESS_400_CODE")
            .WithMessage("Kod procesu chemicznego nie może być pusty!");

        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("UPDATE_CHEMICAL_PROCESS_400_NAME")
            .WithMessage("Nazwa procesu chemicznego nie może być pusta!");
    }
}

public class UpdateChemicalProcessCommandHandler : IRequestHandler<UpdateChemicalProcessCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IChemicalProcessFactory _factory;

    public UpdateChemicalProcessCommandHandler(IApplicationDbContext context, IChemicalProcessFactory factory)
    {
        _context = context;
        _factory = factory;
    }

    public async Task Handle(UpdateChemicalProcessCommand request, CancellationToken cancellationToken)
    {
        (Ulid id, string? code, string? name) = request;

        ChemicalProcess? updated = _factory.Create(id, code, name);

        _context.ChemicalProcesses.Update(updated);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
