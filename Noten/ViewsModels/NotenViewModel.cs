using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Noten.Models;

namespace Noten.ViewsModels
{
    public class NotenViewModel
    {
        private static string ConnectionName { get; set; }
        private static string DatabaseName { get; set; }
        private static string CollectionLetter { get; set; }

        private readonly IMongoCollection<ChordModel> _chordsCollection;

        public NotenViewModel()
        {
            ConnectionName = "mongodb://jonas:freedown@cluster0-shard-00-00.28oko.azure.mongodb.net:27017,cluster0-shard-00-01.28oko.azure.mongodb.net:27017,cluster0-shard-00-02.28oko.azure.mongodb.net:27017/?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true&w=majority";
            DatabaseName = "letterDB";
            CollectionLetter = "chord";

            var mongoClient = new MongoClient(ConnectionName);
            var mongoDatabase = mongoClient.GetDatabase(DatabaseName);
            IMongoCollection<ChordModel> ConfigurationValue = mongoDatabase.GetCollection<ChordModel>(CollectionLetter);

            _chordsCollection = ConfigurationValue;

        }

        public ChordModel GetChord(string sigla) => _chordsCollection.Find(index => index.sigla == sigla).FirstOrDefault();

        public async Task<ChordModel> GetChordAsync(string sigla) => await _chordsCollection.Find(index => index.sigla == sigla).FirstOrDefaultAsync();

    }
}