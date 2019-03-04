using System;
using MongoDB.Driver;
using System.Net.Sockets;
using Microsoft.Extensions.Options;
using System.Linq;
using DockerAndMongoSampleWebApp.Infra.MongoDb.Interfaces;
using DockerAndMongoSampleWebApp.Domain.ValueObjects;

namespace DockerAndMongoSampleWebApp.Infra.MongoDb.Repository
{
    public class ConnectionMongo : IConnectionMongo
    {
        public IMongoDatabase database { get; set; }
        private readonly AppSettings _appSettings;

        public ConnectionMongo(IOptions<AppSettings> appSettings)
        {
            var connectionString = appSettings.Value.MongoConnectionString;
            var mongoUrl = new MongoUrl(connectionString);
            var client = new MongoClient(mongoUrl);
            database = client.GetDatabase(mongoUrl.DatabaseName);
        }

    }
}
