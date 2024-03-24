using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands;

public record CreateAssortment(string Id, char Position, ushort DrawingLength, ushort Addition,
    ushort TechnologicalAddition, char Stage, string Comment, ushort D15I, ushort D15Ii, ushort D1I, ushort D1Ii,
    ushort PrefabricationQuantity, ushort PrefabricationLength, double PrefabricationWeight,
    ushort AssemblyQuantity, ushort AssemblyLength, double AssemblyWeight) : ICommand;