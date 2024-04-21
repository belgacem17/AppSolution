using Application;
using DomainLayer;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument();

string connectionString = builder.Configuration.GetConnectionString("appSolutionDB");
builder.Services.AddDbContext<AppSolutionDBContext>(options => options.UseSqlServer(connectionString)
.LogTo(Console.WriteLine)
.EnableSensitiveDataLogging(true)
.EnableDetailedErrors(true));

// Tous les services du projet ApplicationLayer doivent être ajoutés ici
StartupConfigurationEvolutive.InjecterServices(builder.Services);

StartupConfigurationEvolutive.InjecterRepositories(builder.Services);
WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi3();
}
// Swagger
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
public partial class Program { }
