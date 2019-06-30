using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo1.Classes.OrderData
{

    [Table("Clients")]
    public class ClientData
    {

        [Key]
        public int Id { get; set; }


        [Required, MaxLength(256)]
        public string FirstName { get; set; }


        [Required, MaxLength(256)]
        public string LastName { get; set; }

        [Required, MaxLength(256)]
        public string Email { get; set; }


        [Required, MaxLength(13)]
        public string PhoneNumber { get; set; }


        public virtual Address Address { get; set; } = new Address();
    }
}
