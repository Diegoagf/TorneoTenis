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
        Task Eliminar(string id); // Extra
        Task<IEnumerable<TEntity>>ObtenerTodos();
    }
}
