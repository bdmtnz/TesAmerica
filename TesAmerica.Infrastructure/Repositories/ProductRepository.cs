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
    public class ProductRepository : IGenericRepository<Product>
    {
        private readonly SqlConnection _connection;

        public ProductRepository(SqlConnection connection) {
            _connection = connection;
        }

        public void Add(Product entity)
        {
            var cmdBuilder = new StringBuilder();
            cmdBuilder.AppendLine("INSERT INTO PRODUCTO VALUES");
            cmdBuilder.AppendLine("(");
            cmdBuilder.AppendLine($"    '{entity.Id}', ");
            cmdBuilder.AppendLine($"    '{entity.Name}', ");
            cmdBuilder.AppendLine($"    '{entity.Family}', ");
            cmdBuilder.AppendLine($"    {entity.Price} ");
            cmdBuilder.AppendLine(")");
            using (var cmd = new SqlCommand(cmdBuilder.ToString(), _connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public ICollection<Product> FindByForeignKey(string foreignkey)
        {
            ICollection<Product> result = new List<Product>();
            var cmdBuilder = new StringBuilder();
            cmdBuilder.AppendLine("SELECT");
            cmdBuilder.AppendLine(" * ");
            cmdBuilder.AppendLine("FROM PRODUCTO");
            cmdBuilder.AppendLine($"WHERE NOMBRE LIKE '%{foreignkey}%'");
            using (var cmd = new SqlCommand(cmdBuilder.ToString(), _connection))
            {
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var department = new Product
                    {
                        Id = $"{reader["CODPROD"]}",
                        Name = $"{reader["NOMBRE"]}",
                        Family = $"{reader["FAMILIA"]}",
                        Price = Convert.ToDouble(reader["PRECIO"])
                    };
                    result.Add(department);
                }
            }
            return result;
        }

        public Product? FindByKey(string key)
        {
            Product? result = default;
            var cmdBuilder = new StringBuilder();
            cmdBuilder.AppendLine("SELECT TOP(1)");
            cmdBuilder.AppendLine(" * ");
            cmdBuilder.AppendLine("FROM PRODUCTO");
            cmdBuilder.AppendLine($"WHERE CODPROD = '{key}'");
            using (var cmd = new SqlCommand(cmdBuilder.ToString(), _connection))
            {
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result = new Product
                    {
                        Id = $"{reader["CODPROD"]}",
                        Name = $"{reader["NOMBRE"]}",
                        Family = $"{reader["FAMILIA"]}",
                        Price = Convert.ToDouble(reader["PRECIO"])
                    };
                }
            }
            return result;
        }

        public ICollection<Product> GetAll()
        {
            ICollection<Product> result = new List<Product>();
            var cmdBuilder = new StringBuilder();
            cmdBuilder.AppendLine("SELECT");
            cmdBuilder.AppendLine(" * ");
            cmdBuilder.AppendLine("FROM PRODUCTO");
            using(var cmd = new SqlCommand(cmdBuilder.ToString(), _connection))
            {
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var department = new Product
                    {
                        Id = $"{reader["CODPROD"]}",
                        Name = $"{reader["NOMBRE"]}",
                        Family = $"{reader["FAMILIA"]}",
                        Price = Convert.ToDouble(reader["PRECIO"])
                    };
                    result.Add(department);
                }
            }
            return result;
        }

        public void Update(Product entity)
        {
            var cmdBuilder = new StringBuilder();
            cmdBuilder.AppendLine("UPDATE PRODUCTO");
            cmdBuilder.AppendLine("SET");
            cmdBuilder.AppendLine($"    NOMBRE = '{entity.Name}', ");
            cmdBuilder.AppendLine($"    FAMILIA = '{entity.Family}' ");
            cmdBuilder.AppendLine($"    PRECIO = {entity.Price} ");
            cmdBuilder.AppendLine($"WHERE CODPROD = '{entity.Id}'");
            using (var cmd = new SqlCommand(cmdBuilder.ToString(), _connection))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}
