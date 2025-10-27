using System.ComponentModel.DataAnnotations;

namespace Stokz.Polygon.Configuration;

/// <summary>
///     Configuration options for the Polygon.io SDK.
/// </summary>
public sealed class PolygonOptions
{
    /// <summary>
    ///     Gets or sets the base URI used for HTTP requests to the Polygon.io API.
    /// </summary>
    public Uri HttpBaseUrl { get; set; } = new("https://api.polygon.io");

    /// <summary>
    ///     Gets or sets the API key for authenticating with Polygon.io.
    /// </summary>
    public string ApiKey { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the request timeout in seconds.
    /// </summary>
    public int TimeoutSeconds { get; set; } = 30;

    /// <summary>
    ///     Gets or sets the maximum number of requests allowed within the rate limit window.
    /// </summary>
    public int RateLimitCount { get; set; } = 100;

    /// <summary>
    ///     Gets or sets the time interval, in seconds, to wait before retrying after a rate limit is encountered.
    /// </summary>
    public int RateLimitTime { get; set; } = 1;

    /// <summary>
    ///     Gets or sets the maximum number of retry attempts.
    /// </summary>
    public int MaxRetryAttempts { get; set; } = 3;

    /// <summary>
    ///     Validates the configuration options.
    /// </summary>
    /// <exception cref="ValidationException">Thrown when configuration is invalid.</exception>
    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(ApiKey))
        {
            throw new ValidationException("ApiKey must be configured.");
        }

        if (HttpBaseUrl is null)
        {
            throw new ValidationException("HttpBaseUrl must be configured.");
        }

        if (RateLimitCount <= 0)
        {
            throw new ValidationException("RateLimitCount must be greater than 0.");
        }

        if (RateLimitTime <= 0)
        {
            throw new ValidationException("RateLimitTime must be greater than 0.");
        }

        if (TimeoutSeconds <= 0)
        {
            throw new ValidationException("TimeoutSeconds must be greater than 0.");
        }

        if (MaxRetryAttempts < 0)
        {
            throw new ValidationException("MaxRetryAttempts must be non-negative.");
        }
    }
}