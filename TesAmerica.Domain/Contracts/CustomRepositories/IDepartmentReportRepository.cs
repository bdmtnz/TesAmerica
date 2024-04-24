using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesAmerica.Domain.Contracts.CustomRepositories
{
    public interface IDepartmentReportRepository
    {
        ICollection<DepartmentReport> GetSales(DateTime start, DateTime end);
    }
}
