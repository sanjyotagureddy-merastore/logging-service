using MediatR;
using MeraStore.Service.Logging.Core.Models;

namespace MeraStore.Service.Logging.Application.LogResponse.Queries;

public class GetResponseLogQuery : IRequest<Response>
{
    public Guid Id { get; set; }
}