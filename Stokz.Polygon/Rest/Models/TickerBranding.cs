using System.Text.Json.Serialization;

namespace Stokz.Polygon.Rest.Models;

/// <summary>
///     Represents branding information for a ticker.
/// </summary>
public sealed class TickerBranding
{
    /// <summary>
    ///     Gets or sets the logo URL.
    /// </summary>
    [JsonPropertyName("logo_url")]
    public string? LogoUrl { get; set; }

    /// <summary>
    ///     Gets or sets the icon URL.
    /// </summary>
    [JsonPropertyName("icon_url")]
    public string? IconUrl { get; set; }
}