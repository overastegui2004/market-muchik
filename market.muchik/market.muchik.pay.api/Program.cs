    using MediatR;
using Microsoft.EntityFrameworkCore;
using market.muchik.domain.bus;
using market.muchik.infrastructure.bus.settings;
using market.muchik.infrastructure.ioc;
using market.muchik.pay.application.eventHandlers;
using market.muchik.pay.application.events;
using market.muchik.pay.application.interfaces;
using market.muchik.pay.application.mappings;
using market.muchik.pay.application.services;
using market.muchik.pay.domain.interfaces;
using market.muchik.pay.infrastructure.context;
using market.muchik.pay.infrastructure.repositories;
using Steeltoe.Common.Contexts;
using Steeltoe.Discovery.Client;
using Steeltoe.Extensions.Configuration.ConfigServer;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfigServer();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//AutoMapper  Oscar
builder.Services.AddAutoMapper(typeof(EntityToDtoProfile), typeof(DtoToEntityProfile));

//MY SQL 
builder.Services.AddDbContext<PaymentContext>(config =>
{
    config.UseMySQL(builder.Configuration.GetValue<string>("connectionStrings:muchikConnection"));
});

//RabbitMQ Settings
//builder.Services.Configure<RabbitMqSettings>(builder.Configuration.GetSection("rabbitMqSettings"));

//IoC
builder.Services.RegisterServices(builder.Configuration);

//Services
builder.Services.AddTransient<IPaymentService, PaymentService>();

//Repositories
builder.Services.AddTransient<IPaymentRepository, PaymentRepository>();

//Context
builder.Services.AddTransient<PaymentContext>();

//Commands & Events
builder.Services.AddTransient<IEventHandler<CreatePaymentEvent>, CreatePaymentEventHandler>();

//Subscriptions
builder.Services.AddTransient<CreatePaymentEventHandler>();

//CORS
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

//Consul
builder.Services.AddDiscoveryClient();

var app = builder.Build();

//Subscriptions
var eventBus = app.Services.GetRequiredService<IEventBus>();
eventBus.Subscribe<CreatePaymentEvent, CreatePaymentEventHandler>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
