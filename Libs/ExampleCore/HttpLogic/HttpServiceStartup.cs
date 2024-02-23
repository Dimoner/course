using CoreLib.HttpServiceV2.Services.Interfaces;
using ExampleCore.HttpLogic.Services;
using ExampleCore.HttpLogic.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace ExampleCore.HttpLogic;

/// <summary>
/// Регистрация в DI сервисов для HTTP-соединений
/// </summary>
public static class HttpServiceStartup
{
    /// <summary>
    /// Добавление сервиса для осуществления запросов по HTTP
    /// </summary>
    public static IServiceCollection AddHttpRequestService(this IServiceCollection services)
    {
        services
            .AddHttpContextAccessor()
            .AddHttpClient()
            .AddTransient<IHttpConnectionService, HttpConnectionService>();
        
        services.TryAddTransient<IHttpRequestService, HttpRequestService>();
        
        return services;
    }
}