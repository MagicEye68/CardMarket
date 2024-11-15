using Annunci.Business.Abstractions;
using Annunci.Repository.Abstractions;
using Annunci.Business;
using Annunci.Repository;
using Microsoft.EntityFrameworkCore;
using Annunci.Business.Kafka;
using Utility.Kafka.Abstractions.MessageHandlers;
using Annunci.Business.Kafka.MessageHandlers;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AnnunciDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AnnunciDbContext")));
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
