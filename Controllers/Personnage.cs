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


     [HttpGet]
        public IActionResult Get()
        {
            // Logique de récupération des données
            return Ok("Hello World");
        }

        [HttpPost]
        public IActionResult Post([FromBody] string data)
        {
            // Logique de création des données
            return Created("", data);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string data)
        {
            // Logique de mise à jour des données
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Logique de suppression des données
            return NoContent();
        }
}
