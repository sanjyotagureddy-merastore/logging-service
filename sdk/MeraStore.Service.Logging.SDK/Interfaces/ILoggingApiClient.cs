using MeraStore.Service.Logging.SDK.Models;

namespace MeraStore.Service.Logging.SDK.Interfaces;

public interface ILoggingApiClient
{
  // Request logging methods
  Task<string> CreateRequestLogAsync(BaseDto command);
  Task<Request> GetRequestLogAsync(Guid id);

  // Response logging methods
  Task<string> CreateResponseLogAsync(BaseDto command);
  Task<Response> GetResponseLogAsync(Guid id);
}