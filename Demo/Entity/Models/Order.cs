using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using Entity.Models.OrderData;
using System.Runtime.Serialization.Formatters.Binary;


namespace Entity.Models
{
    [Table("Orders")]
    public class Order
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

 
        public virtual ClientData ClientData { get; set; } = new ClientData();


        public virtual ShopData ShopData { get; set; } = new ShopData();


        public virtual GoodsData GoodsData { get; set; } = new GoodsData();

     
    }
}
