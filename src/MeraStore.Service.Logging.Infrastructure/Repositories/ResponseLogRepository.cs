using MeraStore.Service.Logging.Core.Interfaces;
using MeraStore.Service.Logging.Core.Models;

namespace MeraStore.Service.Logging.Infrastructure.Repositories;

public class ResponseLogRepository(ApplicationDbContext context) : IResponseLogRepository
{
  public async Task AddResponseLogAsync(Response response)
  {
    context.Responses.Add(response);
    await context.SaveChangesAsync();
  }

  public async Task<Response> GetResponseLogAsync(Guid id)
  {
    return await context.Responses.FindAsync(id);
  }
}