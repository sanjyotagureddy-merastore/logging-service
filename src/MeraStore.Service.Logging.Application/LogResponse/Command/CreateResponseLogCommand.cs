using MediatR;

namespace MeraStore.Service.Logging.Application.LogResponse.Command;

public class CreateResponseLogCommand : IRequest<Guid>
{
    public string Endpoint { get; set; }
    public string Content { get; set; }
}