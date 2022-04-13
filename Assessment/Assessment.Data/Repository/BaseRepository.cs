using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Assessment.Data.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using MongoDB.Bson;
    using MongoDB.Driver;

    public interface IBaseRepository<T>
    {
        List<T> GetList();
        Task<List<T>> GetListAsync();
        void InsertItem(T item);
        Task InsertItemAsync(T item);
        T GetById(string id);
        Task<T> GetByIdAsync(string Id);
        void DeleteItem(Expression<Func<T, bool>> predicate);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> predicate);
        T GetByFilter(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetListByFilterAsync(Expression<Func<T, bool>> predicate);
        List<T> GetListByFilter(Expression<Func<T, bool>> predicate);
        List<T> GetListByFilterDefinition(FilterDefinition<T> filter);
        Task<List<T>> GetListByFilterDefinitionAsync(FilterDefinition<T> filter);
        Task DeleteItemAsync(Expression<Func<T, bool>> predicate);
        IMongoCollection<T> Collection { get; set; }

        bool IsExist(Expression<Func<T, bool>> predicate);
        Task<bool> IsExistAsync(Expression<Func<T, bool>> predicate);
        Task<bool> UpdateAsync(string RowId, T item);
    }

    public class BaseRepository<T> : IBaseRepository<T> where T : Model.BaseCollection, new()
    {
        private string username = "";
        private string password = "";
        private string dbname = "";
        public readonly IMongoCollection<T> collection;

        public IMongoCollection<T> Collection { get; set; }

        public BaseRepository(string collectionname)
        {
            try
            {
                var client = new MongoClient($"mongodb+srv://{username}:{password}@cluster0.pjbsp.mongodb.net/{dbname}?retryWrites=true&w=majority");

                var database = client.GetDatabase(dbname);
                collection = database.GetCollection<T>(collectionname);
                Collection = collection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BaseRepository(Model.IConnectionString mongoDBConnectionString, string collectionName="")
        {
            try
            {
                if (string.IsNullOrEmpty(collectionName))
                {
                    throw new Exception("CollectionName must be declared!");
                }
                var client = new MongoClient($"{mongoDBConnectionString.ConnectionString}");
                var database = client.GetDatabase(mongoDBConnectionString.DBName);
                collection = database.GetCollection<T>(collectionName);
                Collection = collection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<T> GetList() => collection.Find(x => true).ToList();

        public async Task<List<T>> GetListAsync() => await collection.Find(x => true).ToListAsync();

        public List<T> GetListByFilter(Expression<Func<T, bool>> predicate) => Collection.Find(predicate).ToList();
        
        public async Task<List<T>> GetListByFilterAsync(Expression<Func<T, bool>> predicate) => await collection.Find(predicate).ToListAsync();

        public T GetById(string Id) => collection.Find(x => x.Id == new ObjectId(Id)).FirstOrDefault();

        public async Task<T> GetByIdAsync(string Id) => await collection.Find(x => x.Id == new ObjectId(Id)).FirstAsync();

        public void InsertItem(T item) => collection.InsertOne(item);

        public async Task InsertItemAsync(T item) => await collection.InsertOneAsync(item);

        public T GetByFilter(Expression<Func<T, bool>> predicate) => collection.Find(predicate).FirstOrDefault();

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> predicate) => await collection.Find(predicate).FirstOrDefaultAsync();

        public void DeleteItem(Expression<Func<T, bool>> predicate) => collection.DeleteOne(predicate);

        public async Task DeleteItemAsync(Expression<Func<T, bool>> predicate) => await collection.DeleteOneAsync(predicate);

        public List<T> GetListByFilterDefinition(FilterDefinition<T> filter) => collection.Find(filter).ToList();
        
        public async Task<List<T>> GetListByFilterDefinitionAsync(FilterDefinition<T> filter) => await collection.Find(filter).ToListAsync();

        public bool IsExist(Expression<Func<T, bool>> predicate) => collection.Find(predicate).Any();

        public async Task<bool> IsExistAsync(Expression<Func<T, bool>> predicate) => await collection.Find(predicate).AnyAsync();

        public async Task<bool> UpdateAsync(string RowId, T item)
        {
            try
            {
                var objId = new ObjectId(RowId);
                await collection.ReplaceOneAsync(x => x.Id == objId, item);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}