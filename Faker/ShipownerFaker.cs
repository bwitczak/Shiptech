using Bogus;
using Shiptech.Domain.Entities;

namespace Faker;

public sealed class ShipownerFaker : Faker<Shipowner>
{
    public ShipownerFaker()
    {
        RuleFor(x => x.Id, Ulid.NewUlid);
        RuleFor(x => x.Orderer, f => f.Random.ArrayElement([
            "Oceanic Ventures", "Seawind Logistics", "Blue Horizon Shipping", "Maritime Fleet",
            "Anchorline Marine", "Tidewave Shipping", "Nautilus Armada", "Deepwater Carriers", "Harborstar Shipping",
            "Wavecrest Lines"
        ]));
    }
}
