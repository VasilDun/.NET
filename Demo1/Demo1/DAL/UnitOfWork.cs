 using System;
using System.Data.Entity;
using System.Collections.Generic;

using Demo1.Classes;
using Demo1.DAL.Interfaces;
using Demo1.Classes.OrderData;

namespace Demo1.DAL
{
    /// <summary>
    /// Is used to manage repositories. 
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        private readonly OrderContext _context;


        public GenericRepository<Order> Orders { get; }

        public GenericRepository<ClientData> Clients { get; }


        public GenericRepository<ShopData> Shops { get; }


        public GenericRepository<GoodsData> Goods { get; }


        public GenericRepository<Address> Addresses { get; }

        private bool _disposed;


        public UnitOfWork()
        {
            _context = new OrderContext();
            Orders = new GenericRepository<Order>(_context);
            Clients = new GenericRepository<ClientData>(_context);
            Shops = new GenericRepository<ShopData>(_context);
            Goods = new GenericRepository<GoodsData>(_context);
            Addresses = new GenericRepository<Address>(_context);
        }


        public IEnumerable<Order> GetOrders()
        {
            return _context.Orders
                .Include(g => g.GoodsData)
                .Include(s => s.ShopData).Include(shop => shop.ShopData.Address)
                .Include(c => c.ClientData).Include(client => client.ClientData.Address);
        }


        public void DeleteOrder(int id)
        {
            var order = Orders.GetById(id);
            Addresses.Delete(order.ClientData.Address);
            Addresses.Delete(order.ShopData.Address);
            Goods.Delete(order.GoodsData);
            Clients.Delete(order.ClientData);
            Shops.Delete(order.ShopData);
            Orders.Delete(order);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
