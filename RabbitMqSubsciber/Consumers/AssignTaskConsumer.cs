using MassTransit;
using RabbbitMqMessages.Messages;

namespace RabbitMqSubsciber.Consumers
{
  public class AssignTaskConsumer : IConsumer<AssignTaskCommand>
  {
    // Buradan sonra iş bitt görev assign edildi Report ve Email Service Bildirim gönderiyorum.

    private readonly IPublishEndpoint _publishEndpoint;

    public AssignTaskConsumer(IPublishEndpoint publishEndpoint)
    {
      _publishEndpoint = publishEndpoint;
    }
    public async Task Consume(ConsumeContext<AssignTaskCommand> context)
    {
      // event gönderdik queue belirtmedik.
      await _publishEndpoint.Publish(new TaskAssignedEvent { EmployeeId = context.Message.EmployeeId, EventDate = DateTime.Now, TaskId = context.Message.TaskId });

      Console.WriteLine($"TaskId:{context.Message.TaskId} ve EmployeeId:{context.Message.EmployeeId}");
      await Task.CompletedTask;
    }
  }
}
