
namespace PersonnageService.DTO{

    public class DTOPersonnage
    {
        public string Name { get; set; }
        public string Class { get; set; }
        // Autres propriétés du DTOPersonnage

        public DTOPersonnage(string Name, string Class)
        {
            this.Name = Name;
            this.Class = Class;
        }

        public DTOPersonnage()
        {
            this.Name="";
            this.Class="";
        }
    }

}