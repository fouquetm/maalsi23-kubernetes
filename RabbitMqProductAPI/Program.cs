using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using RabbitMqProductAPI.Data;
using RabbitMqProductAPI.RabbitMQ;
using RabbitMqProductAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddDbContext<DbContextClass>();

builder.Services.AddScoped<IRabbitMQProducer, RabbitMQProducer>();

builder.Services.AddSingleton<IModel>(serviceProvider =>
{
    //Here we specify the Rabbit MQ Server. we use rabbitmq docker image and use it
    var factory = new ConnectionFactory
    {
        HostName = builder.Configuration["RabbitMQ:Hostname"],
        UserName = builder.Configuration["RabbitMQ:Username"],
        Password = builder.Configuration["RabbitMQ:Password"]
    };

    //Create the RabbitMQ connection using connection factory details as i mentioned above
    var connection = factory.CreateConnection();

    //Here we create channel with session and model
    var channel = connection.CreateModel();

    return channel;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Migrate latest database changes during startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<DbContextClass>();

    // Here is the migration executed
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
