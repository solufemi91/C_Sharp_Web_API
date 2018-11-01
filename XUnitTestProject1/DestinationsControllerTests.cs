using System;
using Xunit;
using WebApi.Controllers;
using System.Threading.Tasks;
using System.Linq;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using Moq;
using System.Collections.Generic;

namespace WebApiTestProject
{
    public class DestinationsControllerTests
    {
        [Fact]

        public void TestGetMethodReturnsCollectionOfDestinationObjects()
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

            var mock = new Mock<IDestinationsController>();
            mock.Setup(x => x.Get()).ReturnsAsync(destinations.AsEnumerable());
        }

      

    }
}
