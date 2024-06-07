using System.Collections.Generic;
using System.Threading.Tasks;
using CRUD.Models;
using MongoDB.Driver;

namespace CRUD.Services
{
    public class NotenService
    {
        public static string ConnectionNoten { get; set; }
        public static string ConnectionLetter { get; set; }
        public static string ConnectionMalware { get; set; }
        public static string DatabaseName { get; set; }
        public static string CollectionNoten { get; set; }
        public static string JsonFile { get; set; }

        private readonly IMongoCollection<Noten> _notensCollection;

        public NotenService(string connection)
        {
            MongoClient mongoClient;
            switch (connection)
            {
                case "malware":
                    mongoClient = new MongoClient(ConnectionMalware);
                    break;
                case "letter":
                    mongoClient = new MongoClient(ConnectionLetter);
                    break;
                default:
                    mongoClient = new MongoClient(ConnectionNoten);
                    break;
            }
            var mongoDatabase = mongoClient.GetDatabase(DatabaseName);
            IMongoCollection<Noten> ConfigurationValue = mongoDatabase.GetCollection<Noten>(CollectionNoten);
            _notensCollection = ConfigurationValue;
        }

        public async Task<List<Noten>> GetAsync() =>
            await _notensCollection.Find(_ => true).ToListAsync();

        public async Task<Noten> GetAsync(string id) =>
            await _notensCollection.Find(index => index.Id == id).FirstOrDefaultAsync();

        public async Task<Noten> GetNotenAsync(double frequence) =>
            await _notensCollection.Find(index => index.frequency == frequence).FirstOrDefaultAsync();

        public async Task CreateAsync(Noten noten) =>
            await _notensCollection.InsertOneAsync(noten);

        public async Task UpdateAsync(Noten noten) =>
            await _notensCollection.ReplaceOneAsync(index => index.Id == noten.Id, noten);

        public async Task RemoveAsync(string id) =>
            await _notensCollection.DeleteOneAsync(index => index.Id == id);
    }
}
