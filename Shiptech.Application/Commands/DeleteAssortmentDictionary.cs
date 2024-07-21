using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands;

public record DeleteAssortmentDictionary(Ulid Id) : ICommand;