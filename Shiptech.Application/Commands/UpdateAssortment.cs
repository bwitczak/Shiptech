using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands;

public record UpdateAssortment(string Id, string Position, int DrawingLength, int Addition,
    int TechnologicalAddition, string Stage, int D15I, int D15Ii, int D1I, int D1Ii,
    int PrefabricationQuantity, int PrefabricationLength, double PrefabricationWeight,
    int AssemblyQuantity, int AssemblyLength, double AssemblyWeight) : ICommand;