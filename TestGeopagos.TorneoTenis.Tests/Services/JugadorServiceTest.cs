using System;
using System.Collections.Generic;
using System.Text;
using TestGeopagos.TorneoTenis.Models;
using TestGeopagos.TorneoTenis.Services;
using TestGeopagos.TorneoTenis.Services.Impl;
using Xunit;

namespace TestGeopagos.TorneoTenis.Tests.Services
{
    public class JugadorServiceTest
    {
         private readonly IJugadoresService _jugadoresService;
        public JugadorServiceTest()
        {
            _jugadoresService = new JugadoresService();
        }
        [Fact]
        public void SimularListaJugadoresMasculinosTest()
        {
            List<JugadorMasculinoDTO> DataSimulated= _jugadoresService.SimularListaJugadoresMasculinos();
            
            Assert.True(EsPotenciaDe2(DataSimulated.Count));
            Assert.IsType<List<JugadorMasculinoDTO>>(DataSimulated);

        }

        [Fact]
        public void SimularListaJugadoresFemeninoTest()
        {
            List<JugadorFemeninoDTO> DataSimulated = _jugadoresService.SimularListaJugadoresFemeninos();

            Assert.True(EsPotenciaDe2(DataSimulated.Count));
            Assert.IsType<List<JugadorFemeninoDTO>>(DataSimulated);

        }

        private bool EsPotenciaDe2(int numero)
        {
            return ((numero != 0) && ((numero & (numero - 1)) == 0));
        }
    }
}
