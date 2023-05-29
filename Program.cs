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
ModelePersonnage personnage = new ModelePersonnage(
    "azeqsaeazed",
    "Chocolat",
    "bruges", 
    DateOnly.FromDateTime(new DateTime(1995,03,09))
    );
var mongoClient = new MongoClient("mongodb://localhost:27017");
var database = mongoClient.GetDatabase("GameGuesser");
builder.Services.AddSingleton(database);
PersonnageManager PM = new PersonnageManager(database);

PM.CreerPersonnage(personnage);


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
