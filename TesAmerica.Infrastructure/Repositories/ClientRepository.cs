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
    public class ClientRepository : IGenericRepository<Client>
    {
        private readonly SqlConnection _connection;

        public ClientRepository(SqlConnection connection) {
            _connection = connection;
        }

        public void Add(Client entity)
        {
            var cmdBuilder = new StringBuilder();
            cmdBuilder.AppendLine("INSERT INTO CLIENTE VALUES");
            cmdBuilder.AppendLine("(");
            cmdBuilder.AppendLine($"    '{entity.Id}', ");
            cmdBuilder.AppendLine($"    '{entity.Name}', ");
            cmdBuilder.AppendLine($"    '{entity.Address}', ");
            cmdBuilder.AppendLine($"    '{entity.Phone}', ");
            cmdBuilder.AppendLine($"    {entity.Quota}, ");
            cmdBuilder.AppendLine($"    {entity.CreateAt}, ");
            cmdBuilder.AppendLine($"    '{entity.Channel}', ");
            cmdBuilder.AppendLine($"    '{entity.SellerId}', ");
            cmdBuilder.AppendLine($"    '{entity.CityId}', ");
            cmdBuilder.AppendLine($"    '{entity.DadId}' ");
            cmdBuilder.AppendLine(")");
            using (var cmd = new SqlCommand(cmdBuilder.ToString(), _connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public ICollection<Client> FindByForeignKey(string foreignkey)
        {
            ICollection<Client> result = new List<Client>();
            var cmdBuilder = new StringBuilder();
            cmdBuilder.AppendLine("SELECT");
            cmdBuilder.AppendLine(" * ");
            cmdBuilder.AppendLine("FROM CLIENTE");
            cmdBuilder.AppendLine($"WHERE NOMBRE LIKE '%{foreignkey}%'");
            using (var cmd = new SqlCommand(cmdBuilder.ToString(), _connection))
            {
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Client
                    {
                        Id = $"{reader["CODCLI"]}",
                        Address = $"{reader["DIRECCION"]}",
                        Name = $"{reader["NOMBRE"]}",
                        Channel = $"{reader["CANAL"]}",
                        CityId = $"{reader["CIUDAD"]}",
                        CreateAt = Convert.ToDateTime(reader["FECHACREACION"]),
                        DadId = $"{reader["PADRE"]}",
                        Phone = $"{reader["TELEFONO"]}",
                        Quota = Convert.ToInt32(reader["CUPO"]),
                        SellerId = $"{reader["VENDEDOR"]}"
                    });
                }
            }
            return result;
        }

        public Client? FindByKey(string key)
        {
            Client? result = default;
            var cmdBuilder = new StringBuilder();
            cmdBuilder.AppendLine("SELECT TOP(1)");
            cmdBuilder.AppendLine(" * ");
            cmdBuilder.AppendLine("FROM CLIENTE");
            cmdBuilder.AppendLine($"WHERE CODCLI = '{key}'");
            using (var cmd = new SqlCommand(cmdBuilder.ToString(), _connection))
            {
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result = new Client
                    {
                        Id = $"{reader["CODCLI"]}",
                        Address = $"{reader["DIRECCION"]}",
                        Name = $"{reader["NOMBRE"]}",
                        Channel = $"{reader["CANAL"]}",
                        CityId = $"{reader["CIUDAD"]}",
                        CreateAt = Convert.ToDateTime(reader["FECHACREACION"]),
                        DadId = $"{reader["PADRE"]}",
                        Phone = $"{reader["TELEFONO"]}",
                        Quota = Convert.ToInt32(reader["CUPO"]),
                        SellerId = $"{reader["VENDEDOR"]}"
                    };
                }
            }
            return result;
        }

        public ICollection<Client> GetAll()
        {
            ICollection<Client> result = new List<Client>();
            var cmdBuilder = new StringBuilder();
            cmdBuilder.AppendLine("SELECT");
            cmdBuilder.AppendLine(" * ");
            cmdBuilder.AppendLine("FROM CLIENTE");
            using(var cmd = new SqlCommand(cmdBuilder.ToString(), _connection))
            {
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var client = new Client
                    {
                        Id = $"{reader["CODCLI"]}",
                        Address = $"{reader["DIRECCION"]}",
                        Name = $"{reader["NOMBRE"]}",
                        Channel = $"{reader["CANAL"]}",
                        CityId = $"{reader["CIUDAD"]}",
                        CreateAt = Convert.ToDateTime(reader["FECHACREACION"]),
                        DadId = $"{reader["PADRE"]}",
                        Phone = $"{reader["TELEFONO"]}",
                        Quota = Convert.ToInt32(reader["CUPO"]),
                        SellerId = $"{reader["VENDEDOR"]}"
                    };
                    result.Add(client);
                }
            }
            return result;
        }

        public void Update(Client entity)
        {
            var cmdBuilder = new StringBuilder();
            cmdBuilder.AppendLine("UPDATE CLIENTE");
            cmdBuilder.AppendLine("SET");
            cmdBuilder.AppendLine($"    DIRECCION = '{entity.Address}', ");
            cmdBuilder.AppendLine($"    NOMBRE = '{entity.Name}', ");
            cmdBuilder.AppendLine($"    CANAL = '{entity.Channel}', ");
            cmdBuilder.AppendLine($"    CIUDAD = '{entity.CityId}', ");
            cmdBuilder.AppendLine($"    FECHACREACION = '{entity.CreateAt}', ");
            cmdBuilder.AppendLine($"    PADRE = '{entity.DadId}', ");
            cmdBuilder.AppendLine($"    TELEFONO = '{entity.Phone}', ");
            cmdBuilder.AppendLine($"    VENDEDOR = '{entity.SellerId}', ");
            cmdBuilder.AppendLine($"    CUPO = {entity.Quota} ");
            cmdBuilder.AppendLine($"WHERE CODCLI = '{entity.Id}'");
            using (var cmd = new SqlCommand(cmdBuilder.ToString(), _connection))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}
