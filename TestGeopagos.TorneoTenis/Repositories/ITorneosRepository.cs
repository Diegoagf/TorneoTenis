using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestGeopagos.TorneoTenis.Models;
using static TestGeopagos.TorneoTenis.Models.JugadorDTO;

namespace TestGeopagos.TorneoTenis.Repositories
{
    public interface ITorneosRepository: IBaseRepository<TorneoDTO>
    {
        Task<List<TorneoDTO>> ObtenerTorneoPorGenero(Genero sexo);
        Task<List<TorneoDTO>> ObtenerTorneoPorFecha(DateTime fecha);
    }
}
