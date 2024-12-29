using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Common.Interfaces.Database;
using Shiptech.Application.Common.Interfaces.Services;
using Shiptech.Domain.Entities;

namespace Shiptech.Application.Drawings.Commands.DeleteDrawing;

public record DeleteDrawingCommand(Ulid Id) : IRequest
{
}

public class DeleteDrawingCommandValidator : AbstractValidator<DeleteDrawingCommand>
{
    public DeleteDrawingCommandValidator(IDrawingService service)
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("DELETE_DRAWING_400_ID")
            .WithMessage("Identyfikator rysunku nie może być pusty!")
            .MustAsync(async (x, _) => await service.ExistsById(x))
            .WithMessage(x => $"{x.Id} nie istnieje w bazie!")
            .WithErrorCode("DELETE_DRAWING_404_ID");
    }
}

public class DeleteDrawingCommandHandler : IRequestHandler<DeleteDrawingCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteDrawingCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteDrawingCommand request, CancellationToken cancellationToken)
    {
        Drawing? drawing = await _context.Drawings.AsNoTracking()
            .SingleAsync(x => x.Id == request.Id, cancellationToken);

        _context.Drawings.Remove(drawing);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
