using CitiesManager.WebAPI.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApllicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddControllers();

//Swagger
builder.Services.AddEndpointsApiExplorer(); //Generates description for all endpoints
builder.Services.AddSwaggerGen(); //generates OpenAPI specification


var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseHsts();
app.UseHttpsRedirection();

app.UseSwagger(); //creates endpoint for swagger.json
app.UseSwaggerUI(); //creates swagger UI for testing all Web API endpoints / action methods

app.UseAuthorization();

app.MapControllers();

app.Run();
