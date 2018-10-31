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
        private IDataProvider _dataProvider;

        public DestinationsController(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }


        [HttpGet]
        public async Task<IEnumerable<Destination>> Get()
        {
            
            return await _dataProvider.GetDestinations();
            
        }


        [HttpGet("{id}")]
        public async Task<Destination> Get(int id)
        {
            return await _dataProvider.GetDestination(id);
        }

        [HttpPost]
        public async Task Post([FromBody]Destination destination)
        {
            await _dataProvider.AddDestination(destination);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _dataProvider.DeleteDestination(id);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]Destination destination)
        {
            await _dataProvider.UpdateDestination(id,destination);
        }

    }
}
