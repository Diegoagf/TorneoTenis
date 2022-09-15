using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestGeopagos.TorneoTenis.Models;

namespace TestGeopagos.TorneoTenis.Services
{
    public interface IJugadoresService
    {
        public List<JugadorMasculinoDTO> SimularListaJugadoresMasculinos();
        public List<JugadorFemeninoDTO> SimularListaJugadoresFemeninos();
    }
}
