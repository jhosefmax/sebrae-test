using Microsoft.Extensions.Configuration;
using Sebrae.Repository;
using Sebrae.Services.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Sebrae.Persistence.Dependencies.ConfigureServices(builder.Services, builder.Configuration);

builder.Services.AddScoped<IViaCepService, ViaCepService>();
builder.Services.AddScoped<IContasService, ContaService>();
builder.Services.AddScoped<IContaRepository, ContaRepository>();



var app = builder.Build();

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
