using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevSpace_DataAccessLayer.Repositories
{
    public class MongoDBRepository
    {
        public MongoClient client;
        public IMongoDatabase database;

        public MongoDBRepository()
        {
            client = new MongoClient("mongodb://localhost:27017/DevSpace");
            database = client.GetDatabase("Unity");
        }
    }
}