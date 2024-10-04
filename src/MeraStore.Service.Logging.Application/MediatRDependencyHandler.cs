using Microsoft.Extensions.DependencyInjection;

namespace MeraStore.Service.Logging.Application;

public static class MediatRDependencyHandler
{
  public static IServiceCollection RegisterRequestHandlers(
    this IServiceCollection services)
  {
    return services
      .AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(MediatRDependencyHandler).Assembly));
  }
}