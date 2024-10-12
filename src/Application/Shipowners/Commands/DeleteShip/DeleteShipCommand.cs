using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Common.Interfaces.Database;
using Shiptech.Application.Common.Interfaces.Services;
using Shiptech.Domain.Entities;

namespace Shiptech.Application.Shipowners.Commands.DeleteShip;

public record DeleteShipownerCommand(Ulid Id) : IRequest
{
}

public class DeleteShipownerCommandValidator : AbstractValidator<DeleteShipownerCommand>
{
    public DeleteShipownerCommandValidator(IShipownerService service)
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("DELETE_SHIPOWNER_400_ID")
            .WithMessage("Identyfikator statku nie może być pusty!")
            .MustAsync(async (x, _) => await service.ExistsById(x))
            .WithErrorCode("DELETE_SHIPOWNER_404_ID")
            .WithMessage(x => $"{x.Id} nie istnieje w bazie!");
    }
}

public class DeleteShipownerCommandHandler : IRequestHandler<DeleteShipownerCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteShipownerCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteShipownerCommand request, CancellationToken cancellationToken)
    {
        Shipowner ship = await _context.Shipowners.AsNoTracking()
            .SingleAsync(x => x.Id == request.Id, cancellationToken);

        _context.Shipowners.Remove(ship);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
