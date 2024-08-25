using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Common.Interfaces.Database;
using Shiptech.Application.Common.Interfaces.Services;

namespace Shiptech.Application.Ships.Commands.DeleteShip;

public record DeleteShipCommand(Ulid Id) : IRequest
{
}

public class DeleteShipCommandValidator : AbstractValidator<DeleteShipCommand>
{
    public DeleteShipCommandValidator(IShipService service)
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("DELETE_SHIP_400_ID")
            .WithMessage("Identyfikator statku nie może być pusty!")
            .MustAsync(async (x, _) => await service.ExistsById(x))
            .WithErrorCode("DELETE_SHIP_404_ID")
            .WithMessage(x =>$"{x.Id} nie istnieje w bazie!");
    }
}

public class DeleteShipCommandHandler : IRequestHandler<DeleteShipCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteShipCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteShipCommand request, CancellationToken cancellationToken)
    {
        var ship = await _context.Ships.AsNoTracking()
            .SingleAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

        _context.Ships.Remove(ship);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
