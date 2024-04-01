using Shiptech.Domain.Entities;
using Shiptech.Domain.ValueObjects;

namespace Shiptech.Domain.Factories
{
    public sealed class AssortmentDictionaryFactory : IAssortmentDictionaryFactory
    {
        public AssortmentDictionary Create(Id id, AssortmentDictionaryNumber number, AssortmentDictionaryName name, Distinguishing distinguishing, Unit unit, AssortmentDictionaryAmount amount, AssortmentDictionaryWeight weight, AssortmentDictionaryMaterial material, AssortmentDictionaryKind kind, AssortmentDictionaryLength length, RO ro, Comment comment)
            => new(id, number, name, distinguishing, unit, amount, weight, material, kind, length, ro, comment);
    }
}