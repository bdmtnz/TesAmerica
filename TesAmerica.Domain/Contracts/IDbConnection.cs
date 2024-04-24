using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesAmerica.Domain.Contracts
{
    public interface IDbConnection<T, D> 
        where T : class 
        where D : class
    {
        D BeginTransaction();
        void Open();
        void Close();
        T GetConnection();
    }
}
