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
    public class TorneosRepository: BaseRepository<TorneoDTO>, ITorneosRepository
    {
        public TorneosRepository(IMongoDBContext context) : base(context)
        {
           
        }

        public async Task<List<TorneoDTO>> ObtenerTorneoPorFecha(DateTime fecha)
        {
            var filtro = Builders<TorneoDTO>.Filter.Eq(t => t.Fecha_Torneo, fecha);
            return await Collection.FindAsync(filtro).Result.ToListAsync();
        }

        public async Task<List<TorneoDTO>> ObtenerTorneoPorGenero(Genero sexo)
        {
            var filtro = Builders<TorneoDTO>.Filter.Eq(t => t.Tipo_Torneo, sexo);
            return await Collection.FindAsync(filtro).Result.ToListAsync();
        }
       
    }
}
