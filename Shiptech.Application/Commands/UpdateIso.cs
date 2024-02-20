using Shiptech.Domain.Consts;
using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands;

public record UpdateIso(string Id, string IsoRevision, string System, string Class, AtestEnum Atest, string KzmNumber,
    string KzmDate) : ICommand;