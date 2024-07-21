using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands;

public record CreateAssortmentDictionary(Ulid Id, string Number, string Name, string Distinguishing, string Unit, double? Amount, double? Weight, string? Material, string? Kind, ushort? DN1, ushort? DN2, ushort? Length, string RO, string? Comment) : ICommand;