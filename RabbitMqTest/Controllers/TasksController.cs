using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbbitMqMessages.Messages;
using System.Runtime.CompilerServices;

namespace RabbitMqTest.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TasksController : ControllerBase
  {
    private readonly ISendEndpointProvider _sendEndpointProvider;

    public TasksController(ISendEndpointProvider sendEndpointProvider)
    {
      _sendEndpointProvider = sendEndpointProvider;
    }

    [HttpPost]
    public async Task<IActionResult> AssignTask()
    {

      var message = new AssignTaskCommand();
      message.TaskId = Guid.NewGuid().ToString();
      message.EmployeeId = Guid.NewGuid().ToString();


      //for (int i = 0; i < 100; i++)
      //{
        var sendPoint = await _sendEndpointProvider.GetSendEndpoint(new Uri($"queue:deneme"));
        //Thread.Sleep(100);
        await sendPoint.Send(message);


    

      return Ok();
    }
  }
}
