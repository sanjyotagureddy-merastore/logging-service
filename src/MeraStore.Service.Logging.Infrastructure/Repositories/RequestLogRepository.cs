using MeraStore.Service.Logging.Core.Interfaces;
using MeraStore.Service.Logging.Core.Models;

namespace MeraStore.Service.Logging.Infrastructure.Repositories;

public class RequestLogRepository(ApplicationDbContext context) : IRequestLogRepository
{
  public async Task AddRequestLogAsync(Request request)
  {
    context.Requests.Add(request);
    await context.SaveChangesAsync();
  }

  public async Task<Request> GetRequestLogAsync(Guid id)
  {
    return await context.Requests.FindAsync(id);
  }
}