using Autenticazione.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Autenticazione.Repository;
using Autenticazione.Business;
using Autenticazione.Business.Abstractions;
using Autenticazione.Repository.Abstractions;
using Autenticazione.Business.Kafka;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IBusiness, Business>();

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("AutenticazioneDbContext") ?? throw new InvalidOperationException("Connection string 'AutenticazioneDbContext' not found.");
builder.Services.AddDbContext<AutenticazioneDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AutenticazioneDbContext>();
builder.Services.AddRazorPages();

builder.Services.AddKafkaProducerService<KafkaTopicsOutput, ProducerService>(builder.Configuration);
builder.Services.AddHttpContextAccessor();

//builder.Services.AddKafkaProducerService<KafkaTopicsOutput, ProducerService>(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllers();

app.MapRazorPages();

app.Run();
