using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbbitMqMessages.Messages
{
  // Send ile gönderilecek olan komut
  // Test Deneme
  public class AssignTaskCommand
  {
    public string TaskId { get; set; } 
    public string EmployeeId { get; set; }

  }
}
