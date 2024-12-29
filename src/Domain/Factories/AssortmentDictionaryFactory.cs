using Shiptech.Domain.Entities;

namespace Shiptech.Domain.Factories;

public class AssortmentDictionaryFactory : IAssortmentDictionaryFactory
{
    public AssortmentDictionary Create(Ulid id, string number, string name, string distinguishing, string unit,
        double? amount,
        double? weight, string? material, string? kind, ushort? dn1, ushort? dn2, ushort? length, string ro,
        string? comment)
    {
        return new AssortmentDictionary
        {
            Id = id,
            Number = number,
            Name = name,
            Distinguishing = distinguishing,
            Unit = unit,
            Amount = amount,
            Weight = weight,
            Material = material,
            Kind = kind,
            DN1 = dn1,
            DN2 = dn2,
            Length = length,
            RO = ro,
            Comment = comment
        };
    }
}
