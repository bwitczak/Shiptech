using Shiptech.Domain.Consts;
using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands;

public record UpdateIso(string Id, char IsoRevision, string System, string Class, string Atest, string KzmNumber,
    DateTime KzmDate) : ICommand;