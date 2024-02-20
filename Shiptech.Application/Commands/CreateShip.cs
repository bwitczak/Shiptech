using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands;

public record CreateShip(string Id, string Orderer) : ICommand;