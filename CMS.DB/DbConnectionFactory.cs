using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
namespace CMSDB
{
    public class DbConnectionFactory : IConnectionFactory
    {

        private readonly DbProviderFactory _provider;
        private readonly string _connectionString;
        private readonly string _name;

        public DbConnectionFactory(string connectionName)
        {

            _connectionString = connectionName;

        }

        public IDbConnection Create()
        {
            DbConnection connection = new System.Data.SqlClient.SqlConnection();

            connection.ConnectionString = _connectionString;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            return connection;
        }
    }
}
