using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Entity
{
    public class Cart
    {
        [Key]
        public Guid CartId { get; set; }

        [Required] 
        public int Quantity { get; set; }

        [ForeignKey("ProductId")]
        public Guid ProductId { get; set; }

        [ForeignKey("CustomerId")]
        public Guid CustomerId { get; set; }

        public Product? Product { get; set; }

        public Customer? Customer { get; set; }
    }
}
