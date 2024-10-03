using MediatR;

namespace MeraStore.Service.Logging.Application.LogRequest.Command;

public class CreateRequestLogCommand : IRequest<Guid>
{
    public string Endpoint { get; set; }
    public string Content { get; set; }
}