using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesAmerica.Domain;
using TesAmerica.Domain.Base;
using TesAmerica.Domain.Contracts.CustomRepositories;

namespace TesAmerica.Infrastructure.Repositories
{
    public class DepartmentReportRepository : IDepartmentReportRepository
    {
        private readonly SqlConnection _connection;

        public DepartmentReportRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public ICollection<DepartmentReport> GetSales(DateTime start, DateTime end)
        {
            ICollection<DepartmentReport> result = new List<DepartmentReport>();
            var cmdBuilder = new StringBuilder();
            cmdBuilder.AppendLine("SELECT");
            cmdBuilder.AppendLine(" D.CODDEP, ");
            cmdBuilder.AppendLine(" D.NOMBRE, ");
            cmdBuilder.AppendLine(" SUM(I.SUBTOTAL) AS VENTAS ");
            cmdBuilder.AppendLine("FROM PEDIDO P ");
            cmdBuilder.AppendLine("JOIN (  ");
            cmdBuilder.AppendLine(" SELECT  ");
            cmdBuilder.AppendLine("     NUMPEDIDO,  ");
            cmdBuilder.AppendLine("     SUM(SUBTOTAL) AS SUBTOTAL  ");
            cmdBuilder.AppendLine(" FROM ITEMS  ");
            cmdBuilder.AppendLine(" GROUP BY NUMPEDIDO  ");
            cmdBuilder.AppendLine(") I ON P.NUMPEDIDO = I.NUMPEDIDO  ");
            cmdBuilder.AppendLine("JOIN CLIENTE C ON P.CLIENTE = C.CODCLI  ");
            cmdBuilder.AppendLine("JOIN CIUDAD CI ON C.CIUDAD = CI.CODCIU  ");
            cmdBuilder.AppendLine("JOIN DEPARTAMENTO D ON CI.DEPARTAMENTO = D.CODDEP  ");
            //cmdBuilder.AppendLine("WHERE FECHA BETWEEN '2017-09-01 00:00:00.000' AND '2017-09-03 16:48:00.000'  ");
            var startString = Utils.GetStartDbDate(start);
            var endString = Utils.GetEndDbDate(end);
            cmdBuilder.AppendLine($"WHERE FECHA BETWEEN '{startString}' AND '{endString}'  ");
            cmdBuilder.AppendLine("GROUP BY D.CODDEP, D.NOMBRE  ");
            using (var cmd = new SqlCommand(cmdBuilder.ToString(), _connection))
            {
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var department = new DepartmentReport
                    {
                        DepartmentId = $"{reader["CODDEP"]}",
                        DepartmentName = $"{reader["NOMBRE"]}",
                        Sales = Convert.ToDouble(reader["VENTAS"])
                    };
                    result.Add(department);
                }
            }
            return result;
        } 
    }
}
