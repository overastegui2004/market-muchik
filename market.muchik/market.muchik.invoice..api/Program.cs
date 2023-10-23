using Microsoft.EntityFrameworkCore;
using market.muchik.invoice.application.interfaces;
using market.muchik.invoice.application.mappings;
using market.muchik.invoice.application.services;
using market.muchik.invoice.domain.interfaces;
using market.muchik.invoice.infrastructure.context;
using market.muchik.invoice.infrastructure.repositories;
using market.muchik.infrastructure.bus.settings;
using market.muchik.infrastructure.ioc;
using Steeltoe.Discovery.Client;
using Steeltoe.Extensions.Configuration.ConfigServer;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfigServer();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//AutoMapper
builder.Services.AddAutoMapper(typeof(EntityToDtoProfile), typeof(DtoToEntityProfile));

//SQL Server
builder.Services.AddDbContext<InvoiceContext>(config =>
{
    config.UseNpgsql(builder.Configuration.GetValue<string>("connectionStrings:muchikConnection"));
});

//RabbitMQ Settings
builder.Services.Configure<RabbitMqSettings>(builder.Configuration.GetSection("RabbitMqSettings"));

//IoC
builder.Services.RegisterServices(builder.Configuration);

//Services
builder.Services.AddTransient<IInvoiceService, InvoiceService>();

//Repositories
builder.Services.AddTransient<IInvoiceRepository, InvoiceRepository>();


//Context
builder.Services.AddTransient<InvoiceContext>();

//CORS
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

//Consul
builder.Services.AddDiscoveryClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
