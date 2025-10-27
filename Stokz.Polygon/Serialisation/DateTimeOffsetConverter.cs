using System.Text.Json;
using System.Text.Json.Serialization;

namespace Stokz.Polygon.Serialisation;

/// <summary>
///     JSON converter for nullable <see cref="DateTimeOffset" /> values represented as Unix epoch milliseconds.
/// </summary>
internal class DateTimeOffsetConverter : JsonConverter<DateTimeOffset?>
{
    /// <inheritdoc />
    public override DateTimeOffset? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
        }

        if (reader.TokenType == JsonTokenType.Number && reader.TryGetInt64(out var value))
        {
            return DateTimeOffset.FromUnixTimeMilliseconds(value).UtcDateTime;
        }

        return null;
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, DateTimeOffset? value, JsonSerializerOptions options)
    {
        if (value is not null)
        {
            writer.WriteNumberValue(value.Value.ToUnixTimeMilliseconds());
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}