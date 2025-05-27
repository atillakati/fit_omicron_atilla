using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Collections.Generic;

namespace Wifi.PlaylistEditor.Repositories.Database
{
    public class PlaylistEntity
    {
        [BsonId] // Marks this as the _id field
        [BsonRepresentation(BsonType.ObjectId)] // If it's a string ObjectId
        public string Id { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }
        public string CreateAt { get; set; }
        public IEnumerable<string> ItemPathList { get; set; }
    }
}