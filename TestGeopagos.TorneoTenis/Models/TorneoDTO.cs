using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static TestGeopagos.TorneoTenis.Models.JugadorDTO;

namespace TestGeopagos.TorneoTenis.Models
{
    public class TorneoDTO
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Ganador_Torneo { get; set; }
        public DateTime Fecha_Torneo { get; set; }
        public Genero Tipo_Torneo { get; set; }
    }
}
