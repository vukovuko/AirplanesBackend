using Airplanes.BusinessLogic;
using Airplanes.Data_Layer;
using Integrations.Modules_Handlers.Ticketing_Handlers;
using MessageBus;
using Microsoft.EntityFrameworkCore;
using Ticketing.BusinessLogic;
using Ticketing.Data_Layer;

var builder = WebApplication.CreateBuilder(args);

// Configuration setup
builder.Configuration.AddJsonFile("Configuration/appsettings.json"); // Specify the JSON configuration file

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:4200") // Angular app's URL
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

var x = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AirplaneContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<TicketingContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register SimpleMessageBus as a singleton service
builder.Services.AddSingleton<IMessageBus, InternalMessageBus>();

builder.Services.AddSingleton<IAirplaneRepository, AirplaneRepository>();

builder.Services.AddSingleton<ITicketingRepository, TicketingRepository>();

builder.Services.AddSingleton<ITicketingManager, TicketingManager>();

builder.Services.AddSingleton<IAirplaneManager, AirplaneManager>();

builder.Services.AddSingleton<CreatedTicketEventHandler>();

builder.Services.AddControllers();

var app = builder.Build();

// Retrieve the MessageBus instance
var messageBus = app.Services.GetRequiredService<IMessageBus>();

// Retrieve the service instance which contains the handler you want to subscribe
var myEventHandler = app.Services.GetRequiredService<CreatedTicketEventHandler>();

// Assuming CreatedTicketEventHandler has a method HandleTicketCreated
// that matches the expected delegate signature for the message type
messageBus.Subscribe<CreatedTicketEvent>(myEventHandler.OnCreatedTicket);

// Initialize airplane in database
var AirplaneRepository = app.Services.GetRequiredService<IAirplaneRepository>();
AirplaneRepository.Initialize();

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