using AutoFixture;
using Locator.Business.Interface;
using Locator.Business.Service;
using Locator.Data.Context;
using Locator.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locator.Tests.Unit
{
    public class CarServiceTests
    {
        
        [Fact]
        public async Task GetListCars_ListCars_ReturnsAListAsync()
        {
            // Arrange
            var _fixture = new Fixture();

            // client has a circular reference from AutoFixture point of view
            _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var carsFixtureList = _fixture.Create<List<Car>>();
            //Mock do contexto
            var carsContextMock = new Mock<DataBaseContext>();
            carsContextMock.Setup(x => x.Cars)
                .ReturnsDbSet(carsFixtureList);
            //chamar o serviço
            var carService = new CarService(carsContextMock.Object);
            var carList = (await carService.GetListCars());
            //Assert
            Assert.NotNull(carList);
            Assert.Equal(carsFixtureList.Count(), carList.Count());

        }
    }
}
