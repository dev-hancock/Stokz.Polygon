using System.Text.Json.Serialization;

namespace Stokz.Polygon.Models;

/// <summary>
/// Represents a generic API response wrapper returned by Polygon.io endpoints.
/// </summary>
/// <typeparam name="T">The type of the <see cref="Value"/> payload.</typeparam>
public class Result<T>
{
    /// <summary>
    /// Gets or sets the unique request identifier returned by the API.
    /// </summary>
    [JsonPropertyName("request_id")]
    public required string RequestId { get; set; }

    /// <summary>
    /// Gets or sets the response payload value for the request.
    /// </summary>
    [JsonPropertyName("results")]
    public required T Value { get; set; }

    /// <summary>
    /// Gets or sets the number of items in <see cref="Value"/> when applicable.
    /// </summary>
    [JsonPropertyName("count")]
    public int? Count { get; set; }

    /// <summary>
    /// Gets or sets the status returned by the API (e.g., <c>OK</c>, <c>ERROR</c>).
    /// </summary>
    [JsonPropertyName("status")]
    public required string Status { get; set; }

    /// <summary>
    /// Gets or sets the next page URL, if pagination is available.
    /// </summary>
    [JsonPropertyName("next_url")]
    public string? NextUrl { get; set; }

    /// <summary>
    /// Gets or sets an error or informational message when provided by the API.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    /// <summary>
    /// Gets the pagination cursor extracted from <see cref="NextUrl"/>, when available.
    /// </summary>
    [JsonIgnore]
    public string? Cursor => NextUrl?.Split("cursor=")?.LastOrDefault();

    /// <summary>
    /// Gets a value indicating whether the response status indicates success.
    /// </summary>
    [JsonIgnore]
    public bool IsSuccess => Status is "OK" or "success";
}