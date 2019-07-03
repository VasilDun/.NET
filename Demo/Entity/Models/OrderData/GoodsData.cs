using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models.OrderData
{

    [Table("Goods")]
    public class GoodsData
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public int Code { get; set; }

  
        [Required]
        public double Weight { get; set; }
    }
}
