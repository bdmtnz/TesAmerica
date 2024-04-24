using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesAmerica.Domain;
using TesAmerica.Domain.Contracts;
using TesAmerica.Infrastructure.Repositories;

namespace TesAmerica.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlConnection _connection;
        private  SqlTransaction? _transaction;

        public UnitOfWork(SqlConnection connection)
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

        public IGenericRepository<City> CityRepository()
        {
            throw new NotImplementedException();
        }

        public IGenericRepository<Client> ClientRepository()
        {
            throw new NotImplementedException();
        }

        public IGenericRepository<Department> DepartmentRepository()
        {
            return new DepartmentRepository(_connection);
        }

        public IGenericRepository<Item> ItemRepository()
        {
            throw new NotImplementedException();
        }

        public IGenericRepository<Order> OrderRepository()
        {
            throw new NotImplementedException();
        }

        public IGenericRepository<Product> ProductRepository()
        {
            throw new NotImplementedException();
        }

        public IGenericRepository<Seller> SellerRepository()
        {
            throw new NotImplementedException();
        }
    }
}
