using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands;

public record UpdateChemicalProcess(Guid Id, string ChemicalProcessCode, string ChemicalProcessName) : ICommand;