using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestGeopagos.TorneoTenis.Models;

namespace TestGeopagos.TorneoTenis.Repositories
{
    public class TorneoCollection : ITorneoCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<TorneoDTO> Collection;

        public TorneoCollection()
        {
            Collection = _repository.db.GetCollection<TorneoDTO>("Torneos");
        }

        public async Task ActualizarTorneo(TorneoDTO torneo) // REVISAR SI CONVIENE
        {
            var filtro = Builders<TorneoDTO>.Filter
                                            .Eq(t => t.Id, torneo.Id);
            await Collection.ReplaceOneAsync(filtro, torneo);
        }

        public async Task EliminarTorneo(string id) // REVISAR SI CONVIENE
        {
            var filtro = Builders<TorneoDTO>.Filter.Eq(t => t.Id, new ObjectId(id));
            await Collection.DeleteOneAsync(filtro);
        }

        public async Task InsertarTorneo(TorneoDTO torneo)
        {
            await Collection.InsertOneAsync(torneo);
        }

        public async Task<List<TorneoDTO>> ObtenerTodos()
        {
                return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<TorneoDTO> ObtenerTorneoPorId(string id)
        {
            return await Collection.FindAsync(
                new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }
    }
}
