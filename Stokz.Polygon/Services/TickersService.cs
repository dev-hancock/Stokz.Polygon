using System.Runtime.CompilerServices;
using Stokz.Polygon.Extensions;
using Stokz.Polygon.Rest.Clients;
using Stokz.Polygon.Rest.Models;
using Stokz.Polygon.Rest.Requests;

namespace Stokz.Polygon.Services;

/// <summary>
///     Service for accessing ticker/stock data from Polygon.io.
/// </summary>
public sealed class TickersService
{
    private readonly ITickersClient _client;

    /// <summary>
    ///     Initializes a new instance of the <see cref="TickersService" /> class.
    /// </summary>
    /// <param name="client">The tickers Refit client.</param>
    public TickersService(ITickersClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    /// <summary>
    ///     Gets a list of tickers with automatic pagination.
    /// </summary>
    /// <param name="request">Optional request filter.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>An async enumerable of tickers.</returns>
    public async IAsyncEnumerable<Ticker> GetTickersAsync(
        TickersRequest? request = null,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        string? cursor = null;

        while (!ct.IsCancellationRequested)
        {
            var result = await _client
                .GetTickersAsync(
                    request,
                    cursor,
                    ct)
                .GetResult()
                .ConfigureAwait(false);

            if (result is { Count: > 0 })
            {
                foreach (var item in result.Value)
                {
                    ct.ThrowIfCancellationRequested();

                    yield return item;
                }
            }

            cursor = result.Cursor;

            if (string.IsNullOrWhiteSpace(cursor))
            {
                yield break;
            }
        }
    }

    /// <summary>
    ///     Gets detailed information about a ticker.
    /// </summary>
    /// <param name="ticker">The ticker symbol.</param>
    /// <param name="date">Optional date for historical data (YYYY-MM-DD).</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>The ticker details.</returns>
    public async Task<TickerDetails> GetTickerDetailsAsync(
        string ticker,
        string? date = null,
        CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(ticker))
        {
            throw new ArgumentException("Ticker symbol is required.", nameof(ticker));
        }

        return await _client
            .GetTickerDetailsAsync(
                ticker,
                date,
                ct)
            .Unwrap()
            .ConfigureAwait(false);
    }

    /// <summary>
    ///     Gets short volume data with automatic pagination.
    /// </summary>
    /// <param name="request">The request filter.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>An async enumerable of short volume items.</returns>
    public async IAsyncEnumerable<ShortVolume> GetShortVolumeAsync(
        ShortVolumeRequest request,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        if (request is null)
        {
            throw new ArgumentException("Request is required.", nameof(request));
        }

        string? cursor = null;

        while (!ct.IsCancellationRequested)
        {
            var result = await _client
                .GetShortVolumeAsync(
                    request,
                    cursor,
                    ct)
                .GetResult()
                .ConfigureAwait(false);

            if (result is { Count: > 0 })
            {
                foreach (var item in result.Value)
                {
                    ct.ThrowIfCancellationRequested();

                    yield return item;
                }
            }

            cursor = result.Cursor;

            if (string.IsNullOrWhiteSpace(cursor))
            {
                yield break;
            }
        }
    }

    /// <summary>
    ///     Gets short interest data with automatic pagination.
    /// </summary>
    /// <param name="request">The request filter.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>An async enumerable of short interest items.</returns>
    public async IAsyncEnumerable<ShortInterest> GetShortInterestAsync(
        ShortInterestRequest request,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        if (request is null)
        {
            throw new ArgumentException("Request is required.", nameof(request));
        }

        string? cursor = null;

        while (!ct.IsCancellationRequested)
        {
            var result = await _client
                .GetShortInterestAsync(
                    request,
                    cursor,
                    ct)
                .GetResult()
                .ConfigureAwait(false);

            if (result is { Count: > 0 })
            {
                foreach (var item in result.Value)
                {
                    ct.ThrowIfCancellationRequested();

                    yield return item;
                }
            }

            cursor = result.Cursor;

            if (string.IsNullOrWhiteSpace(cursor))
            {
                yield break;
            }
        }
    }
}