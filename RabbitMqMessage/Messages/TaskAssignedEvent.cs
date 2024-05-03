using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbbitMqMessages.Messages
{
  // Test-1
  public class TaskAssignedEvent
  {
    public string TaskId { get; set; }
    public string EmployeeId { get; set; }
    public DateTime EventDate { get; set; }
  }
}
