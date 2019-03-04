using System;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;
using DockerAndMongoSampleWebApp.Infra.MongoDb.Interfaces;

namespace DockerAndMongoSampleWebApp.Infra.MongoDb.Repository
{
    public class GenericRepository<T> : IRepository<T>
    {
        protected readonly IMongoDatabase _database;
        protected readonly IMongoCollection<T> _collection;

        public GenericRepository(IConnectionMongo connectionMongo)
        {
            _database = connectionMongo.database;
            _collection = _database.GetCollection<T>(typeof(T).Name);
        }

        public T Get(Guid id)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            return _collection.Find(filter).FirstOrDefault();
        }

        public T GetById(string id)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            return _collection.Find(filter).FirstOrDefault();
        }

        public async Task<IList<T>> GetByIdListAsync(List<string> idList)
        {
            var filter = Builders<T>.Filter.In("Id", idList);
            var result = await _collection.FindAsync(filter);

            return result.ToList();
        }

        public IList<T> GetByIdList(List<string> idList)
        {
            var filter = Builders<T>.Filter.In("Id", idList);
            var result = _collection.Find(filter);

            return result.ToList();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            var result = await _collection.FindAsync(filter);
            return result.FirstOrDefault();
        }

        public virtual IList<T> GetAll()
        {
            try
            {
                return _collection.Find(_ => true).ToList();
            }
            catch
            {
                return null;
            }

        }

        public async Task<bool> InsertAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);

            return true;
        }

        public bool UpdateOneById(string id, UpdateDefinition<T> update)
        {
            try
            {
                var objectId = new ObjectId(id);
                var filter = Builders<T>.Filter.Eq("Id", objectId);
                _collection.FindOneAndUpdateAsync(filter, update);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual bool UpdateOne(FilterDefinition<T> filter, UpdateDefinition<T> update)
        {
            try
            {
                _collection.FindOneAndUpdateAsync(filter, update);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual async Task<Boolean> UpdateOneAsync(FilterDefinition<T> filter, UpdateDefinition<T> update)
        {
            try
            {
                var result = await _collection.FindOneAndUpdateAsync(filter, update);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(string id)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            _collection.DeleteOneAsync(filter);

            return true;
        }


    }
}
