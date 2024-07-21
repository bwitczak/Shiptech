using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands;

public record CreateChemicalProcess(Ulid Id, string ChemicalProcessCode, string ChemicalProcessName) : ICommand;