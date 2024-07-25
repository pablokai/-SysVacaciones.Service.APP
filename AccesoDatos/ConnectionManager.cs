using DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace DataAccess
{
    public class ConnectionManager : IConnectionManager
    {
        public readonly IConfiguration? Configuration;

        public ConnectionManager(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(ConfigurationExtensions.GetConnectionString(Configuration, "DB_Connection"));   
        }
    }
}
