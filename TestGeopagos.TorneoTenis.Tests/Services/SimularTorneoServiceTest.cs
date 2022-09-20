using MongoDB.Driver;
using Moq;
using System;
using System.Collections.Generic;
using TestGeopagos.TorneoTenis.Models;
using TestGeopagos.TorneoTenis.Repositories;
using TestGeopagos.TorneoTenis.Services;
using TestGeopagos.TorneoTenis.Services.Impl;
using Xunit;

namespace TestGeopagos.TorneoTenis.Tests
{
    public class SimularTorneoServiceTest
    {
        private readonly IJugadoresService _jugadoresService;
        private readonly ISimularTorneoService _TorneoService;
        SimularTorneoService service;
        public SimularTorneoServiceTest( )
        {
            _jugadoresService = new JugadoresService();
            _TorneoService = new SimularTorneoService();
        }

        [Fact]
        public void SimularJuegoTest()
        {

            //Arrange
            service = new SimularTorneoService();
            JugadorMasculinoDTO jugadorM1 = new JugadorMasculinoDTO();
            jugadorM1.Nombre = "Test";
            jugadorM1.Habilidad = 78;
            jugadorM1.Fuerza = 90;
            jugadorM1.VelocidadDesplazamiento = 21;
            JugadorMasculinoDTO jugadorM2 = new JugadorMasculinoDTO();
            jugadorM2.Nombre = "Prueba";
            jugadorM2.Habilidad = 70;
            jugadorM2.Fuerza = 91;
            jugadorM2.VelocidadDesplazamiento = 45;

            JugadorFemeninoDTO jugadorF1 = new JugadorFemeninoDTO();
            jugadorF1.Nombre = "Test";
            jugadorF1.Habilidad = 78;
            jugadorF1.TiempoReaccion = 2.5;
            JugadorFemeninoDTO jugadorF2 = new JugadorFemeninoDTO();
            jugadorF2.Nombre = "Prueba";
            jugadorF2.Habilidad = 70;
            jugadorF2.TiempoReaccion = 20.12;

            //Act
            JugadorMasculinoDTO PerdedorM = service.SimularJuego(jugadorM1, jugadorM2);
            JugadorFemeninoDTO PerdedorF = service.SimularJuego(jugadorF1, jugadorF2);
            //Assert
            Assert.IsType<JugadorMasculinoDTO>( PerdedorM);
            Assert.IsType<JugadorFemeninoDTO>(PerdedorF);
        }

        [Fact]
        public void SimularTorneoMasculinoTest()
        {

            //Arrange
            List< JugadorMasculinoDTO> ListaHombres= _jugadoresService.SimularListaJugadoresMasculinos();

            //Act
            JugadorMasculinoDTO Ganador = _TorneoService.SimularTorneoMasculino(ListaHombres);
            //Assert
            Assert.Contains(Ganador, ListaHombres);
        }
        [Fact]
        public void SimularTorneoFemeninoTest()
        {

            //Arrange
            List<JugadorFemeninoDTO> ListaMujeres = _jugadoresService.SimularListaJugadoresFemeninos();

            //Act
            JugadorFemeninoDTO Ganador = _TorneoService.SimularTorneoFemenino(ListaMujeres);
            //Assert
            Assert.Contains(Ganador, ListaMujeres);
        }
    }
}
