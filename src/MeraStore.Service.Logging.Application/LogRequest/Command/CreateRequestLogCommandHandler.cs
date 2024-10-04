using MediatR;
using MeraStore.Service.Logging.Core.Interfaces;
using MeraStore.Service.Logging.Core.Models;

namespace MeraStore.Service.Logging.Application.LogRequest.Command;

public class CreateRequestLogCommandHandler(IRequestLogRepository requestLogRepository)
  : IRequestHandler<CreateRequestLogCommand, Guid>
{
    public async Task<Guid> Handle(CreateRequestLogCommand request, CancellationToken cancellationToken)
    {
        var requestLog = new Request
        {
            Endpoint = request.Endpoint,
            Content = request.Content,
            Timestamp = DateTime.UtcNow
        };

        await requestLogRepository.AddRequestLogAsync(requestLog);
        return requestLog.Id;
    }
}