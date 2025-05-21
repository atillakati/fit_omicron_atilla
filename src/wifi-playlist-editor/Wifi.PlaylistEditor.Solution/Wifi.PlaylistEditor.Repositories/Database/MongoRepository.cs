using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wifi.PlaylistEditor.Core;

namespace Wifi.PlaylistEditor.Repositories.Database
{
    public class MongoRepository<T> : IDataBaseRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;

        public MongoRepository(string connectionString, string databaseName, string collectionName)
        {
            if (string.IsNullOrWhiteSpace(connectionString) ||
                string.IsNullOrWhiteSpace(databaseName) ||
                string.IsNullOrWhiteSpace(collectionName))
            {
                throw new ArgumentNullException(nameof(collectionName));
            }

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _collection = database.GetCollection<T>(collectionName);
        }

        public async Task CreateAsync(T item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            await _collection.InsertOneAsync(item);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(FilterDefinition<T>.Empty).ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));

            var filter = Builders<T>.Filter.Eq("Id", id);
            return await _collection.Find(filter).FirstOrDefaultAsync();            
        }

        public async Task UpdateAsync(string id, T updatedItem)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));
            if (updatedItem == null) throw new ArgumentNullException(nameof(updatedItem));

            var filter = Builders<T>.Filter.Eq("Id", id);
            await _collection.ReplaceOneAsync(filter, updatedItem);
        }

        public async Task DeleteAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));

            var filter = Builders<T>.Filter.Eq("Id", id);
            await _collection.DeleteOneAsync(filter);
        }
    }
}
