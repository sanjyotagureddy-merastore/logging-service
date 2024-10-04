using MediatR;
using MeraStore.Service.Logging.Application.LogResponse.Command;
using MeraStore.Service.Logging.Application.LogResponse.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MeraStore.Service.Logging.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResponsesController(IMediator mediator) : ControllerBase
{
  [HttpPost]
  public async Task<IActionResult> CreateResponseLog([FromBody] CreateResponseLogCommand command)
  {
    var id = await mediator.Send(command);
    return Ok(new { Id = id });
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetResponseLog(Guid id)
  {
    var responseLog = await mediator.Send(new GetResponseLogQuery { Id = id });
    if (responseLog == null)
    {
      return NotFound();
    }
    return Ok(responseLog.Content);
  }
}