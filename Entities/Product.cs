using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIChallenge.Entities
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Column("ProductName", TypeName = "varchar")]
        [StringLength(50)]
        [Required]
        public string? Name { get; set; }
        public double? Price { get; set; }
        [ForeignKey("UserId")]
        public String? UserId {  get; set; }
        public User? User { get; set; }
    }
}
