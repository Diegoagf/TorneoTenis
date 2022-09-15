using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestGeopagos.TorneoTenis.Models;

namespace TestGeopagos.TorneoTenis.Services.Impl
{
    public class SimularTorneoService : ISimularTorneoService
    {

        JugadorFemeninoDTO ISimularTorneoService.SimularTorneoFemenino(List<JugadorFemeninoDTO> jugadores)
        {
            while (jugadores.Count != 1)
            {
                JugadorFemeninoDTO Perdedor = SimularJuego(jugadores.First(), jugadores.Last());
                jugadores.Remove(Perdedor);
            }
            return jugadores.FirstOrDefault();
        }

        JugadorMasculinoDTO ISimularTorneoService.SimularTorneoMasculino(List<JugadorMasculinoDTO> jugadores)
        {
           
            while (jugadores.Count!=1)
            {
                JugadorMasculinoDTO Perdedor = SimularJuego(jugadores.First(), jugadores.Last());
                jugadores.Remove(Perdedor);
            }
            return jugadores.FirstOrDefault();
        }

        public JugadorMasculinoDTO SimularJuego(JugadorMasculinoDTO jug1, JugadorMasculinoDTO jug2)
        {
            int ScorePlayer1, ScorePlayer2;
            Random azar = new Random();
            ScorePlayer1 = jug1.Habilidad + jug1.Fuerza + jug1.VelocidadDesplazamiento + azar.Next(0, 100);
            ScorePlayer2 = jug2.Habilidad + jug2.Fuerza  + jug2.VelocidadDesplazamiento + azar.Next(0, 100);
            if (ScorePlayer1 < ScorePlayer2)
            {
                return jug1; // Perdio el Jug1
            }
            else if(ScorePlayer1 == ScorePlayer2) // Si estan empatados entonces se deja a la suerte el ganador
            {
                if (azar.NextDouble() > 0.5)
                {
                    return jug2;
                }
                else
                {
                    return jug1;
                }

            }
            else
            {
                return jug2; //Perdio el jug2
            }

        }

        public JugadorFemeninoDTO SimularJuego(JugadorFemeninoDTO jug1, JugadorFemeninoDTO jug2)
        {
            int ScorePlayer1, ScorePlayer2;
            Random azar = new Random();

            int RedondTiempoJug1 = (int)Math.Round(jug1.TiempoReaccion);
            int RedondTiempoJug2 = (int)Math.Round(jug2.TiempoReaccion);

            ScorePlayer1 = jug1.Habilidad + azar.Next(0, 100) - RedondTiempoJug1;
            ScorePlayer2 = jug2.Habilidad + azar.Next(0, 100) - RedondTiempoJug2;
            if (ScorePlayer1 < ScorePlayer2)
            {
                return jug1; // Perdio el Jug1
            }
            else if (ScorePlayer1 == ScorePlayer2) // Si estan empatados entonces se deja a la suerte el ganador
            {
                if (azar.NextDouble() > 0.5)
                {
                    return jug2;
                }
                else
                {
                    return jug1;
                }

            }
            else
            {
                return jug2; //Perdio el jug2
            }

        }

    }
}
