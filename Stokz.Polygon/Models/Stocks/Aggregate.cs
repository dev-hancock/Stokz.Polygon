using System.Text.Json.Serialization;
using Stokz.Polygon.Serialisation;

namespace Stokz.Polygon.Models.Stocks;

/// <summary>
/// Represents an aggregate bar (OHLCV data) for a ticker.
/// </summary>
public sealed class Aggregate
{
    /// <summary>
    /// Gets or sets the ticker symbol.
    /// </summary>
    [JsonPropertyName("T")]
    public string? Symbol { get; set; }

    /// <summary>
    /// Gets or sets the aggregate window's start timestamp in milliseconds since epoch.
    /// </summary>
    [JsonPropertyName("t")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset Timestamp { get; set; }

    /// <summary>
    /// Gets or sets the number of items aggregated.
    /// </summary>
    [JsonPropertyName("n")]
    public long? NumberOfItems { get; set; }

    /// <summary>
    /// Gets or sets the trading volume.
    /// </summary>
    [JsonPropertyName("v")]
    public decimal Volume { get; set; }

    /// <summary>
    /// Gets or sets the volume-weighted average price.
    /// </summary>
    [JsonPropertyName("vw")]
    public decimal? VolumeWeightedAveragePrice { get; set; }

    /// <summary>
    /// Gets or sets the open price.
    /// </summary>
    [JsonPropertyName("o")]
    public decimal Open { get; set; }

    /// <summary>
    /// Gets or sets the close price.
    /// </summary>
    [JsonPropertyName("c")]
    public decimal Close { get; set; }

    /// <summary>
    /// Gets or sets the high price.
    /// </summary>
    [JsonPropertyName("h")]
    public decimal High { get; set; }

    /// <summary>
    /// Gets or sets the low price.
    /// </summary>
    [JsonPropertyName("l")]
    public decimal Low { get; set; }

    /// <summary>
    /// Gets or sets whether this aggregate represents official trading day values.
    /// </summary>
    [JsonPropertyName("otc")]
    public bool? IsOtc { get; set; }
}
