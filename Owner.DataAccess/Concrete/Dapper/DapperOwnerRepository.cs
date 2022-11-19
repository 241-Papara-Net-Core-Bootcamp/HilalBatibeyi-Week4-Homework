using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Owner.API.Model;
using Owner.DataAccess.Abstract;
using Owner.DataAccess.Context;
using Owner.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Owner.DataAccess.Concrete.Dapper
{
    public class DapperOwnwerRepository : IOwnerRepository
    {
        private readonly IConfiguration _configuration;

        public DapperOwnwerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> AddAsync(OwnerModel ownerModel)
        {
            var query = "Insert into Owners (Name, LastName, Date, Description, Type) VALUES (@Name, @LastName, @Date, @Description, @Type)";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("SqlConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(query, ownerModel);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var query = "DELETE FROM Owners WHERE Id = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("SqlConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(query, new { Id = id });
                return result;
            }
        }

        public async Task<List<OwnerModel>> GetAllAsync()
        {
            var query = "SELECT * FROM Owners";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("SqlConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<OwnerModel>(query);
                return result.ToList();
            }
        }

        public async Task<OwnerModel> GetAsync(int id)
        {
            var query = "Select * From Owners WHERE Id = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("SqlConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<OwnerModel>(query, new { Id = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(OwnerModel ownerModel)
        {
            var query = "UPDATE Owners SET Name = @Name, LastName = @LastName, Date = @Date, Description = @Description, Type = @Type   WHERE Id = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("SqlConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(query, ownerModel);
                return result;
            }
        }
    }
}
