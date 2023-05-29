using MongoDB.Bson;
using MongoDB.Driver;
using PersonnageService.Model;

namespace PersonnageService.Manager
{
    

    public class PersonnageManager
    {
        private readonly IMongoCollection<ModelePersonnage> _personnageCollection;

        public PersonnageManager(IMongoDatabase database)
        {
            _personnageCollection = database.GetCollection<ModelePersonnage>("Personnage");
        }

        public void CreerPersonnage(ModelePersonnage personnage)
        {
            _personnageCollection.InsertOne(personnage);
        }

        public List<ModelePersonnage> ObtenirTousLesPersonnages()
        {
            var personnages = _personnageCollection.Find(_ => true).ToList();
            return personnages;
        }

        public async Task<ModelePersonnage> ObtenirPersonnageParNom(string Name)
        {

            ModelePersonnage personnage = (await _personnageCollection.FindAsync(p=>p.Name==Name)).FirstOrDefault();
            return personnage;
        }   

        public void ModifierPersonnageParNom(string Name, ModelePersonnage personnage)
        {
           // Définissez le filtre pour trouver le document à mettre à jour
            var filter = Builders<ModelePersonnage>.Filter.Eq("Name", ObjectId.Parse("Name"));

            // Définissez les mises à jour que vous souhaitez effectuer
            var update = Builders<ModelePersonnage>.Update.Set("Class",personnage.Class);
            var updateResult = _personnageCollection.UpdateOne(filter, update);
        
        }   
    }


}