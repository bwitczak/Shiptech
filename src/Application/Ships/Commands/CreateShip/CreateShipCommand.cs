using FluentValidation;
using MediatR;
using Shiptech.Application.Common.Interfaces.Database;
using Shiptech.Application.Common.Interfaces.Services;
using Shiptech.Domain.Entities;
using Shiptech.Domain.Factories;

namespace Shiptech.Application.Ships.Commands.CreateShip;

public record CreateShipCommand(string Code, string Orderer) : IRequest
{
}

public class CreateShipCommandValidator : AbstractValidator<CreateShipCommand>
{
    public CreateShipCommandValidator(IShipService service)
    {
        RuleFor(x => x.Code)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("CREATE_SHIP_400_CODE")
            .WithMessage("Kod statku nie może być pusty!")
            .MustAsync(async (x, _) => !await service.ExistsByCode(x))
            .WithMessage(x => $"{x.Code} już istnieje w bazie!")
            .WithErrorCode("CREATE_SHIP_409_ID");
        
        RuleFor(x => x.Orderer)
            .NotNull()
            .NotEmpty()
            .WithMessage("Nazwa zamawiającego nie może być pusta!")
            .WithErrorCode("CREATE_SHIP_400_ORDERER")
            .MustAsync(async (x, _) => !await service.ExistsByOrderer(x))
            .WithMessage(x => $"{x.Orderer} już istnieje w bazie!")
            .WithErrorCode("CREATE_SHIP_409_ORDERER");
    }
}

public class CreateShipCommandHandler : IRequestHandler<CreateShipCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IShipFactory _factory;

    public CreateShipCommandHandler(IApplicationDbContext context, IShipFactory factory)
    {
        _context = context;
        _factory = factory;
    }

    public async Task Handle(CreateShipCommand request, CancellationToken cancellationToken)
    {
        var (code, orderer) = request;
        
        var ship = _factory.Create(Ulid.NewUlid(), code, orderer);
        
        await _context.Ships.AddAsync(ship, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
