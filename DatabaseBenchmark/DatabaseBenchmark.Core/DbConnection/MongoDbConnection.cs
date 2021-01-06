using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseBenchmark.Core.DbConnection
{
    public class MongoDbConnection
    {
        public string DatabaseName = "Db_Benchamark";
        public IMongoDatabase db;

        public MongoDbConnection()
        {
            var client = new MongoClient("mongodb://oslAdmin:DevOps.osl01@192.168.2.57:27017/?authSource=admin");
            db = client.GetDatabase(DatabaseName);
        }
    }
}
