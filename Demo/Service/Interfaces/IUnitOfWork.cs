using Entity.Models;
using Entity.Models.OrderData;


namespace Repository.Interfaces
{
    public interface IUnitOfWork
    {
        GenericRepository<Order> Orders { get; }
        GenericRepository<ShopData> Shops { get; }
        GenericRepository<GoodsData> Goods { get; }
        GenericRepository<Address> Addresses { get; }
        GenericRepository<ClientData> Clients { get; }
        void Save();
    }
}
