using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestGeopagos.TorneoTenis.Models;

namespace TestGeopagos.TorneoTenis.Repositories
{
    public interface ITorneoCollection
    {
        Task InsertarTorneo(TorneoDTO torneo);
        Task ActualizarTorneo(TorneoDTO torneo); // REVISAR SI CONVIENE
        Task EliminarTorneo(string id); // REVISAR SI CONVIENE
        Task<List<TorneoDTO>> ObtenerTodos();
        Task<TorneoDTO> ObtenerTorneoPorId(string id);

    }
}
