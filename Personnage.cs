using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PersonnageService;

public class Personnage
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public String Name { get; set; }

    public String Class { get; set; }

    public DateOnly BirthDate {get;set;}



    public Personnage(String Name, String Class,DateOnly BirthDate){

        this.Name=Name;
        this.Class=Name;
        this.BirthDate=BirthDate;

    }

        public Personnage(){
            this.Name="";
            this.Class="None";

    }
}
