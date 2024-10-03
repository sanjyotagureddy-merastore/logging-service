using MediatR;
using MeraStore.Service.Logging.Core.Interfaces;
using MeraStore.Service.Logging.Core.Models;

namespace MeraStore.Service.Logging.Application.LogResponse.Command;

public class CreateResponseLogCommandHandler(IResponseLogRepository responseLogRepository)
  : IRequestHandler<CreateResponseLogCommand, Guid>
{
    public async Task<Guid> Handle(CreateResponseLogCommand request, CancellationToken cancellationToken)
    {
        var responseLog = new Response
        {
            Endpoint = request.Endpoint,
            Content = request.Content,
            Timestamp = DateTime.UtcNow
        };

        await responseLogRepository.AddResponseLogAsync(responseLog);
        return responseLog.Id;
    }
}