using Bogus;
using Shiptech.Domain.Entities;

namespace Faker;

public sealed class IsoFaker : Faker<Iso>
{
    public IsoFaker(List<Drawing> drawings, List<ChemicalProcess> chemicalProcesses)
    {
        RuleFor(x => x.Id, Ulid.NewUlid);
        RuleFor(x => x.Drawing, f => f.Random.ListItem(drawings));
        RuleFor(x => x.Number, (f, iso) => f.Random.Replace($"{iso.Drawing?.Number.Split("_")[1]}-###"));
        RuleFor(x => x.Nameplate, (f, iso) =>
            f.Random.Replace($"{iso.Drawing?.Ship?.Code}-{iso.Number}"));
        RuleFor(x => x.Revision, f => f.LetterWithOptionalDigit(0.5));
        RuleFor(x => x.System, (f, iso) => iso.Drawing?.Number.Split("_")[1]);
        RuleFor(x => x.Class, f => f.Random.Replace("******"));
        RuleFor(x => x.Atest, f => f.Random.ArrayElement([
            "tak",
            "/C",
            "C/C",
            "/W",
            "W/C",
            "W/W",
            "MC",
            "MD",
            "MTR"
        ]).OrNull(f, 0.4f));
        RuleFor(x => x.KzmNumber, f => f.Random.Replace("******").OrNull(f, 0.85f));
        RuleFor(x => x.KzmDate, (f, iso) => iso.KzmNumber is not null ? f.Date.PastDateOnly() : null);
        RuleFor(x => x.ChemicalProcess, f => f.Random.ListItem(chemicalProcesses));
    }
}
