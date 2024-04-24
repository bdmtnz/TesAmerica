using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesAmerica.Domain;
using TesAmerica.Domain.Contracts;
using TesAmerica.Domain.Contracts.CustomRepositories;
using TesAmerica.Infrastructure.Repositories;

namespace TesAmerica.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection<SqlConnection, SqlTransaction> _connection;
        private  SqlTransaction? _transaction;

        public UnitOfWork(IDbConnection<SqlConnection, SqlTransaction> connection)
        {
            _connection = connection;
        }

        public void BeginTransaction()
        {
            _transaction = _connection.BeginTransaction();
        }

        public Task CommitAsync()
        {
            if (_transaction == default) throw new Exception("First begin a transaction");
            return _transaction.CommitAsync();
        }

        public Task RollbackAsync()
        {
            if (_transaction == default) throw new Exception("First begin a transaction");
            return _transaction.RollbackAsync();
        }

        public void Open()
        {
            _connection.Open();
        }

        public void Close()
        {
            _connection.Close();
        }

        public IGenericRepository<City> GetCityRepository()
        {
            return new CityRepository(_connection.GetConnection());
        }

        public IGenericRepository<Client> GetClientRepository()
        {
            return new ClientRepository(_connection.GetConnection());
        }

        public IGenericRepository<Department> GetDepartmentRepository()
        {
            return new DepartmentRepository(_connection.GetConnection());
        }

        public IGenericRepository<Item> GetItemRepository()
        {
            return new ItemRepository(_connection.GetConnection());
        }

        public IGenericRepository<Order> GetOrderRepository()
        {
            return new OrderRepository(_connection.GetConnection());
        }

        public IGenericRepository<Product> GetProductRepository()
        {
            return new ProductRepository(_connection.GetConnection());
        }

        public IGenericRepository<Seller> GetSellerRepository()
        {
            return new SellerRepository(_connection.GetConnection());
        }

        public IDepartmentReportRepository GetDepartmentReportRepository()
        {
            return new DepartmentReportRepository(_connection.GetConnection());
        }
    }
}
