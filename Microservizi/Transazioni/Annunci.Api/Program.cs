using Transazioni.Business.Abstractions;
using Transazioni.Repository.Abstractions;
using Transazioni.Business;
using Transazioni.Repository;
using Microsoft.EntityFrameworkCore;
using Transazioni.Business.Kafka;
using Utility.Kafka.Abstractions.MessageHandlers;
using Transazioni.Business.Kafka.MessageHandlers;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TransazioniDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TransazioniDbContext")));
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IBusiness, Business>();
builder.Services.AddControllers();
builder.Services.AddKafkaConsumerService<KafkaTopicsInput, MessageHandlerFactory>(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddKafkaProducerService<KafkaTopicsOutput, ProducerService>(builder.Configuration);
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
