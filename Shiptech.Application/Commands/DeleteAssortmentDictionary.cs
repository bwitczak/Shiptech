using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands;

public record DeleteAssortmentDictionary(Guid Id) : ICommand;