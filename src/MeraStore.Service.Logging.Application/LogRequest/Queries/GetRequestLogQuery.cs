using MediatR;
using MeraStore.Service.Logging.Core.Models;

namespace MeraStore.Service.Logging.Application.Queries;

public class GetRequestLogQuery : IRequest<Request>
{
    public Guid Id { get; set; }
}