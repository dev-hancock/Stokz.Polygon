using System.Text.Json.Serialization;
using Stokz.Polygon.Serialisation;

namespace Stokz.Polygon.Models.Stocks;

/// <summary>
/// Represents detailed information about a ticker.
/// </summary>
public sealed class TickerDetails
{
    /// <summary>
    /// Gets or sets the ticker symbol.
    /// </summary>
    [JsonPropertyName("ticker")]
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the company name.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the market type.
    /// </summary>
    [JsonPropertyName("market")]
    public string? Market { get; set; }

    /// <summary>
    /// Gets or sets the locale.
    /// </summary>
    [JsonPropertyName("locale")]
    public string? Locale { get; set; }

    /// <summary>
    /// Gets or sets the primary exchange.
    /// </summary>
    [JsonPropertyName("primary_exchange")]
    public string? PrimaryExchange { get; set; }

    /// <summary>
    /// Gets or sets the ticker type.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// Gets or sets whether the ticker is active.
    /// </summary>
    [JsonPropertyName("active")]
    public bool? Active { get; set; }

    /// <summary>
    /// Gets or sets the currency name.
    /// </summary>
    [JsonPropertyName("currency_name")]
    public string? CurrencyName { get; set; }

    /// <summary>
    /// Gets or sets the company description.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the company's homepage URL.
    /// </summary>
    [JsonPropertyName("homepage_url")]
    public string? HomepageUrl { get; set; }

    /// <summary>
    /// Gets or sets the total number of employees.
    /// </summary>
    [JsonPropertyName("total_employees")]
    public long? TotalEmployees { get; set; }

    /// <summary>
    /// Gets or sets the list filing date.
    /// </summary>
    [JsonPropertyName("list_date")]
    [JsonConverter(typeof(DateOnlyConverter))]
    public DateOnly? ListDate { get; set; }

    /// <summary>
    /// Gets or sets the company branding information.
    /// </summary>
    [JsonPropertyName("branding")]
    public TickerBranding? Branding { get; set; }

    /// <summary>
    /// Gets or sets the market capitalization.
    /// </summary>
    [JsonPropertyName("market_cap")]
    public decimal? MarketCap { get; set; }

    /// <summary>
    /// Gets or sets the weighted shares outstanding.
    /// </summary>
    [JsonPropertyName("weighted_shares_outstanding")]
    public long? WeightedSharesOutstanding { get; set; }

    /// <summary>
    /// Gets or sets the share class shares outstanding.
    /// </summary>
    [JsonPropertyName("share_class_shares_outstanding")]
    public long? ShareClassSharesOutstanding { get; set; }

    /// <summary>
    /// Gets or sets the company address.
    /// </summary>
    [JsonPropertyName("address")]
    public TickerAddress? Address { get; set; }

    /// <summary>
    /// Gets or sets the phone number.
    /// </summary>
    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Gets or sets the SIC (Standard Industrial Classification) code.
    /// </summary>
    [JsonPropertyName("sic_code")]
    public string? SicCode { get; set; }

    /// <summary>
    /// Gets or sets the SIC description.
    /// </summary>
    [JsonPropertyName("sic_description")]
    public string? SicDescription { get; set; }

    /// <summary>
    /// Gets or sets the ticker root (for derivatives).
    /// </summary>
    [JsonPropertyName("ticker_root")]
    public string? TickerRoot { get; set; }
}