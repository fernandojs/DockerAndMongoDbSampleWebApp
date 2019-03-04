using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace DockerAndMongoSampleWebApp.Domain
{
    public class Business
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string Id { get; set; }

        [BsonElement("name")]
        [BsonRequired]
        public string Name { get; set; }

        [BsonElement("cnpj")]
        public string Cnpj { get; set; }
    }
}
