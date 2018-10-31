using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Controllers
{

    public interface IDestinationsController
    {


        [HttpGet]
        Task<IEnumerable<Destination>> Get();



        [HttpGet("{id}")]
        Task<Destination> Get(int id);


        [HttpPost]
        Task Post([FromBody]Destination destination);


        [HttpDelete("{id}")]
        Task Delete(int id);


        [HttpPut("{id}")]
        Task Put(int id, [FromBody]Destination destination);

    }
}
