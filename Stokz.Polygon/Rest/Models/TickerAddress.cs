using System.Text.Json.Serialization;

namespace Stokz.Polygon.Rest.Models;

/// <summary>
///     Represents an address for a ticker.
/// </summary>
public sealed class TickerAddress
{
    /// <summary>
    ///     Gets or sets the street address line 1.
    /// </summary>
    [JsonPropertyName("address1")]
    public string? Address1 { get; set; }

    /// <summary>
    ///     Gets or sets the city.
    /// </summary>
    [JsonPropertyName("city")]
    public string? City { get; set; }

    /// <summary>
    ///     Gets or sets the state.
    /// </summary>
    [JsonPropertyName("state")]
    public string? State { get; set; }

    /// <summary>
    ///     Gets or sets the postal code.
    /// </summary>
    [JsonPropertyName("postal_code")]
    public string? PostalCode { get; set; }
}