using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestGeopagos.TorneoTenis.Models;

namespace TestGeopagos.TorneoTenis.Services
{
    public interface ISimularTorneoService
    {
        public JugadorMasculinoDTO SimularTorneoMasculino(List<JugadorMasculinoDTO> jugadores);
        public JugadorFemeninoDTO SimularTorneoFemenino(List<JugadorFemeninoDTO> jugadores);
    }
}
