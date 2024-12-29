using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Common.Interfaces.Database;
using Shiptech.Application.Common.Interfaces.Services;
using Shiptech.Domain.Entities;

namespace Shiptech.Application.Assortments.Commands.DeleteAssortment;

public record DeleteAssortmentCommand(Ulid Id) : IRequest
{
}

public class DeleteAssortmentCommandValidator : AbstractValidator<DeleteAssortmentCommand>
{
    public DeleteAssortmentCommandValidator(IAssortmentService service)
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("DELETE_ASSORTMENT_400_ID")
            .WithMessage("Identyfikator asortymentu nie może być pusty!")
            .MustAsync(async (x, _) => await service.ExistsById(x))
            .WithMessage(x => $"{x.Id} nie istnieje w bazie!")
            .WithErrorCode("ASSORTMENT_404_ID");
    }
}

public class DeleteAssortmentCommandHandler : IRequestHandler<DeleteAssortmentCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteAssortmentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteAssortmentCommand request, CancellationToken cancellationToken)
    {
        Assortment? assortment = await _context.Assortments.AsNoTracking()
            .SingleAsync(x => x.Id == request.Id, cancellationToken);

        _context.Assortments.Remove(assortment);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
