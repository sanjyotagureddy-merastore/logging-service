namespace MeraStore.Service.Logging.SDK;

public static class ApiEndpoints
{
  public const string BaseUri = "/api/"; // Base URI for the API

  public static class RequestLogs
  {
    public const string Create = $"{BaseUri}requests";
    public const string Get = $"{BaseUri}requests/{{0}}"; // Placeholder for ID
  }

  public static class ResponseLogs
  {
    public const string Create = $"{BaseUri}responses";
    public const string Get = $"{BaseUri}responses/{{0}}"; // Placeholder for ID
  }
}