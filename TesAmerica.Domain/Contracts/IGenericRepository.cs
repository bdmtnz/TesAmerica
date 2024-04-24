using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TesAmerica.Domain.Base;

namespace TesAmerica.Domain.Contracts
{
    public interface IGenericRepository<T> where T : class, IEntity
    {
        IEnumerable<T> GetAll();
        T? FindByKey(string key);
        IEnumerable<T> FindByForeignKey(string foreignkey);
        void Add(T entity);
        void Update(T entity);
    }
}
