using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public interface IDataProvider
    {
        Task<IEnumerable<Destination>> GetDestinations();


        Task<Destination> GetDestination(int DestinationId);


        Task AddDestination(Destination destination);


        Task DeleteDestination(int destinationId);


        Task UpdateDestination(int id, Destination destination);

    }
}
