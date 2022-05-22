using ASPTest.Controllers;
using ASPTest.Models;
using ASPTest.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;

namespace ASPUnitTest
{
    public class BeerTesting
    {
        private readonly BeerController _beerController;
        private readonly IBeerService _beerService;

        public BeerTesting()
        {
            _beerService = new BeerService();
            _beerController = new BeerController(_beerService);
        }
        [Fact]
        public void Get_OK()
        {
            //planeacion
            //ejecucion
            //resultados
            var result = _beerController.Get();

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Get_Quantity()
        {
            var result = (OkObjectResult)_beerController.Get();
            var beers = Assert.IsType<List<Beer>>(result.Value);
            Assert.True(beers.Count > 0);
        }

        [Fact]
        public void GetById_Ok()
        {
            //preparacion
            int id = 1;

            //ejecucion
            var result = _beerController.GetById(id);

            //hechos o resultados
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetById_Exists()
        {
            //Arrange
            int id = 1;

            //Act
            var result = (OkObjectResult)_beerController.GetById(id);

            //Assert
                //Evaluamos el tipo
            var beer = Assert.IsType<Beer>(result?.Value);
                //Evaluamos que exista con un booleano
            Assert.True(beer != null);
                //Evaluamos que el dato que enviamos sea el que se requiere
            Assert.Equal(beer?.Id ,id);
        }

        [Fact]
        public void GetById_NotFound()
        {
            //Arrange
            int id = 11;

            //Act
            var result = _beerController.GetById(id);

            //Assert
             
            var beer = Assert.IsType<NotFoundResult>(result);

            
             
        }
    }
}
