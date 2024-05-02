using MassTransit;
using RabbbitMqMessages.Messages;
using RabbitMqSubsciber.Consumers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(config =>
{
  config.AddConsumer<AssignTaskConsumer>();

  config.UsingRabbitMq((context, cfg) =>
  {
    cfg.Host(builder.Configuration.GetConnectionString("RabbitMq"));

    cfg.ReceiveEndpoint("deneme", e => e.ConfigureConsumer<AssignTaskConsumer>(context));
  });
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
