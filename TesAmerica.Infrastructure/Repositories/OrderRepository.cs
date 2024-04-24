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
    public class OrderRepository : IGenericRepository<Order>
    {
        private readonly SqlConnection _connection;

        public OrderRepository(SqlConnection connection) {
            _connection = connection;
        }

        public void Add(Order entity)
        {
            var cmdBuilder = new StringBuilder();
            cmdBuilder.AppendLine("INSERT INTO PEDIDO VALUES");
            cmdBuilder.AppendLine("(");
            cmdBuilder.AppendLine($"    '{entity.Id}', ");
            cmdBuilder.AppendLine($"    '{entity.ClientId}', ");
            cmdBuilder.AppendLine($"    '{entity.Date}', ");
            cmdBuilder.AppendLine($"    '{entity.SellerId}' ");
            cmdBuilder.AppendLine(")");
            using (var cmd = new SqlCommand(cmdBuilder.ToString(), _connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public ICollection<Order> FindByForeignKey(string foreignkey)
        {
            ICollection<Order> result = new List<Order>();
            var cmdBuilder = new StringBuilder();
            cmdBuilder.AppendLine("SELECT");
            cmdBuilder.AppendLine(" * ");
            cmdBuilder.AppendLine("FROM PEDIDO");
            cmdBuilder.AppendLine($"WHERE VENDEDOR = '{foreignkey}'");
            using (var cmd = new SqlCommand(cmdBuilder.ToString(), _connection))
            {
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var department = new Order
                    {
                        Id = $"{reader["NUMPEDIDO"]}",
                        ClientId = $"{reader["CLIENTE"]}",
                        Date = Convert.ToDateTime(reader["FECHA"]),
                        SellerId = $"{reader["VENDEDOR"]}"
                    };
                    result.Add(department);
                }
            }
            return result;
        }

        public Order? FindByKey(string key)
        {
            Order? result = default;
            var cmdBuilder = new StringBuilder();
            cmdBuilder.AppendLine("SELECT TOP(1)");
            cmdBuilder.AppendLine(" * ");
            cmdBuilder.AppendLine("FROM PEDIDO");
            cmdBuilder.AppendLine($"WHERE NUMPEDIDO = '{key}'");
            using (var cmd = new SqlCommand(cmdBuilder.ToString(), _connection))
            {
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result = new Order
                    {
                        Id = $"{reader["NUMPEDIDO"]}",
                        ClientId = $"{reader["CLIENTE"]}",
                        Date = Convert.ToDateTime(reader["FECHA"]),
                        SellerId = $"{reader["VENDEDOR"]}"
                    };
                }
            }
            return result;
        }

        public ICollection<Order> GetAll()
        {
            ICollection<Order> result = new List<Order>();
            var cmdBuilder = new StringBuilder();
            cmdBuilder.AppendLine("SELECT");
            cmdBuilder.AppendLine(" * ");
            cmdBuilder.AppendLine("FROM PEDIDO");
            using(var cmd = new SqlCommand(cmdBuilder.ToString(), _connection))
            {
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var department = new Order
                    {
                        Id = $"{reader["NUMPEDIDO"]}",
                        ClientId = $"{reader["CLIENTE"]}",
                        Date = Convert.ToDateTime(reader["FECHA"]),
                        SellerId = $"{reader["VENDEDOR"]}"
                    };
                    result.Add(department);
                }
            }
            return result;
        }

        public void Update(Order entity)
        {
            var cmdBuilder = new StringBuilder();
            cmdBuilder.AppendLine("UPDATE PEDIDO");
            cmdBuilder.AppendLine("SET");
            cmdBuilder.AppendLine($"    FECHA = '{entity.Date}', ");
            cmdBuilder.AppendLine($"    VENDEDOR = '{entity.SellerId}' ");
            cmdBuilder.AppendLine($"WHERE NUMPEDIDO = '{entity.Id}'");
            using (var cmd = new SqlCommand(cmdBuilder.ToString(), _connection))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}
