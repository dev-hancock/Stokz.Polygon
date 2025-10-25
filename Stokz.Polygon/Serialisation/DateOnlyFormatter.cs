using System.Globalization;
using System.Reflection;
using Refit;
using Stokz.Polygon.Utils;

namespace Stokz.Polygon.Serialisation;

/// <summary>
/// A Refit URL parameter formatter for <see cref="DateOnly"/> values using the SDK's date format.
/// </summary>
public class DateOnlyFormatter : IUrlParameterFormatter
{
    /// <summary>
    /// Formats a parameter value for inclusion in a URL.
    /// </summary>
    /// <param name="parameterValue">The parameter value.</param>
    /// <param name="attributeProvider">The attribute provider.</param>
    /// <param name="type">The parameter type.</param>
    /// <returns>The formatted string value, or <c>null</c> when no value is provided.</returns>
    public string? Format(object? parameterValue, ICustomAttributeProvider attributeProvider, Type type)
    {
        if (parameterValue is DateOnly date)
        {
            return date.ToString(Constants.DateFormat, CultureInfo.InvariantCulture);
        }

        return parameterValue?.ToString();
    }
}