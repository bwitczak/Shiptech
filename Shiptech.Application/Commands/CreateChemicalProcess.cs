using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands;

public record CreateChemicalProcess(Guid Id, string ChemicalProcessCode, string ChemicalProcessName) : ICommand;