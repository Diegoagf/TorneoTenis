using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestGeopagos.TorneoTenis.Models;
using static TestGeopagos.TorneoTenis.Models.JugadorDTO;

namespace TestGeopagos.TorneoTenis.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task Insertar(TEntity torneo);
        //Task<List<TorneoDTO>> ObtenerTorneoPorGenero(Genero sexo);
        //Task<List<TorneoDTO>> ObtenerTorneoPorFecha(DateTime fecha);
        Task Eliminar(string id); // Extra
        Task<IEnumerable<TEntity>>ObtenerTodos();
        //Task<TorneoDTO> ObtenerTorneoPorId(string id);
    }
}
