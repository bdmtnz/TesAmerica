using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesAmerica.Domain.Contracts.CustomRepositories;

namespace TesAmerica.Domain.Contracts
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        Task CommitAsync();
        Task RollbackAsync();
        void Open();
        void Close();
        IGenericRepository<Department> GetDepartmentRepository();
        IGenericRepository<City> GetCityRepository();
        IGenericRepository<Product> GetProductRepository();
        IGenericRepository<Client> GetClientRepository();
        IGenericRepository<Item> GetItemRepository();
        IGenericRepository<Seller> GetSellerRepository();
        IGenericRepository<Order> GetOrderRepository();

        // Custom repos
        IDepartmentReportRepository GetDepartmentReportRepository();
        ISellerReportRepository GetSellerReportRepository();
    }
}
