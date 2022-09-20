using Bogus;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGeopagos.TorneoTenis.Controllers;
using TestGeopagos.TorneoTenis.Models;
using TestGeopagos.TorneoTenis.Repositories;
using TestGeopagos.TorneoTenis.Services;
using TestGeopagos.TorneoTenis.Services.Impl;
using Xunit;
using static TestGeopagos.TorneoTenis.Models.JugadorDTO;

namespace TestGeopagos.TorneoTenis.Tests.Controllers
{
    public class MongoDBContextTests
    {
        private readonly TorneoController _TorneoController;
        private ITorneoCollection _db;
        private readonly ISimularTorneoService _simularTorneo;
        private Mock<IOptions<Mongosettings>> _mockOptions;
        private Mock<IMongoDatabase> _mockDB;
        private Mock<IMongoClient> _mockClient;
        public MongoDBContextTests()
        {
            _mockOptions = new Mock<IOptions<Mongosettings>>();
            _mockDB = new Mock<IMongoDatabase>();
            _mockClient = new Mock<IMongoClient>();
        }

        private IEnumerable<List<TorneoDTO>> ObtenerDataPrueba()
        {
            List<TorneoDTO> Torneos;
            var Tor = new Faker<TorneoDTO>()
                                          .RuleFor(j => j.Fecha_Torneo, f => f.Date.Recent())
                                          .RuleFor(j => j.Id, f => new ObjectId())
                                          .RuleFor(j => j.Tipo_Torneo, f => f.PickRandom<Genero>())
                                          .RuleFor(j => j.Ganador_Torneo, f => f.Name.FullName());
     
            Torneos = Tor.Generate(8);
            return (IEnumerable<List<TorneoDTO>>)Torneos;
        }

        [Fact]
        public void MongoBookDBContext_Constructor_Success()
        {
            var settings = new Mongosettings()
            {
                ConnectionString  = "mongodb://tes123 ",
                DatabaseName = "TestDB"
            };

            _mockOptions.Setup(s => s.Value).Returns(settings);
            _mockClient.Setup(c => c
            .GetDatabase(_mockOptions.Object.Value.DatabaseName, null))
                .Returns(_mockDB.Object);

            //Act 
            var context = new MongoDBContext(_mockOptions.Object);

            //Assert 
            Assert.NotNull(context);
        }

        [Fact]
        public void MongoBookDBContext_GetCollection_NameEmpty_Failure()
        {

            //Arrange
            var settings = new Mongosettings()
            {
                ConnectionString = "mongodb://tes123",
                DatabaseName = "TestDB"
            };

            _mockOptions.Setup(s => s.Value).Returns(settings);
            _mockClient.Setup(c => c
            .GetDatabase(_mockOptions.Object.Value.DatabaseName, null))
                .Returns(_mockDB.Object);

            //Act 
            var context = new MongoDBContext(_mockOptions.Object);
            var myCollection = context.GetCollection<TorneoDTO>("");

            //Assert 
            Assert.Null(myCollection);

        }

        [Fact]
        public void MongoBookDBContext_GetCollection_ValidName_Success()
        {
            //Arrange
            var settings = new Mongosettings()
            {
                ConnectionString = "mongodb://tes123 ",
                DatabaseName = "TestDB"
            };

            _mockOptions.Setup(s => s.Value).Returns(settings);

            _mockClient.Setup(c => c.GetDatabase(_mockOptions.Object.Value.DatabaseName, null)).Returns(_mockDB.Object);

            //Act 
            var context = new MongoDBContext(_mockOptions.Object);
            var myCollection = context.GetCollection<TorneoDTO>("Torneo");

            //Assert 
            Assert.NotNull(myCollection);
        }
        //public TorneoControllerTest()
        //{
        //    _db = new TorneoCollection();
        //    _simularTorneo = new SimularTorneoService();
        //    _TorneoController = new TorneoController(_simularTorneo,_db);
        //}
        //public void ObtenerTodosTest()
        //{
        //    var MockRepository = CrearContexto();
        //    var MockCollection = new Mock<IMongoCollection<TorneoDTO>>();
        //}
    }
}
