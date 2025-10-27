using Refit;

namespace Stokz.Polygon.Rest.Requests;

/// <summary>
///     Request parameters for the Polygon.io <c>/v3/reference/tickers</c> endpoint.
///     Use these filters to refine the list of returned tickers.
/// </summary>
public sealed class TickersRequest
{
    /// <summary>
    ///     Exact ticker symbol to filter by (e.g., <c>AAPL</c>).
    /// </summary>
    [AliasAs("ticker")]
    [Query]
    public string? Ticker { get; set; }

    /// <summary>
    ///     Filter for tickers greater than the specified value (exclusive).
    /// </summary>
    [AliasAs("ticker.gt")]
    [Query]
    public string? TickerGt { get; set; }

    /// <summary>
    ///     Filter for tickers greater than or equal to the specified value (inclusive).
    /// </summary>
    [AliasAs("ticker.gte")]
    [Query]
    public string? TickerGte { get; set; }

    /// <summary>
    ///     Filter for tickers less than the specified value (exclusive).
    /// </summary>
    [AliasAs("ticker.lt")]
    [Query]
    public string? TickerLt { get; set; }

    /// <summary>
    ///     Filter for tickers less than or equal to the specified value (inclusive).
    /// </summary>
    [AliasAs("ticker.lte")]
    [Query]
    public string? TickerLte { get; set; }

    /// <summary>
    ///     Filter by asset type (e.g., <c>CS</c> for common stock).
    /// </summary>
    [AliasAs("type")]
    [Query]
    public string? Type { get; set; }

    /// <summary>
    ///     Filter by market (e.g., <c>stocks</c>, <c>crypto</c>, <c>fx</c>).
    /// </summary>
    [AliasAs("market")]
    [Query]
    public string? Market { get; set; }

    /// <summary>
    ///     Filter by primary exchange identifier.
    /// </summary>
    [AliasAs("exchange")]
    [Query]
    public string? Exchange { get; set; }

    /// <summary>
    ///     Filter by CUSIP identifier.
    /// </summary>
    [AliasAs("cusip")]
    [Query]
    public string? Cusip { get; set; }

    /// <summary>
    ///     Filter by SEC Central Index Key (CIK).
    /// </summary>
    [AliasAs("cik")]
    [Query]
    public string? Cik { get; set; }

    /// <summary>
    ///     Filter tickers that were active on the given date.
    /// </summary>
    [AliasAs("date")]
    [Query]
    public DateOnly? Date { get; set; }

    /// <summary>
    ///     Search by company name or ticker symbol.
    /// </summary>
    [AliasAs("search")]
    [Query]
    public string? Search { get; set; }

    /// <summary>
    ///     Filter by active state. When <c>true</c>, returns active tickers only.
    /// </summary>
    [AliasAs("active")]
    [Query]
    public bool? Active { get; set; }

    /// <summary>
    ///     Sort direction: <c>asc</c> or <c>desc</c>.
    /// </summary>
    [AliasAs("order")]
    [Query]
    public string? Order { get; set; }

    /// <summary>
    ///     Maximum number of results to return per page.
    /// </summary>
    [AliasAs("limit")]
    [Query]
    public int? Limit { get; set; }

    /// <summary>
    ///     Field to sort by.
    /// </summary>
    [AliasAs("sort")]
    [Query]
    public string? Sort { get; set; }
}