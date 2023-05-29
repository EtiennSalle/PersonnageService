using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PersonnageService.Model;

public class ModelePersonnage
{
    [BsonId]
    public String Id { get; set; }
    public String Name { get; set; }

    public String Class { get; set; }

    public DateOnly BirthDate {get;set;}



    public ModelePersonnage(String Id,String Name, String Class,DateOnly BirthDate){

        this.Id=Id;
        this.Name=Name;
        this.Class=Class;
        this.BirthDate=BirthDate;

    }

        public ModelePersonnage(){

            this.Id="5";
            this.Name="";
            this.Class="None";

    }

}
