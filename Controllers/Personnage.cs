using Microsoft.AspNetCore.Mvc;

namespace PersonnageService.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonnageController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<PersonnageController> _logger;

    public PersonnageController(ILogger<PersonnageController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetPersonnage")]
    public IEnumerable<Personnage> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Personnage
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
