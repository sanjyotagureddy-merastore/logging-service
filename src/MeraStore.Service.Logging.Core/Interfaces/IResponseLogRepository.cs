using MeraStore.Service.Logging.Core.Models;

namespace MeraStore.Service.Logging.Core.Interfaces;

public interface IResponseLogRepository
{
  Task AddResponseLogAsync(Response response);
  Task<Response> GetResponseLogAsync(Guid id);
}