using Refit;

namespace Stokz.Polygon.Rest.Requests;

/// <summary>
/// Request parameters for the Polygon.io <c>/stocks/v1/short-interest</c> endpoint.
/// Use these filters to refine returned short interest data.
/// </summary>
public sealed class ShortInterestRequest
{
    /// <summary>
    /// Exact ticker symbol to filter by (e.g., <c>AAPL</c>).
    /// </summary>
    [AliasAs("ticker")]
    [Query]
    public string? Ticker { get; set; }

    /// <summary>
    /// Comma-separated list of ticker symbols to match any.
    /// </summary>
    [AliasAs("ticker.any_of")]
    [Query]
    public string? TickerAnyOf { get; set; }

    /// <summary>
    /// Filter for tickers greater than the specified value (exclusive).
    /// </summary>
    [AliasAs("ticker.gt")]
    [Query]
    public string? TickerGt { get; set; }

    /// <summary>
    /// Filter for tickers greater than or equal to the specified value (inclusive).
    /// </summary>
    [AliasAs("ticker.gte")]
    [Query]
    public string? TickerGte { get; set; }

    /// <summary>
    /// Filter for tickers less than the specified value (exclusive).
    /// </summary>
    [AliasAs("ticker.lt")]
    [Query]
    public string? TickerLt { get; set; }

    /// <summary>
    /// Filter for tickers less than or equal to the specified value (inclusive).
    /// </summary>
    [AliasAs("ticker.lte")]
    [Query]
    public string? TickerLte { get; set; }

    /// <summary>
    /// Filter by Central Index Key (CIK).
    /// </summary>
    [AliasAs("cik")]
    [Query]
    public string? Cik { get; set; }

    /// <summary>
    /// Comma-separated list of CIKs to match any.
    /// </summary>
    [AliasAs("cik.any_of")]
    [Query]
    public string? CikAnyOf { get; set; }

    /// <summary>
    /// Filter for CIK greater than the specified value (exclusive).
    /// </summary>
    [AliasAs("cik.gt")]
    [Query]
    public string? CikGt { get; set; }

    /// <summary>
    /// Filter for CIK greater than or equal to the specified value (inclusive).
    /// </summary>
    [AliasAs("cik.gte")]
    [Query]
    public string? CikGte { get; set; }

    /// <summary>
    /// Filter for CIK less than the specified value (exclusive).
    /// </summary>
    [AliasAs("cik.lt")]
    [Query]
    public string? CikLt { get; set; }

    /// <summary>
    /// Filter for CIK less than or equal to the specified value (inclusive).
    /// </summary>
    [AliasAs("cik.lte")]
    [Query]
    public string? CikLte { get; set; }

    /// <summary>
    /// Filter by settlement date.
    /// </summary>
    [AliasAs("settlement_date")]
    [Query]
    public DateOnly? SettlementDate { get; set; }

    /// <summary>
    /// Filter for settlement date greater than the specified date (exclusive).
    /// </summary>
    [AliasAs("settlement_date.gt")]
    [Query]
    public DateOnly? SettlementDateGt { get; set; }

    /// <summary>
    /// Filter for settlement date greater than or equal to the specified date (inclusive).
    /// </summary>
    [AliasAs("settlement_date.gte")]
    [Query]
    public DateOnly? SettlementDateGte { get; set; }

    /// <summary>
    /// Filter for settlement date less than the specified date (exclusive).
    /// </summary>
    [AliasAs("settlement_date.lt")]
    [Query]
    public DateOnly? SettlementDateLt { get; set; }

    /// <summary>
    /// Filter for settlement date less than or equal to the specified date (inclusive).
    /// </summary>
    [AliasAs("settlement_date.lte")]
    [Query]
    public DateOnly? SettlementDateLte { get; set; }

    /// <summary>
    /// Sort direction: <c>asc</c> or <c>desc</c>.
    /// </summary>
    [AliasAs("order")]
    [Query]
    public string? Order { get; set; }

    /// <summary>
    /// Maximum number of results to return per page.
    /// </summary>
    [AliasAs("limit")]
    [Query]
    public int? Limit { get; set; }

    /// <summary>
    /// Field to sort by.
    /// </summary>
    [AliasAs("sort")]
    [Query]
    public string? Sort { get; set; }
}