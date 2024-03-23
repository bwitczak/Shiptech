using Shiptech.Domain.ValueObjects;

namespace Shiptech.Domain.Entities;

public class AssortmentDictionary
{
    public AssortmentDictionaryId Id { get; private set; }
    private AssortmentDictionaryName _name;
    private Distinguishing _distinguishing;
    private Unit _unit;
    private AssortmentDictionaryAmount _amount;
    private AssortmentDictionaryWeight _weight;
    private AssortmentDictionaryMaterial _material;
    private AssortmentDictionaryKind _kind;
    private AssortmentDictionaryLength _length;
    private RO _ro;
    private Comment _comment;

    private AssortmentDictionary()
    {
    }

    internal AssortmentDictionary(AssortmentDictionaryId id, AssortmentDictionaryName name, Distinguishing distinguishing, Unit unit, AssortmentDictionaryAmount amount, AssortmentDictionaryWeight weight, AssortmentDictionaryMaterial material, AssortmentDictionaryKind kind, AssortmentDictionaryLength length, RO ro, Comment comment)
    {
        Id = id;
        _name = name;
        _distinguishing = distinguishing;
        _unit = unit;
        _amount = amount;
        _weight = weight;
        _material = material;
        _kind = kind;
        _length = length;
        _ro = ro;
        _comment = comment;
    }
}