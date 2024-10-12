using FluentValidation;
using MediatR;
using Shiptech.Application.Common.Interfaces.Database;
using Shiptech.Application.Common.Interfaces.Services;
using Shiptech.Domain.Entities;
using Shiptech.Domain.Factories;

namespace Shiptech.Application.Shipowners.Commands.UpdateShip;

public record UpdateShipownerCommand(Ulid Id, string Orderer) : IRequest
{
}

public class UpdateShipownerCommandValidator : AbstractValidator<UpdateShipownerCommand>
{
    public UpdateShipownerCommandValidator(IShipownerService service)
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("UPDATE_SHIPOWNER_400_ID")
            .WithMessage("Identyfikator statku nie może być pusty!")
            .MustAsync(async (x, _) => await service.ExistsById(x))
            .WithMessage(x => $"{x.Id} nie istnieje w bazie!")
            .WithErrorCode("UPDATE_SHIPOWNER_404_ID");

        RuleFor(x => x.Orderer)
            .NotNull()
            .NotEmpty()
            .WithMessage("Nazwa zamawiającego nie może być pusta!")
            .WithErrorCode("UPDATE_SHIPOWNER_400_ORDERER")
            .MustAsync(async (x, _) => !await service.ExistsByOrderer(x))
            .WithMessage(x => $"{x.Orderer} już istnieje w bazie!")
            .WithErrorCode("UPDATE_SHIPOWNER_409_ORDERER");
    }
}

public class UpdateShipownerCommandHandler : IRequestHandler<UpdateShipownerCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IShipownerFactory _factory;

    public UpdateShipownerCommandHandler(IApplicationDbContext context, IShipownerFactory factory)
    {
        _context = context;
        _factory = factory;
    }

    public async Task Handle(UpdateShipownerCommand request, CancellationToken cancellationToken)
    {
        (Ulid id, string orderer) = request;

        Shipowner updated = _factory.Create(id, orderer);

        _context.Shipowners.Update(updated);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
