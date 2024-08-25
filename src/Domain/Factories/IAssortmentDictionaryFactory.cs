using Shiptech.Domain.Entities;

namespace Shiptech.Domain.Factories;

public interface IAssortmentDictionaryFactory
{
    AssortmentDictionary Create(Ulid id, string number, string name, string distinguishing, string unit, double? amount, 
        double? weight, string? material, string? kind, ushort? dn1, ushort? dn2, ushort? length, string ro, string? comment);
}
