using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestGeopagos.TorneoTenis.Repositories
{
    public class MongoDBContext : IMongoDBContext
    {
        private IMongoDatabase _db { get; set; }
        private MongoClient _mongoClient { get; set; }
        public IClientSessionHandle Session { get; set; }
        public IConfiguration _configuration;

        public MongoDBContext( IConfiguration _configuration)
        {
            _mongoClient = new MongoClient(_configuration.GetConnectionString("MongoDB_CNN"));
            _db = _mongoClient.GetDatabase(_configuration.GetSection("BDNames").GetSection("MongoBD").Value);

        }
        public IMongoCollection<T> GetCollection<T>(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }
            return _db.GetCollection<T>(name);
        }
    }
}
