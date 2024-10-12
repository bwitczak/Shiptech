using FluentValidation;
using MediatR;
using Shiptech.Application.Common.Interfaces.Database;
using Shiptech.Application.Common.Interfaces.Services;
using Shiptech.Domain.Entities;
using Shiptech.Domain.Factories;

namespace Shiptech.Application.Shipowners.Commands.CreateShip;

public record CreateShipownerCommand(string Orderer) : IRequest
{
}

public class CreateShipownerCommandValidator : AbstractValidator<CreateShipownerCommand>
{
    public CreateShipownerCommandValidator(IShipownerService service)
    {
        RuleFor(x => x.Orderer)
            .NotNull()
            .NotEmpty()
            .WithMessage("Nazwa zamawiającego nie może być pusta!")
            .WithErrorCode("CREATE_SHIPOWNER_400_ORDERER")
            .MustAsync(async (x, _) => !await service.ExistsByOrderer(x))
            .WithMessage(x => $"{x.Orderer} już istnieje w bazie!")
            .WithErrorCode("CREATE_SHIPOWNER_409_ORDERER");
    }
}

public class CreateShipownerCommandHandler : IRequestHandler<CreateShipownerCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IShipownerFactory _factory;

    public CreateShipownerCommandHandler(IApplicationDbContext context, IShipownerFactory factory)
    {
        _context = context;
        _factory = factory;
    }

    public async Task Handle(CreateShipownerCommand request, CancellationToken cancellationToken)
    {
        Shipowner shipowner = _factory.Create(Ulid.NewUlid(), request.Orderer);

        await _context.Shipowners.AddAsync(shipowner, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
