using System.ComponentModel.DataAnnotations;

namespace Stokz.Polygon.Configuration;

/// <summary>
/// Configuration options for the Polygon.io SDK.
/// </summary>
public sealed class PolygonOptions
{
    /// <summary>
    /// Gets or sets the API key for authenticating with Polygon.io.
    /// </summary>
    public string ApiKey { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the base URL for REST API requests.
    /// </summary>
    public Uri BaseUrl { get; set; } = new("https://api.polygon.io");

    /// <summary>
    /// Gets or sets the WebSocket URL for real-time streaming.
    /// </summary>
    public Uri WebSocketUrl { get; set; } = new ("wss://socket.polygon.io");

    /// <summary>
    /// Gets or sets the request timeout in seconds.
    /// </summary>
    public int TimeoutSeconds { get; set; } = 30;

    /// <summary>
    /// Gets or sets whether to enable automatic retry on transient failures.
    /// </summary>
    public bool EnableRetry { get; set; } = true;

    /// <summary>
    /// Gets or sets the maximum number of retry attempts.
    /// </summary>
    public int MaxRetryAttempts { get; set; } = 3;

    /// <summary>
    /// Gets or sets the WebSocket reconnection timeout in seconds.
    /// </summary>
    public int WebSocketReconnectTimeoutSeconds { get; set; } = 30;

    /// <summary>
    /// Validates the configuration options.
    /// </summary>
    /// <exception cref="ValidationException">Thrown when configuration is invalid.</exception>
    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(ApiKey))
        {
            throw new ValidationException("ApiKey must be configured.");
        }

        if (BaseUrl is null)
        {
            throw new ValidationException("BaseUrl must be configured.");
        }

        if (WebSocketUrl is null)
        {
            throw new ValidationException("WebSocketUrl must be configured.");
        }

        if (TimeoutSeconds <= 0)
        {
            throw new ValidationException("TimeoutSeconds must be greater than 0.");
        }

        if (MaxRetryAttempts < 0)
        {
            throw new ValidationException("MaxRetryAttempts must be non-negative.");
        }

        if (WebSocketReconnectTimeoutSeconds <= 0)
        {
            throw new ValidationException("WebSocketReconnectTimeoutSeconds must be greater than 0.");
        }
    }
}
