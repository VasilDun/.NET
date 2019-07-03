using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models.OrderData
{
    [Table("Addresses")]
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(256)]
        public string City { get; set; }

        [Required, MaxLength(256)]
        public string Street { get; set; }

        [Required]
        public int BuildingNumber { get; set; }
    }
}
