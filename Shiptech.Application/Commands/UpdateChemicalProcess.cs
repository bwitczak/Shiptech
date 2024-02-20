using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands;

public record UpdateChemicalProcess(string Id, string ChemicalProcessName) : ICommand;