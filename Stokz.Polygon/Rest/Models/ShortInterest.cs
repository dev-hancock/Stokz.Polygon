using System.Text.Json.Serialization;

namespace Stokz.Polygon.Rest.Models;

/// <summary>
///     Represents short interest data for a ticker.
/// </summary>
public sealed class ShortInterest
{
    /// <summary>
    ///     Gets or sets the ticker symbol.
    /// </summary>
    [JsonPropertyName("ticker")]
    public string? Ticker { get; set; }

    /// <summary>
    ///     Gets or sets the Central Index Key (CIK).
    /// </summary>
    [JsonPropertyName("cik")]
    public string? Cik { get; set; }

    /// <summary>
    ///     Gets or sets the settlement date (YYYY-MM-DD).
    /// </summary>
    [JsonPropertyName("settlement_date")]
    public DateOnly? SettlementDate { get; set; }

    /// <summary>
    ///     Gets or sets the short interest quantity (number of shares).
    /// </summary>
    [JsonPropertyName("short_interest")]
    public long? Quantity { get; set; }

    /// <summary>
    ///     Gets or sets the change in short interest from the previous period.
    /// </summary>
    [JsonPropertyName("short_interest_change")]
    public long? Change { get; set; }

    /// <summary>
    ///     Gets or sets the percent change in short interest.
    /// </summary>
    [JsonPropertyName("short_interest_change_percent")]
    public decimal? ChangePercent { get; set; }

    /// <summary>
    ///     Gets or sets the average daily volume.
    /// </summary>
    [JsonPropertyName("average_daily_volume")]
    public long? AverageDailyVolume { get; set; }

    /// <summary>
    ///     Gets or sets the days to cover ratio.
    /// </summary>
    [JsonPropertyName("days_to_cover")]
    public decimal? DaysToCover { get; set; }

    /// <summary>
    ///     Gets or sets the shares outstanding.
    /// </summary>
    [JsonPropertyName("shares_outstanding")]
    public long? SharesOutstanding { get; set; }

    /// <summary>
    ///     Gets or sets the short interest as a percentage of shares outstanding.
    /// </summary>
    [JsonPropertyName("short_interest_percent_of_shares_outstanding")]
    public decimal? PercentOfSharesOutstanding { get; set; }

    /// <summary>
    ///     Gets or sets the float shares.
    /// </summary>
    [JsonPropertyName("float_shares")]
    public long? FloatShares { get; set; }

    /// <summary>
    ///     Gets or sets the short interest as a percentage of float.
    /// </summary>
    [JsonPropertyName("short_interest_percent_of_float")]
    public decimal? PercentOfFloat { get; set; }
}