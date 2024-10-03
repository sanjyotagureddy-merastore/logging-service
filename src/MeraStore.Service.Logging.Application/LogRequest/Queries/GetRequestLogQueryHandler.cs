using MediatR;
using MeraStore.Service.Logging.Application.Queries;
using MeraStore.Service.Logging.Core.Interfaces;
using MeraStore.Service.Logging.Core.Models;

namespace MeraStore.Service.Logging.Application.LogRequest.Queries;

public class GetRequestLogQueryHandler(IRequestLogRepository requestLogRepository)
  : IRequestHandler<GetRequestLogQuery, Request>
{
    public async Task<Request> Handle(GetRequestLogQuery request, CancellationToken cancellationToken)
    {
        return await requestLogRepository.GetRequestLogAsync(request.Id);
    }
}