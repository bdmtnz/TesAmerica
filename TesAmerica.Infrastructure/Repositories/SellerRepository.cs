using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TesAmerica.Domain;
using TesAmerica.Domain.Contracts;

namespace TesAmerica.Infrastructure.Repositories
{
    public class SellerRepository : IGenericRepository<Seller>
    {
        private readonly SqlConnection _connection;

        public SellerRepository(SqlConnection connection) {
            _connection = connection;
        }

        public void Add(Seller entity)
        {
            var cmdBuilder = new StringBuilder();
            cmdBuilder.AppendLine("INSERT INTO VENDEDOR VALUES");
            cmdBuilder.AppendLine("(");
            cmdBuilder.AppendLine($"    '{entity.Id}', ");
            cmdBuilder.AppendLine($"    '{entity.Name}', ");
            cmdBuilder.AppendLine($"    '{entity.State}' ");
            cmdBuilder.AppendLine(")");
            using (var cmd = new SqlCommand(cmdBuilder.ToString(), _connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public ICollection<Seller> FindByForeignKey(string foreignkey)
        {
            ICollection<Seller> result = new List<Seller>();
            var cmdBuilder = new StringBuilder();
            cmdBuilder.AppendLine("SELECT");
            cmdBuilder.AppendLine(" * ");
            cmdBuilder.AppendLine("FROM VENDEDOR");
            cmdBuilder.AppendLine($"WHERE NOMBRE LIKE '%{foreignkey}%' AND ESTADO = 'Activo'");
            using (var cmd = new SqlCommand(cmdBuilder.ToString(), _connection))
            {
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var department = new Seller
                    {
                        Id = $"{reader["CODVEND"]}",
                        Name = $"{reader["NOMBRE"]}",
                        State = $"{reader["ESTADO"]}"
                    };
                    result.Add(department);
                }
            }
            return result;
        }

        public Seller? FindByKey(string key)
        {
            Seller? result = default;
            var cmdBuilder = new StringBuilder();
            cmdBuilder.AppendLine("SELECT TOP(1)");
            cmdBuilder.AppendLine(" * ");
            cmdBuilder.AppendLine("FROM VENDEDOR");
            cmdBuilder.AppendLine($"WHERE CODVEND = '{key}'");
            using (var cmd = new SqlCommand(cmdBuilder.ToString(), _connection))
            {
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result = new Seller
                    {
                        Id = $"{reader["CODVEND"]}",
                        Name = $"{reader["NOMBRE"]}",
                        State = $"{reader["ESTADO"]}"
                    };
                }
            }
            return result;
        }

        public ICollection<Seller> GetAll()
        {
            ICollection<Seller> result = new List<Seller>();
            var cmdBuilder = new StringBuilder();
            cmdBuilder.AppendLine("SELECT");
            cmdBuilder.AppendLine(" * ");
            cmdBuilder.AppendLine("FROM VENDEDOR");
            using(var cmd = new SqlCommand(cmdBuilder.ToString(), _connection))
            {
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var department = new Seller
                    {
                        Id = $"{reader["CODVEND"]}",
                        Name = $"{reader["NOMBRE"]}",
                        State = $"{reader["ESTADO"]}"
                    };
                    result.Add(department);
                }
            }
            return result;
        }

        public void Update(Seller entity)
        {
            var cmdBuilder = new StringBuilder();
            cmdBuilder.AppendLine("UPDATE VENDEDOR");
            cmdBuilder.AppendLine("SET");
            cmdBuilder.AppendLine($"    NOMBRE = '{entity.Name}', ");
            cmdBuilder.AppendLine($"    ESTADO = '{entity.State}' ");
            cmdBuilder.AppendLine($"WHERE CODVEND = '{entity.Id}'");
            using (var cmd = new SqlCommand(cmdBuilder.ToString(), _connection))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}
