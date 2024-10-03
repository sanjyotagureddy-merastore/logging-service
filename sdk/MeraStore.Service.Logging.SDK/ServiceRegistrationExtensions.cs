using MeraStore.Service.Logging.SDK.Interfaces;

using Microsoft.Extensions.DependencyInjection;

namespace MeraStore.Service.Logging.SDK;

public static class ServiceRegistrationExtensions
{
  public static IServiceCollection AddLoggingApiServices(this IServiceCollection services)
  {
    services.AddHttpClient();
    services.AddScoped<ILoggingApiClient, LoggingApiClient>();
    return services;
  }
}