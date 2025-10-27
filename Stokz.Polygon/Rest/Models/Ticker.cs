using System.Text.Json.Serialization;
using Stokz.Polygon.Serialisation;

namespace Stokz.Polygon.Rest.Models;

/// <summary>
///     Represents a ticker/stock symbol.
/// </summary>
public sealed class Ticker
{
    /// <summary>
    ///     Gets or sets the ticker symbol.
    /// </summary>
    [JsonPropertyName("ticker")]
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the company name.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the market type.
    /// </summary>
    [JsonPropertyName("market")]
    public string? Market { get; set; }

    /// <summary>
    ///     Gets or sets the locale (e.g., "us", "global").
    /// </summary>
    [JsonPropertyName("locale")]
    public string? Locale { get; set; }

    /// <summary>
    ///     Gets or sets the primary exchange.
    /// </summary>
    [JsonPropertyName("primary_exchange")]
    public string? PrimaryExchange { get; set; }

    /// <summary>
    ///     Gets or sets the ticker type (e.g., "CS" for Common Stock).
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    ///     Gets or sets whether the ticker is active.
    /// </summary>
    [JsonPropertyName("active")]
    public bool? Active { get; set; }

    /// <summary>
    ///     Gets or sets the currency in which the ticker is traded.
    /// </summary>
    [JsonPropertyName("currency_name")]
    public string? CurrencyName { get; set; }

    /// <summary>
    ///     Gets or sets the ticker's CIK (Central Index Key).
    /// </summary>
    [JsonPropertyName("cik")]
    public string? Cik { get; set; }

    /// <summary>
    ///     Gets or sets the composite FIGI.
    /// </summary>
    [JsonPropertyName("composite_figi")]
    public string? CompositeFigi { get; set; }

    /// <summary>
    ///     Gets or sets the share class FIGI.
    /// </summary>
    [JsonPropertyName("share_class_figi")]
    public string? ShareClassFigi { get; set; }

    /// <summary>
    ///     Gets or sets the date the ticker was last updated.
    /// </summary>
    [JsonPropertyName("last_updated_utc")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset? LastUpdated { get; set; }

    /// <summary>
    ///     Gets or sets the delisted date, if applicable.
    /// </summary>
    [JsonPropertyName("delisted_utc")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset? Delisted { get; set; }
}