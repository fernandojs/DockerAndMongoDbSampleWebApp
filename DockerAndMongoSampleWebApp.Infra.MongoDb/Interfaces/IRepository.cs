using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DockerAndMongoSampleWebApp.Infra.MongoDb.Interfaces
{
    public interface IRepository<T>
    {
        T Get(Guid id);
        T GetById(string id);
        Task<IList<T>> GetByIdListAsync(List<string> idList);
        Task<T> GetByIdAsync(string id);
        bool Delete(string id);
        Task<bool> InsertAsync(T entity);
        bool UpdateOne(FilterDefinition<T> filter, UpdateDefinition<T> update);
    }
}
