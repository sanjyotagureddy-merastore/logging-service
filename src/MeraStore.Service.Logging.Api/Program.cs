using HealthChecks.UI.Client;
using MeraStore.Service.Logging.Application;
using MeraStore.Service.Logging.Core.Interfaces;
using MeraStore.Service.Logging.Infrastructure;
using MeraStore.Service.Logging.Infrastructure.Repositories;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Consul;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterRequestHandlers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("LoggingDb")));

builder.Services.AddHealthChecks()
  .AddDbContextCheck<ApplicationDbContext>("sql", failureStatus: HealthStatus.Degraded, tags: ["database"]);

//name: "sql",
//failureStatus: HealthStatus.Unhealthy);

builder.Services.AddScoped<IRequestLogRepository, RequestLogRepository>();
builder.Services.AddScoped<IResponseLogRepository, ResponseLogRepository>();
builder.Services.AddServiceDiscovery(o => o.UseConsul());



var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseSwagger();
app.UseSwaggerUI(x =>
{
  x.SwaggerEndpoint("/swagger/v1/swagger.json", "LogStore API V1");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/health", new HealthCheckOptions()
{
  ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.Run();