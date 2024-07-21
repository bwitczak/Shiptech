using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shiptech.Domain.ValueObjects;

namespace Shiptech.Infrastructure.EF.Converters;

public class UlidToStringConverter : ValueConverter<Ulid, string>
{
    private static readonly ConverterMappingHints defaultHints = new ConverterMappingHints(size: 26);

    public UlidToStringConverter() : this(null)
    {
    }

    public UlidToStringConverter(ConverterMappingHints mappingHints = null)
        : base(
            convertToProviderExpression: x => x.ToString(),
            convertFromProviderExpression: x => Ulid.Parse(x),
            mappingHints: defaultHints.With(mappingHints))
    {
    }
}