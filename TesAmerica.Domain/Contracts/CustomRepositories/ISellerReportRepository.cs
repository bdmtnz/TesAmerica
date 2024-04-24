using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesAmerica.Domain.Contracts.CustomRepositories
{
    public interface ISellerReportRepository
    {
        ICollection<SellerReport> GetCommisions(int? year, int month);
    }
}
