using Microsoft.AspNetCore.Mvc;
using PersonnageService.DTO;
using PersonnageService.Manager;
using PersonnageService.Model;

namespace PersonnageService.Controllers;

[ApiController]
[Route("api/personnages")]
public class PersonnageController : ControllerBase
{

    private readonly PersonnageManager _personnageManager;
    private readonly MappingService _mappingService;
    private readonly ILogger<PersonnageController> _logger;




     public PersonnageController(PersonnageManager personnageManager,  MappingService mappingService, ILogger<PersonnageController> logger)
    {
        _personnageManager = personnageManager;
         _mappingService = mappingService;
         _logger=logger;
    }


        [HttpGet(Name = "Personnages")]
        public ActionResult<List<DTOPersonnage>> Get()
        {
            try{
            List<ModelePersonnage> personnages =  _personnageManager.ObtenirTousLesPersonnages();
            List<DTOPersonnage> dtoPersonnages = personnages.Select(p => _mappingService.MapToDTO(p)).ToList();
            return Ok(dtoPersonnages);
            }catch(HttpRequestException ex){
            return NoContent();
            }
            // Logique de récupération des données

        }
        [HttpGet("{name}")]
        public async Task<ActionResult<DTOPersonnage>> GetAsync(string name)
        {
            try{
            ModelePersonnage personnage =  await _personnageManager.ObtenirPersonnageParNom(name);
            DTOPersonnage dtoPersonnage = _mappingService.MapToDTO(personnage);
            return Ok(dtoPersonnage);
            }catch(HttpRequestException ex){
            return NoContent();
            }
            // Logique de récupération des données

        }
        [HttpPost]
        public ActionResult Create(DTOPersonnage dtoPersonnage)
        {
            var personnage = _mappingService.MapToModel(dtoPersonnage);
            return Created(new Uri($"{Request.Path}/{dtoPersonnage.Name},UriKind.Relative"),personnage);
        }

        [HttpPut("{name}")]
        public ActionResult Put(string name, DTOPersonnage dtoPersonnage)
        {
            var personnage = _mappingService.MapToModel(name,dtoPersonnage);
            _personnageManager.ModifierPersonnageParNom(name,personnage);
            return Ok();
        }

        [HttpDelete("{name}")]
        public IActionResult Delete(string name)
        {
            // Logique de suppression des données
            return NoContent();
        }
}
