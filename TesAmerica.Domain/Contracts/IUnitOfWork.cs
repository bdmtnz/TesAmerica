using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesAmerica.Domain.Contracts
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        Task CommitAsync();
        Task RollbackAsync();
        void Open();
        void Close();
        IGenericRepository<Department> DepartmentRepository();
        IGenericRepository<City> CityRepository();
        IGenericRepository<Product> ProductRepository();
        IGenericRepository<Client> ClientRepository();
        IGenericRepository<Item> ItemRepository();
        IGenericRepository<Seller> SellerRepository();
        IGenericRepository<Order> OrderRepository();
    }
}
