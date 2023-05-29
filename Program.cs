using PersonnageService.Model;
using PersonnageService.Manager;
using MongoDB.Driver;
using Microsoft.Extensions.DependencyInjection;
using PersonnageService.DTO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<PersonnageManager>();
builder.Services.AddTransient<MappingService>();
var mongoClient = new MongoClient("mongodb://localhost:27017");
var database = mongoClient.GetDatabase("GameGuesser");
builder.Services.AddSingleton(database);
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
