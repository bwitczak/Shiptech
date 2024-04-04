using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands;

public record UpdateShip(Guid Id, string Code, string Orderer) : ICommand;