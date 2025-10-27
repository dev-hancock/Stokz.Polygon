using System.Text.Json;
using System.Text.Json.Serialization;

namespace Stokz.Polygon.Serialisation;

/// <summary>
///     JSON converter for nullable <see cref="DateTime" /> values represented as Unix epoch milliseconds.
/// </summary>
internal class DateTimeConverter : JsonConverter<DateTime?>
{
    /// <inheritdoc />
    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
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
    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        if (value is not null)
        {
            var utc = value.Value.Kind switch
            {
                DateTimeKind.Utc => value.Value,
                DateTimeKind.Local => value.Value.ToUniversalTime(),
                _ => DateTime.SpecifyKind(value.Value, DateTimeKind.Utc)
            };

            writer.WriteNumberValue(new DateTimeOffset(utc).ToUnixTimeMilliseconds());
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}