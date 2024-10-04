using System.Net.Http.Json;
using System.Text.Json;
using MeraStore.Service.Logging.SDK.Interfaces;
using MeraStore.Service.Logging.SDK.Models;

namespace MeraStore.Service.Logging.SDK;

internal record ResponseDto(string id);

public class LoggingApiClient(HttpClient httpClient) : ILoggingApiClient
{
  public async Task<string> CreateRequestLogAsync(BaseDto command)
  {
    var response = await httpClient.PostAsJsonAsync(ApiEndpoints.RequestLogs.Create, command); // Use PostAsJsonAsync for automatic serialization

    response.EnsureSuccessStatusCode();

    var result = await response.Content.ReadAsStringAsync();

    // Ensure the response contains a valid Guid
    return JsonSerializer.Deserialize<ResponseDto>(result, new JsonSerializerOptions
    {
      PropertyNameCaseInsensitive = true // Ensure case-insensitive matching
    }).id ?? throw new InvalidOperationException("Deserialization returned null.");
  }

  public async Task<Request> GetRequestLogAsync(Guid id)
  {
    var response = await httpClient.GetAsync(string.Format(ApiEndpoints.RequestLogs.Get, id));

    response.EnsureSuccessStatusCode();

    var result = await response.Content.ReadAsStringAsync();

    // Deserialize the JSON string to Request
    return JsonSerializer.Deserialize<Request>(result, new JsonSerializerOptions
    {
      PropertyNameCaseInsensitive = true // Ensure case-insensitive matching
    }) ?? throw new InvalidOperationException("Deserialization returned null.");
  }

  public async Task<string> CreateResponseLogAsync(BaseDto command)
  {
    var response = await httpClient.PostAsJsonAsync(ApiEndpoints.ResponseLogs.Create, command); // Use PostAsJsonAsync for automatic serialization

    response.EnsureSuccessStatusCode();

    var result = await response.Content.ReadAsStringAsync();

   return JsonSerializer.Deserialize<ResponseDto>(result, new JsonSerializerOptions
    {
      PropertyNameCaseInsensitive = true // Ensure case-insensitive matching
    }).id ?? throw new InvalidOperationException("Deserialization returned null.");
  }

  public async Task<Response> GetResponseLogAsync(Guid id)
  {
    var response = await httpClient.GetAsync(string.Format(ApiEndpoints.ResponseLogs.Get, id));

    response.EnsureSuccessStatusCode();

    var result = await response.Content.ReadAsStringAsync();

    // Deserialize the JSON string to Response
    return JsonSerializer.Deserialize<Response>(result, new JsonSerializerOptions
    {
      PropertyNameCaseInsensitive = true // Ensure case-insensitive matching
    }) ?? throw new InvalidOperationException("Deserialization returned null.");
  }
}