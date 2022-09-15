using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static TestGeopagos.TorneoTenis.Models.JugadorDTO;

namespace TestGeopagos.TorneoTenis.Models
{
    public class ResponseTorneoDTO
    {
        public string Tipo_Torneo { get; set; }
        public TorneoDTO Torneo_Realizado { get; set;}

        public ResponseTorneoDTO(string Tipo_Torneo, TorneoDTO Torneo_Realizado)
        {
            this.Tipo_Torneo = Tipo_Torneo;
            this.Torneo_Realizado = Torneo_Realizado;
        }

    }


}
