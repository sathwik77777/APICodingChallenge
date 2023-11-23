using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace APIChallenge.DTO
{
    public class ProductDTO
    {
        public int ProductId {  get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

    }
}
