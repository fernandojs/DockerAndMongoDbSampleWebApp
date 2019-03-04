using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace DockerAndMongoSampleWebApp.Domain
{
    public class Client
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string Id { get; set; }

        [BsonElement("name")]
        [BsonRequired]
        public string Name { get; set; }

        [BsonElement("businessname")]
        [BsonRequired]
        public string BusinessName { get; set; }

        [BsonElement("address")]
        [BsonRequired]
        public string Address { get; set; }

        [BsonElement("jobtitle")]
        [BsonRequired]
        public string JobTitle { get; set; }

        [BsonElement("businessid")]
        public string BusinessId { get; set; }
    }
}
