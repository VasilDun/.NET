using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo1.Classes.OrderData
{

	[Table("Shops")]
    public class ShopData
    {

        [Key]
        public int Id { get; set; }


        [Required, MaxLength(256)]
        public string Name { get; set; }

        public virtual Address Address { get; set; } = new Address();
    }
}
