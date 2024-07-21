using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands;

public record CreateShip(Ulid Id, string Code, string Orderer) : ICommand;