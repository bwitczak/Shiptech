using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands;

public record DeleteShip(string Id) : ICommand;