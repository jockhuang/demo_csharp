using Demo.Controllers;
using Demo.Service;
using Demo.Service.Impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// string password = File.ReadAllText("/run/secrets/db-password");
// string connectionString = $"Server=db;Database=example;Uid=root;Pwd={password};";
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine($"Connecting to MySQL...{connectionString}");

builder.Services.AddDbContext<DemoDbContext>(options => options.UseMySQL(connectionString));

// builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IMailListService, MailListService>();
builder.Services.AddScoped<IStatisticService, StatisticService>();

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
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            if (builder.Configuration["EF_MIGRATE"] == "true")
            {
                var db = services.GetRequiredService<DemoDbContext>();
                db.Database.Migrate();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    app.UseCors(corsPolicyBuilder =>
        corsPolicyBuilder.WithOrigins("http://localhost:5173")
            .AllowAnyMethod()
            .AllowAnyHeader()
    );
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();