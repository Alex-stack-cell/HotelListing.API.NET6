using Serilog;

// Services declaration
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", 
        b => b.AllowAnyHeader()
        .AllowAnyOrigin()
        .AllowAnyMethod());// allow all clients to connect to our api
});

// hostContext is the builder context containing the services
builder.Host.UseSerilog((hostContext, loggerConfiguration)=>loggerConfiguration.WriteTo.Console().ReadFrom.Configuration(hostContext.Configuration));// rely on the configuration file => appsettings.json

//Middleware declaration
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");//allow CORS policy for all controller endpoints

app.UseAuthorization();

app.MapControllers();

app.Run();
