namespace Stokz.Polygon.Models;

/// <summary>
/// Extension methods for working with <see cref="Result{T}"/> responses.
/// </summary>
public static class ResultExtensions
{
    /// <summary>
    /// Awaits the task, validates the API response, and throws a <see cref="PolygonApiException"/>
    /// if the response status indicates failure.
    /// </summary>
    /// <typeparam name="T">The wrapped result type.</typeparam>
    /// <param name="task">The task returning a <see cref="Result{T}"/>.</param>
    /// <returns>The validated <see cref="Result{T}"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the provided task is null.</exception>
    /// <exception cref="PolygonApiException">Thrown when the API response indicates failure.</exception>
    public static async Task<Result<T>> GetResult<T>(this Task<Result<T>> task)
    {
        if (task is null)
        {
            throw new ArgumentNullException(nameof(task), "Result task cannot be null.");
        }

        var result = await task.ConfigureAwait(false);

        if (!result.IsSuccess)
        {
            throw new PolygonApiException(
                result.Message ?? "An error occurred while processing the API request",
                result.Status,
                result.RequestId);
        }

        return result;
    }

    /// <summary>
    /// Awaits and unwraps the value from a <see cref="Result{T}"/> response, validating success first.
    /// </summary>
    /// <typeparam name="T">The wrapped result type.</typeparam>
    /// <param name="task">The task returning a <see cref="Result{T}"/>.</param>
    /// <returns>The unwrapped value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the provided task is null.</exception>
    /// <exception cref="PolygonApiException">Thrown when the API response indicates failure.</exception>
    public static async Task<T> Unwrap<T>(this Task<Result<T>> task)
    {
        if (task is null)
        {
            throw new ArgumentNullException(nameof(task), "Result task cannot be null.");
        }

        return (await task.GetResult().ConfigureAwait(false)).Value;
    }
}