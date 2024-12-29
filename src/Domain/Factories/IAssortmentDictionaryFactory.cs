using Shiptech.Domain.Entities;

namespace Shiptech.Domain.Factories;

public interface IAssortmentDictionaryFactory
{
    AssortmentDictionary Create(Ulid id, string number, string name, string? distinguishing, string unit,
        double? amount, double? weight, string? material, string? kind, string? dn1, string? dn2, ushort? length,
        string? ro, string? ns, string? comment);
}
