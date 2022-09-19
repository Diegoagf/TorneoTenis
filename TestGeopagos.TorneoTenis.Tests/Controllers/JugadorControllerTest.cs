using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using TestGeopagos.TorneoTenis.Controllers;
using TestGeopagos.TorneoTenis.Models;
using TestGeopagos.TorneoTenis.Services;
using TestGeopagos.TorneoTenis.Services.Impl;
using Xunit;

namespace TestGeopagos.TorneoTenis.Tests.Controllers
{
    public class JugadorControllerTest
    {
        private readonly JugadoresController _jugadoresController;
        private readonly IJugadoresService _jugadoresService;
        public JugadorControllerTest()
        {     
            _jugadoresService = new JugadoresService();
            _jugadoresController = new JugadoresController(_jugadoresService);
        }
        [Fact]
        public void ObtenerJugadoresTest()
        {
           var responseMasculino= _jugadoresController.ObtenerJugadoresMasculino();
            var responseFemenino = _jugadoresController.ObtenerJugadoresFemenino();

            var JugadoresF = Assert.IsType<List<JugadorFemeninoDTO>>(responseFemenino.Value);

            Assert.IsType<JsonResult>(responseMasculino);
            Assert.True(JugadoresF.Count > 0);
        }
    }
}
