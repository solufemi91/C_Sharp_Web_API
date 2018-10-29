using System;
using Xunit;
using WebApi.Models;
using System.Threading.Tasks;
using System.Linq;
using FluentAssertions;

namespace WebApiTestProject
{
    public class DataProviderTests
    {
        private readonly DataProvider dataProvider = new DataProvider();

        [Fact]
        public async Task GetAllDestinationsFromDatabaseAsync()
        {
            var destinations = await dataProvider.GetDestinations();
            destinations.Count().Should().Be(7, "this is the amount of records in the database's table");
        }

        [Fact]
        public async Task VerifyingThatTheCountryColumnDoesNotContainAnyBlanks()
        {
            var destinations = await dataProvider.GetDestinations();
            destinations.All(d => d.Country != null).Should().BeTrue("the country column should not be blank");          
        }

        [Fact]
        public async Task VerifyingGetDestinationByIdReturnsTheCorrectObject()
        {
            var destination = await dataProvider.GetDestination(3);
            destination.DestinationId.Should().Be(3, "this is the number that was supplied as an argument");
            destination.City.Should().Be("Liverpool", "this is the city that corresponds with the number that was supplied as an argument");
        }

        [Fact]
        public async Task AddANewDestination()
        {
            Destination destination = new Destination();
            destination.DestinationId = 100;
            destination.Country = "Legoland";
            destination.City = "Block City";
            await dataProvider.AddDestination(destination);
            await dataProvider.GetDestination(100);
            destination.DestinationId.Should().Be(100, "this is the number that was supplied as an argument");
            destination.Country.Should().Be("Legoland", "this is the country that was supplied as an argument");
        }


    }
}
