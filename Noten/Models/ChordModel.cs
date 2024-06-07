using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Noten.Models
{
    public class ChordModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string initial { get; set; }
        public string name { get; set; }
        public List<string> device { get; set; }
        public List<LyricsModel> lyrics { get; set; }

    }
}