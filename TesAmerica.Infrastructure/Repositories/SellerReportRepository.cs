using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesAmerica.Domain;
using TesAmerica.Domain.Base;
using TesAmerica.Domain.Contracts.CustomRepositories;

namespace TesAmerica.Infrastructure.Repositories
{
    public class SellerReportRepository : ISellerReportRepository
    {
        private readonly SqlConnection _connection;

        public SellerReportRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public ICollection<SellerReport> GetCommisions(int? year, int month)
        {
            ICollection<SellerReport> result = new List<SellerReport>();
            var cmdBuilder = new StringBuilder();
            cmdBuilder.AppendLine("SELECT");
            cmdBuilder.AppendLine(" P.VENDEDOR, ");
            cmdBuilder.AppendLine(" V.NOMBRE, ");
            cmdBuilder.AppendLine(" SUM(I.SUBTOTAL) AS SUBTOTAL, ");
            cmdBuilder.AppendLine(" SUM(I.SUBTOTAL) * 0.10 AS COMISION, ");
            cmdBuilder.AppendLine(" YEAR(P.FECHA) AS YEARS, ");
            cmdBuilder.AppendLine(" MONTH(P.FECHA) AS MONTHS ");
            cmdBuilder.AppendLine("FROM PEDIDO P ");
            cmdBuilder.AppendLine("JOIN ( ");
            cmdBuilder.AppendLine(" SELECT ");
            cmdBuilder.AppendLine("     NUMPEDIDO, ");
            cmdBuilder.AppendLine("     SUM(SUBTOTAL) AS SUBTOTAL ");
            cmdBuilder.AppendLine(" FROM ITEMS ");
            cmdBuilder.AppendLine(" GROUP BY NUMPEDIDO ");
            cmdBuilder.AppendLine(") I ON P.NUMPEDIDO = I.NUMPEDIDO ");
            cmdBuilder.AppendLine("JOIN VENDEDOR V ON P.VENDEDOR = V.CODVEND ");
            if(year.HasValue)
            {
                cmdBuilder.AppendLine($"WHERE MONTH(P.FECHA) = {month} AND YEAR(P.FECHA) = {year.Value} ");
            }
            else
            {
                cmdBuilder.AppendLine($"WHERE MONTH(P.FECHA) = {month} ");
            }
            cmdBuilder.AppendLine("GROUP BY P.VENDEDOR, V.NOMBRE, YEAR(P.FECHA), MONTH(P.FECHA) ");
            using (var cmd = new SqlCommand(cmdBuilder.ToString(), _connection))
            {
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var department = new SellerReport
                    {
                        SellerId = $"{reader["VENDEDOR"]}",
                        SellerName = $"{reader["NOMBRE"]}",
                        Subtotal = Convert.ToDouble(reader["SUBTOTAL"]),
                        Comission = Convert.ToDouble(reader["COMISION"]),
                        Year = Convert.ToInt32(reader["YEARS"]),
                        Month = Convert.ToInt32(reader["MONTHS"])
                    };
                    result.Add(department);
                }
            }
            return result;
        }
    }
}
