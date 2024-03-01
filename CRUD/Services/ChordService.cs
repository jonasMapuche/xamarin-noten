using System.Collections.Generic;
using System.Threading.Tasks;
using CRUD.Models;
using MongoDB.Driver;

namespace CRUD.Services
{
    public class ChordService
    {
        public static string ConnectionName { get; set; }
        public static string DatabaseName { get; set; }
        public static string CollectionChord { get; set; }
        public static string JsonFile { get; set; }

        private readonly IMongoCollection<Chord> _chordsCollection;

        public ChordService()
        {
            var mongoClient = new MongoClient(ConnectionName);
            var mongoDatabase = mongoClient.GetDatabase(DatabaseName);
            IMongoCollection<Chord> ConfigurationValue = mongoDatabase.GetCollection<Chord>(CollectionChord);

            _chordsCollection = ConfigurationValue;
        }

        public async Task<List<Chord>> GetAsync() =>
            await _chordsCollection.Find(_ => true).ToListAsync();

        public async Task<Chord> GetAsync(string id) =>
            await _chordsCollection.Find(index => index.Id == id).FirstOrDefaultAsync();

        public async Task<Chord> GetChordAsync(string sigla) =>
            await _chordsCollection.Find(index => index.sigla == sigla).FirstOrDefaultAsync();

        public async Task CreateAsync(Chord chord) =>
            await _chordsCollection.InsertOneAsync(chord);

        public async Task UpdateAsync(Chord chord) =>
            await _chordsCollection.ReplaceOneAsync(index => index.Id == chord.Id, chord);

        public async Task RemoveAsync(string id) =>
            await _chordsCollection.DeleteOneAsync(index => index.Id == id);

    }
}
