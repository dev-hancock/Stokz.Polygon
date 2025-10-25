using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;
using Stokz.Polygon.Configuration;

namespace Stokz.Polygon;

/// <summary>
/// Validator for Polygon.io options.
/// </summary>
internal sealed class PolygonOptionsValidator : IValidateOptions<PolygonOptions>
{
    /// <inheritdoc/>
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