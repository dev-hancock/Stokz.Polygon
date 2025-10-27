using Refit;

namespace Stokz.Polygon.Rest.Requests;

/// <summary>
///     Request parameters for the Polygon.io <c>/stocks/v1/short-volume</c> endpoint.
///     Use these filters to query short volume data.
/// </summary>
public class ShortVolumeRequest
{
    /// <summary>
    ///     Exact ticker symbol to filter by (e.g., <c>AAPL</c>).
    /// </summary>
    [AliasAs("ticker")]
    [Query]
    public string? Ticker { get; set; }

    /// <summary>
    ///     Comma-separated list of ticker symbols to match any.
    /// </summary>
    [AliasAs("ticker.any_of")]
    [Query]
    public string? TickerAnyOf { get; set; }

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
    ///     Filter by date.
    /// </summary>
    [AliasAs("date")]
    [Query]
    public DateOnly? Date { get; set; }

    /// <summary>
    ///     Comma-separated list of dates to match any.
    /// </summary>
    [AliasAs("date.any_of")]
    [Query]
    public DateOnly? DateAnyOf { get; set; }

    /// <summary>
    ///     Filter for date greater than the specified value (exclusive).
    /// </summary>
    [AliasAs("date.gt")]
    [Query]
    public DateOnly? DateGt { get; set; }

    /// <summary>
    ///     Filter for date greater than or equal to the specified value (inclusive).
    /// </summary>
    [AliasAs("date.gte")]
    [Query]
    public DateOnly? DateGte { get; set; }

    /// <summary>
    ///     Filter for date less than the specified value (exclusive).
    /// </summary>
    [AliasAs("date.lt")]
    [Query]
    public DateOnly? DateLt { get; set; }

    /// <summary>
    ///     Filter for date less than or equal to the specified value (inclusive).
    /// </summary>
    [AliasAs("date.lte")]
    [Query]
    public DateOnly? DateLte { get; set; }

    /// <summary>
    ///     Filter by short volume ratio.
    /// </summary>
    [AliasAs("short_volume_ratio")]
    [Query]
    public double? VolumeRatio { get; set; }

    /// <summary>
    ///     Comma-separated list of short volume ratio values to match any.
    /// </summary>
    [AliasAs("short_volume_ratio.any_of")]
    [Query]
    public string? VolumeRatioAnyOf { get; set; }

    /// <summary>
    ///     Filter for short volume ratio greater than the specified value (exclusive).
    /// </summary>
    [AliasAs("short_volume_ratio.gt")]
    [Query]
    public double? VolumeRatioGt { get; set; }

    /// <summary>
    ///     Filter for short volume ratio greater than or equal to the specified value (inclusive).
    /// </summary>
    [AliasAs("short_volume_ratio.gte")]
    [Query]
    public double? VolumeRatioGte { get; set; }

    /// <summary>
    ///     Filter for short volume ratio less than the specified value (exclusive).
    /// </summary>
    [AliasAs("short_volume_ratio.lt")]
    [Query]
    public double? VolumeRatioLt { get; set; }

    /// <summary>
    ///     Filter for short volume ratio less than or equal to the specified value (inclusive).
    /// </summary>
    [AliasAs("short_volume_ratio.lte")]
    [Query]
    public double? VolumeRatioLte { get; set; }

    /// <summary>
    ///     Filter by total trading volume.
    /// </summary>
    [AliasAs("total_volume")]
    [Query]
    public int? TotalVolume { get; set; }

    /// <summary>
    ///     Comma-separated list of total trading volume values to match any.
    /// </summary>
    [AliasAs("total_volume.any_of")]
    [Query]
    public string? TotalVolumeAnyOf { get; set; }

    /// <summary>
    ///     Filter for total trading volume greater than the specified value (exclusive).
    /// </summary>
    [AliasAs("total_volume.gt")]
    [Query]
    public int? TotalVolumeGt { get; set; }

    /// <summary>
    ///     Filter for total trading volume greater than or equal to the specified value (inclusive).
    /// </summary>
    [AliasAs("total_volume.gte")]
    [Query]
    public int? TotalVolumeGte { get; set; }

    /// <summary>
    ///     Filter for total trading volume less than the specified value (exclusive).
    /// </summary>
    [AliasAs("total_volume.lt")]
    [Query]
    public int? TotalVolumeLt { get; set; }

    /// <summary>
    ///     Filter for total trading volume less than or equal to the specified value (inclusive).
    /// </summary>
    [AliasAs("total_volume.lte")]
    [Query]
    public int? TotalVolumeLte { get; set; }

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