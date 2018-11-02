using System;
using Xunit;
using WebApi.Controllers;
using System.Threading.Tasks;
using System.Linq;
using FluentAssertions;
using WebApi.Models;
using Moq;
using System.Collections.Generic;

namespace WebApiTestProject
{
    public class DestinationsControllerTests
    {
        [Fact]

        public async Task TestGetMethodReturnsCollectionOfDestinationObjectsAsync()
        {
            var destinations = new List<Destination>
            {
               new Destination
               {
                   DestinationId = 1,
                   Country = "England",
                   City = "London"
               },

               new Destination
               {
                   DestinationId = 2 ,
                   Country = "England",
                   City = "Manchester"
               },

               new Destination
               {
                   DestinationId = 3 ,
                   Country = "Spain",
                   City = "Madrid"
               },

               new Destination
               {
                   DestinationId = 4 ,
                   Country = "France",
                   City = "Paris"
               }
            };

            var expectedResult = new List<Destination>
            {
               new Destination
               {
                   DestinationId = 1,
                   Country = "England",
                   City = "London"
               },

               new Destination
               {
                   DestinationId = 2 ,
                   Country = "England",
                   City = "Manchester"
               },

               new Destination
               {
                   DestinationId = 3 ,
                   Country = "Spain",
                   City = "Madrid"
               },

               new Destination
               {
                   DestinationId = 4 ,
                   Country = "France",
                   City = "Paris"
               }
            };

            var mock = new Mock<IDataProvider>();
            mock.Setup(x => x.GetDestinations()).ReturnsAsync(destinations.AsEnumerable());

            var destinationsController = new DestinationsController(mock.Object);

            var collectionOfDestinations = await destinationsController.Get();
                
            collectionOfDestinations.Should().BeEquivalentTo(expectedResult.AsEnumerable(), "this is the list of destinations from the database");

        }


        [Fact]

        public async Task TestParameterisedGetMethodReturnsADestinationObjectsAsync()
        {

            var destination = new Destination
            {
                DestinationId = 1,
                Country = "England",
                City = "London"
            };

            var expectedResult = new Destination
            {
                DestinationId = 1,
                Country = "England",
                City = "London"
            };




            var mock = new Mock<IDataProvider>();
            mock.Setup(x => x.GetDestination(1)).ReturnsAsync(destination);

            var destinationsController = new DestinationsController(mock.Object);

            var destinationObject = await destinationsController.Get(1);

            destinationObject.Should().BeEquivalentTo(expectedResult, "this is the list of destinations from the database");

        }



    }
}
