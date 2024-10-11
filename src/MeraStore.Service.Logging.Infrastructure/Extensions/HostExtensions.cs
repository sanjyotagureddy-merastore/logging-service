using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MeraStore.Service.Logging.Infrastructure.Extensions;

public static class HostExtensions
{
  public static IHost MigrateDatabase<TContext>(this IHost host) where TContext : DbContext
  {
    using var scope = host.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<TContext>();
    var pendingMigrations = dbContext.Database.GetPendingMigrations();
    if (pendingMigrations.Any())
    {
      Console.WriteLine("Applying pending migrations...");
      dbContext.Database.Migrate();
      Console.WriteLine("Migrations applied successfully.");
    }
    else
    {
      Console.WriteLine("No pending migrations.");
    }

    return host;
  }
}