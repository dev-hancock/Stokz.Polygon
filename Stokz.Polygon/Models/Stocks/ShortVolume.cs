using System.Text.Json.Serialization;

namespace Stokz.Polygon.Models.Stocks;

/// <summary>
/// Represents short volume data for a ticker.
/// </summary>
public sealed class ShortVolume
{
    /// <summary>
    /// Gets or sets the ticker symbol.
    /// </summary>
    [JsonPropertyName("ticker")]
    public string? Ticker { get; set; }

    /// <summary>
    /// Gets or sets the date of the volume data (YYYY-MM-DD).
    /// </summary>
    [JsonPropertyName("date")]
    public DateOnly? Date { get; set; }

    /// <summary>
    /// Gets or sets the total trading volume.
    /// </summary>
    [JsonPropertyName("total_volume")]
    public long? TotalVolume { get; set; }

    /// <summary>
    /// Gets or sets the total short volume.
    /// </summary>
    [JsonPropertyName("short_volume")]
    public long? Volume { get; set; }

    /// <summary>
    /// Gets or sets the short volume ratio (percentage).
    /// </summary>
    [JsonPropertyName("short_volume_ratio")]
    public decimal? VolumeRatio { get; set; }

    /// <summary>
    /// Gets or sets the non-exempt short volume.
    /// </summary>
    [JsonPropertyName("non_exempt_volume")]
    public long? NonExemptVolume { get; set; }

    /// <summary>
    /// Gets or sets the exempt short volume.
    /// </summary>
    [JsonPropertyName("exempt_volume")]
    public long? ExemptVolume { get; set; }

    /// <summary>
    /// Gets or sets the NYSE short volume.
    /// </summary>
    [JsonPropertyName("nyse_short_volume")]
    public long? NyseVolume { get; set; }

    /// <summary>
    /// Gets or sets the NYSE exempt short volume.
    /// </summary>
    [JsonPropertyName("nyse_short_volume_exempt")]
    public long? NyseVolumeExempt { get; set; }

    /// <summary>
    /// Gets or sets the NASDAQ Carteret short volume.
    /// </summary>
    [JsonPropertyName("nasdaq_carteret_short_volume")]
    public long? NasdaqCarteretVolume { get; set; }

    /// <summary>
    /// Gets or sets the NASDAQ Carteret exempt short volume.
    /// </summary>
    [JsonPropertyName("nasdaq_carteret_short_volume_exempt")]
    public long? NasdaqCarteretVolumeExempt { get; set; }

    /// <summary>
    /// Gets or sets the NASDAQ Chicago short volume.
    /// </summary>
    [JsonPropertyName("nasdaq_chicago_short_volume")]
    public long? NasdaqChicagoVolume { get; set; }

    /// <summary>
    /// Gets or sets the NASDAQ Chicago exempt short volume.
    /// </summary>
    [JsonPropertyName("nasdaq_chicago_short_volume_exempt")]
    public long? NasdaqChicagoVolumeExempt { get; set; }

    /// <summary>
    /// Gets or sets the ADF short volume.
    /// </summary>
    [JsonPropertyName("adf_short_volume")]
    public long? AdfVolume { get; set; }

    /// <summary>
    /// Gets or sets the ADF exempt short volume.
    /// </summary>
    [JsonPropertyName("adf_short_volume_exempt")]
    public long? AdfVolumeExempt { get; set; }
}
