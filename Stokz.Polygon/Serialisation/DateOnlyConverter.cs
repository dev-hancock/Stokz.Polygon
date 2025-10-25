using Stokz.Polygon.Utils;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Stokz.Polygon.Serialisation;

/// <summary>
/// JSON converter for nullable <see cref="DateOnly"/> values using the SDK's standard date format.
/// </summary>
public sealed class DateOnlyConverter : JsonConverter<DateOnly?>
{
    /// <inheritdoc />
    public override DateOnly? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
        }

        var value = reader.GetString();

        if (string.IsNullOrWhiteSpace(value))
        {
            return null;
        }

        if (DateOnly.TryParseExact(value, Constants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
        {
            return date;
        }

        return DateOnly.Parse(value, CultureInfo.InvariantCulture);
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, DateOnly? value, JsonSerializerOptions options)
    {
        if (value is not null)
        {
            writer.WriteStringValue(value.Value.ToString(Constants.DateFormat, CultureInfo.InvariantCulture));
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}