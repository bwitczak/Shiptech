using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Shiptech.Infrastructure.Data.Converters;

public class UlidToStringConverter : ValueConverter<Ulid, string>
{
    private static readonly ConverterMappingHints defaultHints = new(26);

    public UlidToStringConverter() : this(null)
    {
    }

    public UlidToStringConverter(ConverterMappingHints? mappingHints = null)
        : base(
            x => x.ToString(),
            x => Ulid.Parse(x),
            defaultHints.With(mappingHints))
    {
    }
}
