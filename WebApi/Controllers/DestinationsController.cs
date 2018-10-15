using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class DestinationsController :Controller
    {
        private DataProvider dataProvider;

        public DestinationsController(DataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }

        [HttpGet]
        public async Task<IEnumerable<Destination>> Get()
        {
            return await dataProvider.GetDestinations();
        }

        [HttpGet("{id}")]
        public async Task<Destination> Get(int id)
        {
            return await dataProvider.GetDestination(id);
        }

        [HttpPost]
        public async Task Post([FromBody]Destination destination)
        {
            await dataProvider.AddDestination(destination);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await dataProvider.DeleteDestination(id);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]Destination destination)
        {
            await dataProvider.UpdateDestination(id,destination);
        }

    }
}
