using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands;

public record UpdateAssortmentDictionary(Guid Id, string Number, string Name, string Distinguishing, string Unit, double Amount, double Weight, string? Material, string? Kind, double? Length, string RO, string? Comment) : ICommand;