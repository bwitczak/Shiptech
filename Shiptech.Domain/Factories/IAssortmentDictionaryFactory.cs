using Shiptech.Domain.Entities;
using Shiptech.Domain.ValueObjects;

namespace Shiptech.Domain.Factories;

public interface IAssortmentDictionaryFactory
{
    AssortmentDictionary Create(Id id, AssortmentDictionaryNumber number, AssortmentDictionaryName name, Distinguishing distinguishing, Unit unit, AssortmentDictionaryAmount amount, AssortmentDictionaryWeight weight, AssortmentDictionaryMaterial material, AssortmentDictionaryKind kind, AssortmentDictionaryLength length, RO ro, Comment comment);
}