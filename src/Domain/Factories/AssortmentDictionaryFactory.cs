using Shiptech.Domain.Entities;

namespace Shiptech.Domain.Factories;

public class AssortmentDictionaryFactory : IAssortmentDictionaryFactory
{
    public AssortmentDictionary Create(Ulid id, string number, string name, string? distinguishing, string unit,
        double? amount, double? weight, string? material, string? kind, string? dn1, string? dn2, ushort? length,
        string? ra, string? ns, string? comment)
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
            RA = ra,
            NS = ns,
            Comment = comment
        };
    }
}
