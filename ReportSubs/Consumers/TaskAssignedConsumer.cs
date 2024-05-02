using MassTransit;
using RabbbitMqMessages.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSubs.Consumers
{
  public class TaskAssignedConsumer : IConsumer<TaskAssignedEvent>
  {
    public async Task Consume(ConsumeContext<TaskAssignedEvent> context)
    {
      Console.WriteLine("Report Service Tetiklendi");
      await Task.CompletedTask;
    }
  }
}
