using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands;

public record DeleteChemicalProcess(string Id) : ICommand;