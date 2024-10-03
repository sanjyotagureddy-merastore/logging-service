using MediatR;
using MeraStore.Service.Logging.Core.Interfaces;
using MeraStore.Service.Logging.Core.Models;

namespace MeraStore.Service.Logging.Application.LogResponse.Queries;

public class GetResponseLogQueryHandler(IResponseLogRepository responseLogRepository)
  : IRequestHandler<GetResponseLogQuery, Response>
{
    public async Task<Response> Handle(GetResponseLogQuery request, CancellationToken cancellationToken)
    {
        return await responseLogRepository.GetResponseLogAsync(request.Id);
    }
}