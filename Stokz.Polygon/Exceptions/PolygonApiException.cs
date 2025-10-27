namespace Stokz.Polygon.Exceptions;

/// <summary>
///     Exception thrown when a Polygon.io API request fails.
/// </summary>
public class PolygonApiException : Exception
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PolygonApiException" /> class.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <param name="status">The API response status.</param>
    /// <param name="requestId">The request ID.</param>
    /// <param name="httpStatusCode">The HTTP status code.</param>
    /// <param name="innerException">The inner exception.</param>
    public PolygonApiException(
        string message,
        string status = "ERROR",
        string? requestId = null,
        int? httpStatusCode = null,
        Exception? innerException = null)
        : base(message, innerException)
    {
        Status = status;
        RequestId = requestId;
        HttpStatusCode = httpStatusCode;
    }

    /// <summary>
    ///     Gets the API response status.
    /// </summary>
    public string Status { get; }

    /// <summary>
    ///     Gets the API request ID for tracking purposes.
    /// </summary>
    public string? RequestId { get; }

    /// <summary>
    ///     Gets the HTTP status code if available.
    /// </summary>
    public int? HttpStatusCode { get; }

    /// <inheritdoc />
    public override string ToString()
    {
        var details = $"Status: {Status}";

        if (!string.IsNullOrWhiteSpace(RequestId))
        {
            details += $", RequestId: {RequestId}";
        }

        if (HttpStatusCode.HasValue)
        {
            details += $", HttpStatusCode: {HttpStatusCode}";
        }

        return $"{base.ToString()}\n{details}";
    }
}