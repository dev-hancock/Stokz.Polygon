using Refit;
using Stokz.Polygon.Models;
using Stokz.Polygon.Models.Stocks;
using Stokz.Polygon.Rest.Requests;

namespace Stokz.Polygon.Rest;

/// <summary>
/// Refit interface for Polygon.io Stocks Ticker endpoints.
/// </summary>
public interface ITickersClient
{
    /// <summary>
    /// Get a list of tickers.
    /// </summary>
    /// <param name="request">Filter by ticker symbol.</param>
    /// <param name="cursor">Cursor for pagination.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>A paginated list of tickers.</returns>
    [Get("/v3/reference/tickers")]
    Task<Result<Ticker[]>> GetTickersAsync(
        [Query] TickersRequest? request = null,
        [Query] string? cursor = null,
        CancellationToken ct = default);

    /// <summary>
    /// Get detailed information about a ticker.
    /// </summary>
    /// <param name="ticker">The ticker symbol.</param>
    /// <param name="date">Optional date for historical data (YYYY-MM-DD).</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>Ticker details.</returns>
    [Get("/v3/reference/tickers/{ticker}")]
    Task<Result<TickerDetails>> GetTickerDetailsAsync(
        string ticker,
        [Query] string? date = null,
        CancellationToken ct = default);

    /// <summary>
    /// Get short volume data for stocks.
    /// </summary>
    /// <param name="cursor">Cursor for pagination.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>A paginated list of short interest data.</returns>
    [Get("/stocks/v1/short-volume")]
    Task<Result<ShortVolume[]>> GetShortVolumeAsync(
        [Query] ShortVolumeRequest? request = null,
        [Query] string? cursor = null,
        CancellationToken ct = default);

    /// <summary>
    /// Get short interest data for stocks.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cursor">Cursor for pagination.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>A paginated list of short interest data.</returns>
    [Get("/stocks/v1/short-interest")]
    Task<Result<ShortInterest[]>> GetShortInterestAsync(
        [Query] ShortInterestRequest? request = null,
        [Query] string? cursor = null,
        CancellationToken ct = default);
}
