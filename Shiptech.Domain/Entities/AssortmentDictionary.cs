using Shiptech.Domain.ValueObjects;

namespace Shiptech.Domain.Entities;

public class AssortmentDictionary
{
    public Ulid Id { get; private set; }
    private AssortmentDictionaryNumber _number;
    private AssortmentDictionaryName _name;
    private Distinguishing _distinguishing;
    private Unit _unit;
    private AssortmentDictionaryAmount _amount;
    private AssortmentDictionaryWeight _weight;
    private AssortmentDictionaryMaterial _material;
    private AssortmentDictionaryKind _kind;
    private DN _dn1;
    private DN _dn2;
    private AssortmentDictionaryLength _length;
    private RO _ro;
    private Comment _comment;

    private AssortmentDictionary()
    {
    }

    internal AssortmentDictionary(Id id, AssortmentDictionaryNumber number, AssortmentDictionaryName name, Distinguishing distinguishing, Unit unit, AssortmentDictionaryAmount amount, AssortmentDictionaryWeight weight, AssortmentDictionaryMaterial material, AssortmentDictionaryKind kind, DN dn1, DN dn2, AssortmentDictionaryLength length, RO ro, Comment comment)
    {
        Id = id;
        _number = number;
        _name = name;
        _distinguishing = distinguishing;
        _unit = unit;
        _amount = amount;
        _weight = weight;
        _material = material;
        _kind = kind;
        _dn1 = dn1;
        _dn2 = dn2;
        _length = length;
        _ro = ro;
        _comment = comment;
    }

    // internal AssortmentDictionary(Id id, AssortmentDictionaryNumber number, AssortmentDictionaryName name, Distinguishing distinguishing, Unit unit, AssortmentDictionaryAmount amount, AssortmentDictionaryWeight weight, AssortmentDictionaryMaterial material, AssortmentDictionaryKind kind, DN dn1, DN dn2, AssortmentDictionaryLength length, RO ro, Comment comment)
    // {
    //     Id = id;
    //     _number = number;
    //     _name = name;
    //     _distinguishing = distinguishing;
    //     _unit = unit;
    //     _amount = amount;
    //     _weight = weight;
    //     _material = material;
    //     _kind = kind;
    //     _dn1 = _dn1;
    //     _dn2 = _dn2;
    //     _length = length;
    //     _ro = ro;
    //     _comment = comment;
    // }
}