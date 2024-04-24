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
    public class ItemRepository : IGenericRepository<Item>
    {
        private readonly SqlConnection _connection;

        public ItemRepository(SqlConnection connection) {
            _connection = connection;
        }

        public void Add(Item entity)
        {
            var cmdBuilder = new StringBuilder();
            cmdBuilder.AppendLine("INSERT INTO ITEMS VALUES");
            cmdBuilder.AppendLine("(");
            cmdBuilder.AppendLine($"    '{entity.OrderId}', ");
            cmdBuilder.AppendLine($"    '{entity.ProductId}', ");
            cmdBuilder.AppendLine($"    {entity.Price}, ");
            cmdBuilder.AppendLine($"    {entity.Quantity}, ");
            cmdBuilder.AppendLine($"    {entity.Subtotal} ");
            cmdBuilder.AppendLine(")");
            using (var cmd = new SqlCommand(cmdBuilder.ToString(), _connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public Item? FindByKey(string key)
        {
            Item? result = default;
            var cmdBuilder = new StringBuilder();
            cmdBuilder.AppendLine("SELECT TOP(1)");
            cmdBuilder.AppendLine(" * ");
            cmdBuilder.AppendLine("FROM ITEMS");
            cmdBuilder.AppendLine($"WHERE PRODUCTO = '{key}'");
            using (var cmd = new SqlCommand(cmdBuilder.ToString(), _connection))
            {
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result = new Item
                    {
                        OrderId = $"{reader["NUMPEDIDO"]}",
                        ProductId = $"{reader["PRODUCTO"]}",
                        Price = Convert.ToDouble(reader["PRECIO"]),
                        Quantity = Convert.ToDouble(reader["CANTIDAD"]),
                        Subtotal = Convert.ToDouble(reader["SUBTOTAL"])
                    };
                }
            }
            return result;
        }

        public ICollection<Item> FindByForeignKey(string foreigkey)
        {
            ICollection<Item> result = new List<Item>();
            var cmdBuilder = new StringBuilder();
            cmdBuilder.AppendLine("SELECT");
            cmdBuilder.AppendLine(" * ");
            cmdBuilder.AppendLine("FROM ITEMS");
            cmdBuilder.AppendLine($"WHERE NUMPEDIDO = '{foreigkey}'");
            using (var cmd = new SqlCommand(cmdBuilder.ToString(), _connection))
            {
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var item = new Item
                    {
                        OrderId = $"{reader["NUMPEDIDO"]}",
                        ProductId = $"{reader["PRODUCTO"]}",
                        Price = Convert.ToDouble(reader["PRECIO"]),
                        Quantity = Convert.ToDouble(reader["CANTIDAD"]),
                        Subtotal = Convert.ToDouble(reader["SUBTOTAL"])
                    };
                    result.Add(item);
                }
            }
            return result;
        }

        public ICollection<Item> GetAll()
        {
            ICollection<Item> result = new List<Item>();
            var cmdBuilder = new StringBuilder();
            cmdBuilder.AppendLine("SELECT");
            cmdBuilder.AppendLine(" * ");
            cmdBuilder.AppendLine("FROM ITEMS");
            using(var cmd = new SqlCommand(cmdBuilder.ToString(), _connection))
            {
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var item = new Item
                    {
                        OrderId = $"{reader["NUMPEDIDO"]}",
                        ProductId = $"{reader["PRODUCTO"]}",
                        Price = Convert.ToDouble(reader["PRECIO"]),
                        Quantity = Convert.ToDouble(reader["CANTIDAD"]),
                        Subtotal = Convert.ToDouble(reader["SUBTOTAL"])
                    };
                    result.Add(item);
                }
            }
            return result;
        }

        public void Update(Item entity)
        {
            var cmdBuilder = new StringBuilder();
            cmdBuilder.AppendLine("UPDATE ITEMS");
            cmdBuilder.AppendLine("SET");
            cmdBuilder.AppendLine($"    CANTIDAD = {entity.Quantity}, ");
            cmdBuilder.AppendLine($"    SUBTOTAL = {entity.Subtotal} ");
            cmdBuilder.AppendLine($"WHERE NUMPEDIDO = '{entity.OrderId}' AND PRODUCTO = '{entity.ProductId}'");
            using (var cmd = new SqlCommand(cmdBuilder.ToString(), _connection))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}
