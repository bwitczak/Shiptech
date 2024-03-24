using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands;

public record CreateAssortment(string Id, char Position, short DrawingLength, short Addition,
    short TechnologicalAddition, char Stage, string Comment, short D15I, short D15Ii, short D1I, short D1Ii,
    short PrefabricationQuantity, short PrefabricationLength, double PrefabricationWeight,
    short AssemblyQuantity, short AssemblyLength, double AssemblyWeight) : ICommand;