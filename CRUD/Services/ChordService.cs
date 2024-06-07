using System.Collections.Generic;
using System.Threading.Tasks;
using CRUD.Models;
using MongoDB.Driver;

namespace CRUD.Services
{
    public class ChordService
    {
        public static string ConnectionChord { get; set; }
        public static string ConnectionArtless { get; set; }
        public static string ConnectionRecipe { get; set; }
        public static string DatabaseName { get; set; }
        public static string CollectionChord { get; set; }
        public static string JsonFile { get; set; }

        private readonly IMongoCollection<Chord> _chordsCollection;

        public ChordService(string connection)
        {
            MongoClient mongoClient;
            switch (connection) 
            {
                case "recipe":
                    mongoClient = new MongoClient(ConnectionRecipe);
                    break;
                case "artless":
                    mongoClient = new MongoClient(ConnectionArtless);
                    break;
                default:
                    mongoClient = new MongoClient(ConnectionChord);
                    break;
            }
            var mongoDatabase = mongoClient.GetDatabase(DatabaseName);
            IMongoCollection<Chord> ConfigurationValue = mongoDatabase.GetCollection<Chord>(CollectionChord);
            _chordsCollection = ConfigurationValue;
        }

        public async Task<List<Chord>> GetAsync() =>
            await _chordsCollection.Find(_ => true).ToListAsync();

        public async Task<Chord> GetAsync(string id) =>
            await _chordsCollection.Find(index => index.Id == id).FirstOrDefaultAsync();

        public async Task<Chord> GetChordAsync(string initial) =>
            await _chordsCollection.Find(index => index.initial == initial).FirstOrDefaultAsync();

        public async Task CreateAsync(Chord chord) =>
            await _chordsCollection.InsertOneAsync(chord);

        public async Task UpdateAsync(Chord chord) =>
            await _chordsCollection.ReplaceOneAsync(index => index.Id == chord.Id, chord);

        public async Task RemoveAsync(string id) =>
            await _chordsCollection.DeleteOneAsync(index => index.Id == id);

    }
}
