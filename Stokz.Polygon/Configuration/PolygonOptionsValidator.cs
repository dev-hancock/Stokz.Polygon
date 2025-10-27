using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace Stokz.Polygon.Configuration;

/// <summary>
///     Validator for Polygon.io options.
/// </summary>
internal sealed class PolygonOptionsValidator : IValidateOptions<PolygonOptions>
{
    /// <inheritdoc />
    public ValidateOptionsResult Validate(string? name, PolygonOptions options)
    {
        try
        {
            options.Validate();

            return ValidateOptionsResult.Success;
        }
        catch (ValidationException ex)
        {
            return ValidateOptionsResult.Fail(ex.Message);
        }
    }
}