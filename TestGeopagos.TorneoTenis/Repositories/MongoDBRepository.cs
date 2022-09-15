using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestGeopagos.TorneoTenis.Repositories
{
    public class MongoDBRepository
    {
        public MongoClient client;

        public IMongoDatabase db;
         
        public MongoDBRepository()
        {
            MongoClient client = new MongoClient("mongodb+srv://diegoagf:fjCGhZcSxkEG2Qqw@miclustertorneotenis.142dota.mongodb.net/Torneos");
            db = client.GetDatabase("TorneosDB");
        }



    }
}
