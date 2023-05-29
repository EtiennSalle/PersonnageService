namespace PersonnageService;

public class Personnage
{
    public String Name { get; set; }

    public String Class { get; set; }

    public DateOnly BirthDate {get;set;}

    public string? Summary { get; set; }


    public Personnage(String Name, String Class){

        this.Name=Name;
        this.Class=Name;

    }
}
