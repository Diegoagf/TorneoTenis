using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestGeopagos.TorneoTenis.Models;
using static TestGeopagos.TorneoTenis.Models.JugadorDTO;

namespace TestGeopagos.TorneoTenis.Helpers
{
    public class Helper
    {
        internal static ResponseTorneoDTO ArmarRespuesta(JugadorDTO GanadorTorneo, Genero genero)
        {
            string TipoTorneo;
            if (genero == Genero.Masculino)
            {
                TipoTorneo = "Masculino";
            }
            else
            {
                TipoTorneo = "Femenino";
            }
            TorneoDTO torneo = new TorneoDTO();
            torneo.Tipo_Torneo = genero;
            torneo.Ganador_Torneo = GanadorTorneo.Nombre;
            torneo.Fecha_Torneo = DateTime.Now;
            //torneo.Id = ObjectId.GenerateNewId();
            ResponseTorneoDTO responseTorneo = new ResponseTorneoDTO(TipoTorneo, torneo);
            
            return responseTorneo;
        }
    }
}
