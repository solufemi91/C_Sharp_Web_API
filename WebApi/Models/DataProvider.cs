using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace WebApi.Models
{
    public class DataProvider : IDataProvider
    {

        private readonly string connectionString = "Server=LAPTOP-G0AD0PCA\\MSSQLSERVER01;Database=HolidayDestinations;Trusted_Connection=True;";

        private SqlConnection sqlConnection;

        public async Task<IEnumerable<Destination>> GetDestinations()
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Destinations";
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<Destination>(sql);
            }
        }


        public async Task<Destination> GetDestination(int DestinationId)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM Destinations WHERE DestinationID = {DestinationId}";
                await sqlConnection.OpenAsync();
                return await sqlConnection.QuerySingleOrDefaultAsync<Destination>(sql);
            }
        }

       

        public async Task AddDestination(Destination destination)
        {
            using(sqlConnection = new SqlConnection(connectionString))
            {
                string sql = $"INSERT INTO Destinations (DestinationID, Country, City) VALUES ({destination.DestinationId}, '{destination.Country}', '{destination.City}')";
                await sqlConnection.OpenAsync();
                await sqlConnection.ExecuteAsync(sql);
            }
            
            
        }

        public async Task DeleteDestination(int destinationId)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                string sql = $"DELETE FROM Destinations WHERE DestinationID = {destinationId}";
                await sqlConnection.OpenAsync();               
                await sqlConnection.ExecuteAsync(sql);
            }

        }

     
        public async Task UpdateDestination(int id, Destination destination)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                string sql = $"UPDATE Destinations SET Country = '{destination.Country}', City = '{destination.City}' WHERE DestinationID = {id}";
                await sqlConnection.OpenAsync();            
                await sqlConnection.ExecuteAsync(sql);
            }
        }
    }
}
