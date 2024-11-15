using Recensioni.Business.Abstractions;
using Recensioni.Repository.Abstractions;
using Recensioni.Business;
using Recensioni.Repository;
using Microsoft.EntityFrameworkCore;
using Recensioni.Business.Kafka;
using Recensioni.Business.Kafka.MessageHandlers;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<RecensioniDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("RecensioniDbContext")));
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IBusiness, Business>();
builder.Services.AddControllers();
builder.Services.AddKafkaConsumerService<KafkaTopicsInput, MessageHandlerFactory>(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
