using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands;

public record CreateShip(Guid Id, string Code, string Orderer) : ICommand;