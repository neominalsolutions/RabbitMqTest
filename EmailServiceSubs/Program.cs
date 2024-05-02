

using EmailServiceSubs.Consumers;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

Console.WriteLine("Hello, World!");


var builder = Host.CreateDefaultBuilder(args).ConfigureServices((hostContext, services) =>
{
  services.AddMassTransit((config) =>
  {
    config.AddConsumer<TaskAssignedConsumer>();

    config.UsingRabbitMq((context, cfg) => {
        cfg.Host(hostContext.Configuration.GetConnectionString("RabbitMq"));
      // event olduğu için recieve endpointte queue ismi tanımlamaya gerek yok
      cfg.ReceiveEndpoint(e => e.ConfigureConsumer<TaskAssignedConsumer>(context));
  });
  });
});


// application Run komutu
builder.Build().Run();
