using MediatR;
using MeraStore.Service.Logging.Application.LogRequest.Command;
using MeraStore.Service.Logging.Application.Queries;

using Microsoft.AspNetCore.Mvc;

namespace MeraStore.Service.Logging.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RequestsController(IMediator mediator) : ControllerBase
{
  [HttpPost]
  public async Task<IActionResult> CreateRequestLog([FromBody] CreateRequestLogCommand command)
  {
    var id = await mediator.Send(command);
    return Ok(new { Id = id });
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetRequestLog(Guid id)
  {
    var requestLog = await mediator.Send(new GetRequestLogQuery { Id = id });
    if (requestLog == null)
    {
      return NotFound();
    }
    return Ok(requestLog.Content);
  }
}