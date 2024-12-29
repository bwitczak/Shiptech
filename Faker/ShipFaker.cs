using Bogus;
using Shiptech.Domain.Entities;

namespace Faker;

public sealed class ShipFaker : Faker<Ship>
{
    public ShipFaker(IEnumerable<Shipowner> shipowners)
    {
        RuleFor(x => x.Id, Ulid.NewUlid);
        RuleFor(x => x.Code, f => f.Random.Replace("?##"));
        RuleFor(x => x.Shipowner, f => f.Random.ListItem(shipowners.ToList()));
    }
}
