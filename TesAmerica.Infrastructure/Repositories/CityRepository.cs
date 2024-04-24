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
    public class CityRepository : IGenericRepository<City>
    {
        private readonly SqlConnection _connection;

        public CityRepository(SqlConnection connection) {
            _connection = connection;
        }

        public void Add(City entity)
        {
            var cmdBuilder = new StringBuilder();
            cmdBuilder.AppendLine("INSERT INTO CIUDAD VALUES");
            cmdBuilder.AppendLine("(");
            cmdBuilder.AppendLine($"    '{entity.Id}', ");
            cmdBuilder.AppendLine($"    '{entity.Name}', ");
            cmdBuilder.AppendLine($"    '{entity.DepartmentId}' ");
            cmdBuilder.AppendLine(")");
            using (var cmd = new SqlCommand(cmdBuilder.ToString(), _connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<City> FindByForeignKey(string foreignkey)
        {
            IEnumerable<City> result = new List<City>();
            var cmdBuilder = new StringBuilder();
            cmdBuilder.AppendLine("SELECT");
            cmdBuilder.AppendLine(" * ");
            cmdBuilder.AppendLine("FROM CIUDAD");
            cmdBuilder.AppendLine($"WHERE DEPARTAMENTO = '{foreignkey}'");
            using (var cmd = new SqlCommand(cmdBuilder.ToString(), _connection))
            {
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var department = new City
                    {
                        Id = $"{reader["CODCIU"]}",
                        Name = $"{reader["NOMBRE"]}",
                        DepartmentId = $"{reader["DEPARTAMENTO"]}"
                    };
                    result.Append(department);
                }
            }
            return result;
        }

        public City? FindByKey(string key)
        {
            City? result = default;
            var cmdBuilder = new StringBuilder();
            cmdBuilder.AppendLine("SELECT TOP(1)");
            cmdBuilder.AppendLine(" * ");
            cmdBuilder.AppendLine("FROM CIUDAD");
            cmdBuilder.AppendLine($"WHERE CODCIU = '{key}'");
            using (var cmd = new SqlCommand(cmdBuilder.ToString(), _connection))
            {
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result = new City
                    {
                        Id = $"{reader["CODCIU"]}",
                        Name = $"{reader["NOMBRE"]}",
                        DepartmentId = $"{reader["DEPARTAMENTO"]}"
                    };
                }
            }
            return result;
        }

        public IEnumerable<City> GetAll()
        {
            IEnumerable<City> result = new List<City>();
            var cmdBuilder = new StringBuilder();
            cmdBuilder.AppendLine("SELECT");
            cmdBuilder.AppendLine(" * ");
            cmdBuilder.AppendLine("FROM CIUDAD");
            using(var cmd = new SqlCommand(cmdBuilder.ToString(), _connection))
            {
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var department = new City
                    {
                        Id = $"{reader["CODCIU"]}",
                        Name = $"{reader["NOMBRE"]}",
                        DepartmentId = $"{reader["DEPARTAMENTO"]}"
                    };
                    result.Append(department);
                }
            }
            return result;
        }

        public void Update(City entity)
        {
            var cmdBuilder = new StringBuilder();
            cmdBuilder.AppendLine("UPDATE CIUDAD");
            cmdBuilder.AppendLine("SET");
            cmdBuilder.AppendLine($"    NOMBRE = '{entity.Name}', ");
            cmdBuilder.AppendLine($"    DEPARTAMENTO = '{entity.DepartmentId}' ");
            cmdBuilder.AppendLine($"WHERE CODCIU = '{entity.Id}'");
            using (var cmd = new SqlCommand(cmdBuilder.ToString(), _connection))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}
