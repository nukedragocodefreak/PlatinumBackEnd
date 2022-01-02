using CCA.DAL.Data;
using Microsoft.Extensions.Configuration;
using PE.BO.Enums;
using System.Data;
using System.Data.SqlClient;

namespace PE.DAL.Data
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly IConfiguration _configuration;

        public DbContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }

        public dynamic GetMyConnection(ORM connectionType)
        {
            return connectionType switch
            {
                ORM.EFCore => null,
                // Below commented out for now, You would be able to plug in EF if needs be
                // When an EF connection / context is present then below code will assist to connect to it
                // {
                //     var optionsBuilder = new DbContextOptionsBuilder<yourDbContext>();
                //     optionsBuilder.UseSqlServer(_config.GetConnectionString(Databases.yourDbConnection.ToString()));
                //     _yourDbContextContext = new yourDbContextContext(optionsBuilder.Options);
                // }
                ORM.Dapper => GetConnection(_configuration.GetConnectionString("PaymentProcessingDB")),
                _ => null,
            };
        }
    }
}
