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
        public string sigla { get; set; }
        public List<ValueModel> value { get; set; }
    }
}