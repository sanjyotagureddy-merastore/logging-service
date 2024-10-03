using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;

namespace MeraStore.Service.Logging.SDK;

public class ClientBuilder
{
  private readonly IHttpClientBuilder _httpClientBuilder;
  private string _baseUrl;
  private IAsyncPolicy<HttpResponseMessage> _retryPolicy;

  public ClientBuilder()
  {
    // Initialize a new service collection
    var serviceCollection = new ServiceCollection();
    _httpClientBuilder = serviceCollection.AddHttpClient<LoggingApiClient>();
    // Set default retry policy
    _retryPolicy = GetDefaultRetryPolicy();
  }
  public ClientBuilder WithUrl(string baseUrl)
  {
    _baseUrl = baseUrl.TrimEnd('/'); // Remove trailing slash
    _httpClientBuilder.ConfigureHttpClient(client =>
    {
      client.BaseAddress = new Uri(_baseUrl);
    });
    return this;
  }

  public ClientBuilder WithRetryPolicy(IAsyncPolicy<HttpResponseMessage> retryPolicy)
  {
    _retryPolicy = retryPolicy;
    return this;
  }

  public ClientBuilder UseDefaultRetryPolicy()
  {
    _retryPolicy = GetDefaultRetryPolicy();
    return this;
  }

  public LoggingApiClient Build()
  {
    // Apply the retry policy
    _httpClientBuilder.AddPolicyHandler(_retryPolicy);
    return _httpClientBuilder.Services.BuildServiceProvider().GetRequiredService<LoggingApiClient>();
  }

  private IAsyncPolicy<HttpResponseMessage> GetDefaultRetryPolicy()
  {
    return HttpPolicyExtensions
      .HandleTransientHttpError() // Handle transient HTTP errors
      .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound) // Optionally handle specific status codes
      .WaitAndRetryAsync(3, // Retry 3 times
        retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)) // Exponential backoff
      );
  }
}