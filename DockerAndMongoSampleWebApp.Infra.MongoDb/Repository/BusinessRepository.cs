using DockerAndMongoSampleWebApp.Domain;
using DockerAndMongoSampleWebApp.Infra.MongoDb.Interfaces;

namespace DockerAndMongoSampleWebApp.Infra.MongoDb.Repository
{
    public class BusinessRepository : GenericRepository<Business>
    {
        const int _pageSizeDefault = 25;

        public BusinessRepository(IConnectionMongo connectionMongo) : base(connectionMongo)
        {

        }       
    }
}
