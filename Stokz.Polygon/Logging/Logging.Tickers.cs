using Microsoft.Extensions.Logging;

namespace Stokz.Polygon.Logging;

public static partial class LoggingExtensions
{
    [LoggerMessage(LogLevel.Debug, "")]
    public static partial void Exmaple(this ILogger logger);
}