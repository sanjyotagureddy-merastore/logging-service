using MeraStore.Service.Logging.Core.Models;

namespace MeraStore.Service.Logging.Core.Interfaces
{
  public interface IRequestLogRepository
  {
    Task AddRequestLogAsync(Request request);
    Task<Request> GetRequestLogAsync(Guid id);
  }
}