using System.Data.Entity;

using Demo1.Classes;
using Demo1.Classes.OrderData;

namespace Demo1.DAL
{
     class OrderContext : DbContext
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
