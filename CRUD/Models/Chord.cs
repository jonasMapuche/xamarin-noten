using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CRUD.Models
{
    public class Chord
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string initial { get; set; }
        public string name { get; set; }
        public List<string> device { get; set; }
        public List<Lyrics> lyrics { get; set; }
    }
}
