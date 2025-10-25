using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Refit;
using Stokz.Polygon.Configuration;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stokz.Polygon.Rest;
using Stokz.Polygon.Serialisation;
using Stokz.Polygon.Services;

namespace Stokz.Polygon;

/// <summary>
/// Extension methods for registering Polygon.io services with dependency injection.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds Polygon.io services to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configure">Configuration action for Polygon.io options.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddPolygon(
        this IServiceCollection services,
        Action<PolygonOptions> configure)
    {
        services.AddOptions<PolygonOptions>().Configure(configure);
        services.AddSingleton<IValidateOptions<PolygonOptions>, PolygonOptionsValidator>();

        var settings = new RefitSettings
        {
            ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                Converters =
                {
                    new DateOnlyConverter(),
                    new DateTimeOffsetConverter()
                }
            })
        };

        services.AddRefitClient<ITickersClient>(settings).ConfigureHttpClient(ConfigureClient);

        services.TryAddScoped<TickersService>();

        return services;
    }

    private static void ConfigureClient(IServiceProvider sp, HttpClient client)
    {
        var options = sp.GetRequiredService<IOptions<PolygonOptions>>().Value;

        client.BaseAddress = options.BaseUrl;
        client.Timeout = TimeSpan.FromSeconds(options.TimeoutSeconds);
    }
}