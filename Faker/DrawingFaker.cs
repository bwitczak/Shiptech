using Bogus;
using Shiptech.Domain.Entities;

namespace Faker;

public sealed class DrawingFaker : Faker<Drawing>
{
    public DrawingFaker(List<Ship> ships)
    {
        // List<string> shipCodes = ships.Select(s => s.Code).ToList();
        RuleFor(x => x.Ship, f => f.Random.ListItem(ships));
        RuleFor(x => x.Id, Ulid.NewUlid);
        RuleFor(x => x.Number, (f, drawing) => f.Random.Replace($"{drawing.Ship?.Code}_###-###"));
        RuleFor(x => x.Name, f => f.Random.ArrayElement([
            "Tank armature",
            "Ballast system",
            "Bilge system",
            "Fuel oil system",
            "Drain external system",
            "Vent pipe system",
            "Electric cable pipe",
            "FW cargo system",
            "Fuel oil cargo",
            "CTV FO cargo system",
            "Souding system",
            "Heeling System",
            "Roll Damping System",
            "Cross flooding system",
            "Hydraulic low press system",
            "HVAC natural pipes system",
            "Chilled water system",
            "HVAC supply pipes system",
            "HVAC exhaust pipes system",
            "HVAC return pipes",
            "Central heating system",
            "Hydrophore system",
            "Sewage discharge system",
            "Grey water discharge system",
            "Heat recovery system",
            "Fuel oil overflow system",
            "Lubrication oil system",
            "Waste/Sludge oil system",
            "SW cooling no 1",
            "FW cooling water system No 1",
            "FW cooling water system No 2",
            "FW cooling water system No 3",
            "Exhaust system",
            "FW production system",
            "Fire system",
            "Foam system",
            "Watermist system"
        ]));
        RuleFor(x => x.Revision, f => f.LetterWithOptionalDigit(0.5));
        RuleFor(x => x.Lot, f => f.Random.Int(0, 100).ToString());
        RuleFor(x => x.Block, f => f.Random.Int(0, 100).ToString());
        RuleFor(x => x.Section,
            f => Enumerable.Range(1, f.Random.Int(1, 5)).Select(_ => f.Random.Int(1000, 9999).ToString()).ToList());
        RuleFor(x => x.Stage, f => f.Random.ArrayElement(["ODP", "ODS", "ODI"]).OrNull(f, .4f));
        RuleFor(x => x.CreatedBy, f => f.Person.FullName);
        RuleFor(x => x.Created, f => f.Date.Past());
    }
}
