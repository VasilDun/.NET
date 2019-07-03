using System.Data.Entity;

using Entity.Models;
using Entity.Models.OrderData;

namespace Data
{
   public class OrderContext : DbContext
    {  
        public DbSet<Order> Orders { get; set; }
     
        public DbSet<ClientData> ClientDatas { get; set; }
  
        public DbSet<GoodsData> GoodsDatas { get; set; }

        public DbSet<ShopData> ShopDatas { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public OrderContext() : base("data source=(local);Initial Catalog=CargoDeliveryDb;Integrated Security=True;Connection Timeout=30;MultipleActiveResultSets=False")
        {
        }
    }
}
