using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesAmerica.Domain.Contracts;

namespace TesAmerica.Infrastructure.DbConnections
{
    public class SqlServerConnection : IDbConnection<SqlConnection, SqlTransaction>
    {
        private readonly SqlConnection _connection;

        public SqlServerConnection(IConfigurationSection section)
        {
            var connectionString = section.GetSection("SqlServer").Value;
            _connection = new SqlConnection(connectionString);
        }

        public void Open()
        {
            _connection.Open();
        }

        public void Close()
        {
            _connection.Close();
        }

        public SqlConnection GetConnection()
        {
            return _connection;
        }

        public SqlTransaction BeginTransaction()
        {
            return _connection.BeginTransaction();
        }
    }
}
