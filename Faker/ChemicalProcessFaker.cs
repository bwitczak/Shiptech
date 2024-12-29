using Bogus;
using Shiptech.Domain.Entities;

namespace Faker;

public sealed class ChemicalProcessFaker : Faker<ChemicalProcess>
{
    public ChemicalProcessFaker()
    {
        RuleFor(x => x.Id, Ulid.NewUlid);
        RuleFor(x => x.Code, f => f.Random.Int(1000, 9999).ToString());
        RuleFor(x => x.Name,
            f => f.Random.ArrayElement([
                "cynkowanie", "cynkowanie wewnątrz", "fosforowanie", "fosforowanie i olejowanie", "gumowanie",
                "malowanie", "malowanie farbą chlorową", "malowanie na zewn. farbą epoksydową", "malowanie wewn. 2",
                "malowanie wewn. 4", "M1-P", "NM1-0"
            ]));
    }
}
