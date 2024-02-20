using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands;

public record DeleteIso(string Id) : ICommand;