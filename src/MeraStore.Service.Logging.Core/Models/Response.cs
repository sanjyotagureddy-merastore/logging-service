using MeraStore.Shared.Common.Core.Domain.Entities;

namespace MeraStore.Service.Logging.Core.Models;

public class Response : Entity
{
  public string Endpoint { get; set; }
  public string Content { get; set; }
  public DateTime Timestamp { get; set; }
}