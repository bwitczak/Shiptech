using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Common.Interfaces.Database;
using Shiptech.Application.Common.Interfaces.Services;

namespace Shiptech.Application.Isos.Commands.DeleteIso;

public record DeleteIsoCommand(Ulid Id) : IRequest
{
}

public class DeleteIsoCommandValidator : AbstractValidator<DeleteIsoCommand>
{
    public DeleteIsoCommandValidator(IIsoService service)
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("DELETE_ISO_400_ID")
            .WithMessage("Identyfikator ISO nie może być pusty!")
            .MustAsync(async (x, _) => await service.ExistsById(x))
            .WithMessage(x => $"{x.Id} nie istnieje w bazie!")
            .WithErrorCode("DELETE_ISO_404_ID");
    }
}

public class DeleteIsoCommandHandler : IRequestHandler<DeleteIsoCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteIsoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteIsoCommand request, CancellationToken cancellationToken)
    {
        var iso = await _context.Isos.AsNoTracking()
            .SingleAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

        _context.Isos.Remove(iso);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
