using VehicleHub.Application;
using VehicleHub.Persistence;
using VehicleHub.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddPersistence();
builder.Services.AddApplication();
builder.Services.AddControllers();
builder.Services.AddMapperService();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddProblemDetails();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseExceptionHandler();

app.MapControllers();

app.Run();
