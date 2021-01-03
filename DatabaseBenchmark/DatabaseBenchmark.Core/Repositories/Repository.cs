using DatabaseBenchmark.Core.DbConnection;
using MongoDB.Driver;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseBenchmark.Core.Repositories
{
    public class Repository<T> : IRepository<T>
    {
        private MongoDbConnection _connection;
        private string _table;
        public Repository(string Table, MongoDbConnection connection)
        {
            _connection = connection;
            _table = Table;
        }

        public void Insert(List<T> entity)
        {
            var collection = _connection.db.GetCollection<T>(_table);
            try
            {
                collection.InsertMany(entity);
            }
            catch(Exception ex)
            {
                throw new Exception("Insert Data : " + ex.Message);
            }
        }

        public T GetObject(string id)
        {
            var collection = _connection.db.GetCollection<T>(_table);
            var filter = Builders<T>.Filter.Eq("Id", id);
            try
            {
                var result = collection.Find(filter).FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Get Data : " + ex.Message);
            }
        }

    }
}
