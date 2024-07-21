using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands;

public record UpdateShip(Ulid Id, string Code, string Orderer) : ICommand;