using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Wrap;
using Refit;
using Stokz.Polygon.Configuration;
using Stokz.Polygon.Rest.Clients;
using Stokz.Polygon.Serialisation;
using Stokz.Polygon.Services;

namespace Stokz.Polygon;

/// <summary>
///     Extension methods for registering Polygon.io services with dependency injection.
/// </summary>
public static class ServiceCollectionExtensions
{
    private static readonly RefitSettings RefitSettings = CreateRefitSettings();

    /// <summary>
    ///     Creates the default Refit settings with System.Text.Json serialization.
    /// </summary>
    private static RefitSettings CreateRefitSettings()
    {
        return new RefitSettings
        {
            ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                Converters =
                {
                    new DateOnlyConverter(), new DateTimeOffsetConverter()
                }
            })
        };
    }

    /// <summary>
    ///     Adds Polygon.io services to the service collection.
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

        services.RegisterPolygonPolicies();

        services.AddClient<ITickersClient>();

        services.TryAddScoped<TickersService>();

        return services;
    }

    /// <summary>
    ///     Registers a typed Refit client with common HTTP configuration and policies.
    /// </summary>
    private static IServiceCollection AddClient<T>(this IServiceCollection services) where T : class
    {
        services.AddRefitClient<T>(RefitSettings)
            .ConfigureHttpClient(ConfigureClient)
            .AddPolicyHandler((sp, _) => sp.GetRequiredService<AsyncPolicyWrap<HttpResponseMessage>>());

        return services;
    }

    /// <summary>
    ///     Registers and composes the HTTP policies used by Polygon clients.
    /// </summary>
    private static IServiceCollection RegisterPolygonPolicies(this IServiceCollection services)
    {
        services.AddSingleton<AsyncPolicyWrap<HttpResponseMessage>>(sp =>
        {
            var options = sp.GetRequiredService<IOptions<PolygonOptions>>().Value;

            IAsyncPolicy<HttpResponseMessage>[] policies =
            [
                CreateRateLimitPolicy(options),
                CreateRetryPolicy(options)
            ];

            return Policy.WrapAsync(policies.ToArray());
        });

        return services;
    }

    /// <summary>
    ///     Creates a rate-limit policy enforcing the configured requests-per-window.
    /// </summary>
    private static AsyncPolicy<HttpResponseMessage> CreateRateLimitPolicy(PolygonOptions options)
    {
        return Policy.RateLimitAsync<HttpResponseMessage>(
            options.RateLimitCount,
            TimeSpan.FromSeconds(options.RateLimitTime),
            0);
    }

    /// <summary>
    ///     Creates a simple retry policy for HTTP 429 (Too Many Requests).
    /// </summary>
    private static AsyncPolicy<HttpResponseMessage> CreateRetryPolicy(PolygonOptions options)
    {
        return Policy<HttpResponseMessage>
            .HandleResult(r => r.StatusCode == HttpStatusCode.TooManyRequests)
            .WaitAndRetryAsync(
                options.MaxRetryAttempts,
                attempt => TimeSpan.FromMilliseconds(200 * attempt));
    }

    /// <summary>
    ///     Applies common HttpClient configuration for Polygon REST clients.
    /// </summary>
    private static void ConfigureClient(IServiceProvider sp, HttpClient client)
    {
        var options = sp.GetRequiredService<IOptions<PolygonOptions>>().Value;

        client.BaseAddress = options.HttpBaseUrl;
        client.Timeout = TimeSpan.FromSeconds(options.TimeoutSeconds);
    }
}