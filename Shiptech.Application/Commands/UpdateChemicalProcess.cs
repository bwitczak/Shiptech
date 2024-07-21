using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands;

public record UpdateChemicalProcess(Ulid Id, string ChemicalProcessCode, string ChemicalProcessName) : ICommand;