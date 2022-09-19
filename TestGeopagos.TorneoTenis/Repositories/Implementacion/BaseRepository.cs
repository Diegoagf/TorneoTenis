using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestGeopagos.TorneoTenis.Models;
using static TestGeopagos.TorneoTenis.Models.JugadorDTO;

namespace TestGeopagos.TorneoTenis.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly IMongoDBContext _mongoContext;
        protected IMongoCollection<TEntity> Collection;

        protected BaseRepository(IMongoDBContext context)
        {
            _mongoContext = context;
            Collection = _mongoContext.GetCollection<TEntity>("Torneos");
        }
        public async Task Eliminar(string id) // EXTRA
        {
            var objectId = new ObjectId(id);
            await Collection.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", objectId));
        }

        public async Task Insertar(TEntity torneo)
        {
            await Collection.InsertOneAsync(torneo);
        }

        public async Task<IEnumerable<TEntity>> ObtenerTodos()
        {
            var all =  Collection.FindAsync(Builders<TEntity>.Filter.Empty);
            return await all.Result.ToListAsync();
            
        }
        public async Task<IEnumerable<TEntity>> ObtenerPorId(string id)
        {
            var objectId = new ObjectId(id);
            return (IEnumerable<TEntity>)await Collection.FindAsync(Builders<TEntity>.Filter.Eq("_id", objectId)).Result.FirstOrDefaultAsync();
        }
    }
}
