using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace DockerAndMongoSampleWebApp.Domain
{
    public class Employee
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string Id { get; set; }

        [BsonElement("name")]
        [BsonRequired]
        public string Name { get; set; }

        [BsonElement("address")]
        [BsonRequired]
        public string Address { get; set; }

        [BsonElement("age")]
        [BsonRequired]
        public string Age { get; set; }

        [BsonElement("businessid")]
        public string BusinessId { get; set; }
    }
}
