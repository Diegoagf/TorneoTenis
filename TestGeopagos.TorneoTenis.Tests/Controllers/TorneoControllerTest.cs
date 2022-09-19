using MongoDB.Driver;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TestGeopagos.TorneoTenis.Models;
using TestGeopagos.TorneoTenis.Repositories;
using Xunit;

namespace TestGeopagos.TorneoTenis.Tests.Controllers
{
    public class TorneoControllerTest
    {
        private Mock<IMongoCollection<TorneoDTO>> _mockCollection;
        private Mock<IMongoDBContext> _mockContext;
        private TorneoDTO _Torneo;
        public List<TorneoDTO> _list;
        public TorneosRepository _repository;
        public TorneoControllerTest()
        {
            _Torneo = new TorneoDTO
            {
                Id = new MongoDB.Bson.ObjectId(),
                Ganador_Torneo = "Nombre Test",
                Fecha_Torneo = DateTime.Now,
                Tipo_Torneo = JugadorDTO.Genero.Femenino
            };
            _mockCollection = new Mock<IMongoCollection<TorneoDTO>>();
            _mockCollection.Object.InsertOne(_Torneo);
            _mockContext = new Mock<IMongoDBContext>();

            _list = new List<TorneoDTO>();
            _list.Add(_Torneo);
             _repository = new TorneosRepository(_mockContext.Object);
        }
        //[Fact]
        //public void ObtenerTodosTest()
        //{
        //    //Mock FindSync

        //    //Mock GetCollection

        //    _mockContext.Setup(c => c.GetCollection<TorneoDTO>("Test")).Returns(_mockCollection.Object);



        //    //Act
        //    var result = _repository.ObtenerTodos();

        //    //Assert 
        //    //Lets loop only first item and assert
        //    foreach (TorneoDTO torneo in result)
        //    {
        //        Assert.NotNull(torneo);
        //        Assert.Equal(torneo.Ganador_Torneo, _Torneo.Ganador_Torneo);
        //        Assert.Equal(torneo.Tipo_Torneo, _Torneo.Tipo_Torneo);
        //        break;
        //    }

        //}
    }
}
