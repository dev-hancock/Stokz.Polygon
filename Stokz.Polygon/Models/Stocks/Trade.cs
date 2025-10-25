using System.Text.Json.Serialization;

namespace Stokz.Polygon.Models.Stocks;

/// <summary>
/// Represents a trade execution.
/// </summary>
public sealed class Trade
{
    /// <summary>
    /// Gets or sets the ticker symbol.
    /// </summary>
    [JsonPropertyName("T")]
    public string? Symbol { get; set; }

    /// <summary>
    /// Gets or sets the trade timestamp in nanoseconds since epoch.
    /// </summary>
    [JsonPropertyName("t")]
    public long TimestampNanos { get; set; }

    /// <summary>
    /// Gets or sets the SIP (Securities Information Processor) timestamp in nanoseconds.
    /// </summary>
    [JsonPropertyName("y")]
    public long? SipTimestampNanos { get; set; }

    /// <summary>
    /// Gets or sets the participant/exchange timestamp in nanoseconds.
    /// </summary>
    [JsonPropertyName("f")]
    public long? ParticipantTimestampNanos { get; set; }

    /// <summary>
    /// Gets or sets the sequence number.
    /// </summary>
    [JsonPropertyName("q")]
    public long? SequenceNumber { get; set; }

    /// <summary>
    /// Gets or sets the trade ID.
    /// </summary>
    [JsonPropertyName("i")]
    public string? TradeId { get; set; }

    /// <summary>
    /// Gets or sets the exchange ID where the trade was executed.
    /// </summary>
    [JsonPropertyName("x")]
    public int? ExchangeId { get; set; }

    /// <summary>
    /// Gets or sets the trade size (shares).
    /// </summary>
    [JsonPropertyName("s")]
    public decimal Size { get; set; }

    /// <summary>
    /// Gets or sets the trade price.
    /// </summary>
    [JsonPropertyName("p")]
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the trade conditions.
    /// </summary>
    [JsonPropertyName("c")]
    public List<int>? Conditions { get; set; }

    /// <summary>
    /// Gets or sets the tape where the trade was executed (1, 2, 3).
    /// </summary>
    [JsonPropertyName("z")]
    public int? Tape { get; set; }

    /// <summary>
    /// Gets or sets the TRF (Trade Reporting Facility) ID.
    /// </summary>
    [JsonPropertyName("r")]
    public int? TrfId { get; set; }

    /// <summary>
    /// Gets or sets the TRF timestamp in nanoseconds.
    /// </summary>
    [JsonPropertyName("trft")]
    public long? TrfTimestampNanos { get; set; }

    /// <summary>
    /// Gets the timestamp as a DateTime.
    /// </summary>
    [JsonIgnore]
    public DateTime DateTime => DateTimeOffset.FromUnixTimeMilliseconds(TimestampNanos / 1_000_000).DateTime;

    /// <summary>
    /// Gets the timestamp as a DateTimeOffset.
    /// </summary>
    [JsonIgnore]
    public DateTimeOffset DateTimeOffset => DateTimeOffset.FromUnixTimeMilliseconds(TimestampNanos / 1_000_000);
}
