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
    public class DepartmentRepository : IGenericRepository<Department>
    {
        private readonly SqlConnection _connection;

        public DepartmentRepository(SqlConnection connection) {
            _connection = connection;
        }

        public void Add(Department entity)
        {
            var cmdBuilder = new StringBuilder();
            cmdBuilder.AppendLine("INSERT INTO DEPARTAMENTO VALUES");
            cmdBuilder.AppendLine("(");
            cmdBuilder.AppendLine($"    '{entity.Id}', ");
            cmdBuilder.AppendLine($"    '{entity.Name}' ");
            cmdBuilder.AppendLine(")");
            using (var cmd = new SqlCommand(cmdBuilder.ToString(), _connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public Department? FindByKey(string key)
        {
            Department? result = default;
            var cmdBuilder = new StringBuilder();
            cmdBuilder.AppendLine("SELECT TOP(1)");
            cmdBuilder.AppendLine(" * ");
            cmdBuilder.AppendLine("FROM DEPARTAMENTO");
            cmdBuilder.AppendLine($"WHERE CODDEP = '{key}'");
            using (var cmd = new SqlCommand(cmdBuilder.ToString(), _connection))
            {
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result = new Department
                    {
                        Id = $"{reader["CODDEP"]}",
                        Name = $"{reader["NOMBRE"]}"
                    };
                }
            }
            return result;
        }

        public IEnumerable<Department> GetAll()
        {
            IEnumerable<Department> result = new List<Department>();
            var cmdBuilder = new StringBuilder();
            cmdBuilder.AppendLine("SELECT");
            cmdBuilder.AppendLine(" * ");
            cmdBuilder.AppendLine("FROM DEPARTAMENTO");
            using(var cmd = new SqlCommand(cmdBuilder.ToString(), _connection))
            {
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var department = new Department
                    {
                        Id = $"{reader["CODDEP"]}",
                        Name = $"{reader["NOMBRE"]}"
                    };
                    result.Append(department);
                }
            }
            return result;
        }

        public void Update(Department entity)
        {
            var cmdBuilder = new StringBuilder();
            cmdBuilder.AppendLine("UPDATE DEPARTAMENTO");
            cmdBuilder.AppendLine("SET");
            cmdBuilder.AppendLine($"    NOMBRE = '{entity.Name}' ");
            cmdBuilder.AppendLine($"WHERE CODDEP = '{entity.Id}'");
            using (var cmd = new SqlCommand(cmdBuilder.ToString(), _connection))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}
