using Bogus;
using Shiptech.Domain.Entities;

namespace Faker;

public sealed class AssortmentFaker : Faker<Assortment>
{
    public AssortmentFaker(List<Iso> isos, List<AssortmentDictionary> assortmentDictionaries)
    {
        Iso? iso = new Bogus.Faker().Random.ListItem(isos);
        AssortmentDictionary assortmentDictionary = new Bogus.Faker().Random.ListItem(assortmentDictionaries);

        RuleFor(x => x.Id, Ulid.NewUlid);
        RuleFor(x => x.Position, f => f.Random.Char('A', 'Z'));
        RuleFor(x => x.PrefabricationQuantity, f => f.Random.UShort(0, 100));
        RuleFor(x => x.PrefabricationLength, f => f.Random.UShort(0, 10000));
        RuleFor(x => x.PrefabricationWeight, f => Math.Round(f.Random.Double(0, 200), 3));
        RuleFor(x => x.AssemblyQuantity, f => f.Random.UShort(0, 100));
        RuleFor(x => x.AssemblyLength, f => f.Random.UShort(0, 10000));
        RuleFor(x => x.AssemblyWeight, f => Math.Round(f.Random.Double(0, 200), 3));
        RuleFor(x => x.PG, f => f.Random.ArrayElement(['P', 'G']));
        RuleFor(x => x.ValveNumber, f => f.Random.Replace("**********").OrNull(f, 0.4f));
        RuleFor(x => x.CutAngle, f => f.Random.ArrayElement([
            "0° - 1°",
            "1° - 1°",
            "0° - 1,5°",
            "1,5° - 1,5°",
            "0° - 2°",
            "2° - 2°",
            "0° - 2,5°",
            "2,5° - 2,5°",
            "0° - 30°",
            "30° - 30°",
            "0° - 45°",
            "45° - 45°"
        ]).OrNull(f, 0.4f));
        RuleFor(x => x.Comment, f => f.Lorem.Sentence().OrNull(f, 0.2f));
        RuleFor(x => x.Iso, f => f.Random.ListItem(isos));
        RuleFor(x => x.AssortmentDictionary, f => f.Random.ListItem(assortmentDictionaries));
    }
}
