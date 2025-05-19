using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace Wifi.PlaylistEditor.Repositories.Database
{    
    public class Person
    {
        [BsonId] // Marks as MongoDB document ID
        [BsonRepresentation(BsonType.ObjectId)] // Stores as ObjectId but allows passing string
        public string Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

}
