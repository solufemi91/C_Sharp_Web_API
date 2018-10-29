using System;
using Xunit;
using WebApi.Controllers;
using System.Threading.Tasks;
using System.Linq;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApiTestProject
{
    public class DestinationsControllerTests
    {

        DataProvider _dataProvider = new DataProvider();

        [Fact]
        public async Task test()
        {
            ContentResult contentResult = new ContentResult();
            var dest = new DestinationsController(_dataProvider);
            await dest.Get();
            contentResult.Content = _dataProvider.GetDestinations().ToString();
            var statusCode = contentResult.StatusCode;
        }

    }
}
