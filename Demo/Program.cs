using Microsoft.EntityFrameworkCore;

using Demo.Service;
using Demo.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// string password = File.ReadAllText("/run/secrets/db-password");
// string connectionString = $"Server=db;Database=example;Uid=root;Pwd={password};";
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine($"Connecting to MySQL...{connectionString}");

builder.Services.AddDbContext<DemoDbContext>(options => options.UseMySQL(connectionString: connectionString));


builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseMiddleware<ExceptionHandlerMiddleware>();

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
