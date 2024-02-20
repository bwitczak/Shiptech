using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands;

public record CreateChemicalProcess(string Id, string ChemicalProcessName) : ICommand;