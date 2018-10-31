using System;
using Xunit;
using WebApi.Models;
using System.Threading.Tasks;
using System.Linq;
using FluentAssertions;
using Moq;
using System.Collections.Generic;

namespace WebApiTestProject
{
    public class DataProviderTests
    {


        [Fact]

        public void TestingGetDestinationsMethodReturnsACollectionOfDestinationObjects()
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

            var mock = new Mock<IDataProvider>();
            mock.Setup(x => x.GetDestinations()).ReturnsAsync(destinations.AsEnumerable());
        }


        [Fact]

        public void TestingGetDestinationMethodReturnsASingleDestinationObject()
        {

            var destination = new Destination
            {
                DestinationId = 3,
                Country = "Spain",
                City = "Madrid"
            };

            var mock = new Mock<IDataProvider>();
            mock.Setup(x => x.GetDestination(3)).ReturnsAsync(destination);
        }


    }
}
