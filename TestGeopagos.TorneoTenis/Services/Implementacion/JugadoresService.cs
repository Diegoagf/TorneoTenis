using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestGeopagos.TorneoTenis.Models;
using static TestGeopagos.TorneoTenis.Models.JugadorDTO;

namespace TestGeopagos.TorneoTenis.Services.Impl
{
    public class JugadoresService : IJugadoresService
    {
        private int numero,potencia2;
        List<JugadorMasculinoDTO> IJugadoresService.SimularListaJugadoresMasculinos()
        {
           Random azar = new Random();
           numero = azar.Next(1, 5);
           potencia2 = Convert.ToInt32(Math.Pow(2, numero)); // Potencia 2
                                                                 
           List<JugadorMasculinoDTO> Jugadores;
           var JugadoresRandomM = new Faker<JugadorMasculinoDTO>()
                                         .RuleFor(j => j.Nombre, f => f.Name.FullName())
                                         .RuleFor(j => j.Habilidad, f => f.Random.Number(0, 100))
                                         .RuleFor(j => j.Fuerza, f => f.Random.Number(0, 100))
                                         .RuleFor(j => j.VelocidadDesplazamiento, f => f.Random.Number(0, 100));


            Jugadores = JugadoresRandomM.Generate(potencia2);
            return Jugadores;
        }

        List<JugadorFemeninoDTO> IJugadoresService.SimularListaJugadoresFemeninos()
        {
            Random azar = new Random();
            numero = azar.Next(1, 5);
            potencia2 = Convert.ToInt32(Math.Pow(2, numero)); // Potencia 2

            List<JugadorFemeninoDTO> Jugadores;
            var JugadoresRandomF = new Faker<JugadorFemeninoDTO>()
                                    .RuleFor(j => j.Nombre, f => f.Name.FullName())
                                    .RuleFor(j => j.Habilidad, f => f.Random.Number(0, 100))
                                    .RuleFor(j => j.TiempoReaccion, f => f.Random.Double(0.1, 10.0));

            Jugadores = JugadoresRandomF.Generate(potencia2);
            return Jugadores;
        }
    }
}
