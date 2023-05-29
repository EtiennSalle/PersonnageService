using PersonnageService.Model;
using PersonnageService.DTO;
    public class MappingService
    {
        public DTOPersonnage MapToDTO(ModelePersonnage personnage)
        {
            return new DTOPersonnage
            {
                Name = personnage.Name,
                Class = personnage.Class
            };
        }

        public ModelePersonnage MapToModel(DTOPersonnage dtoPersonnage)
        {
            return new ModelePersonnage
            {
                Name = dtoPersonnage.Name,
                Class = dtoPersonnage.Class
            };
        }

        public ModelePersonnage MapToModel(string Id, DTOPersonnage dtoPersonnage)
        {
            return new ModelePersonnage
            {   Id=Id,
                Name = dtoPersonnage.Name,
                Class = dtoPersonnage.Class
            };
        }
    }

