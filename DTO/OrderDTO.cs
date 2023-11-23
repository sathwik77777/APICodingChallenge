using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIChallenge.DTO
{
    public class OrderDTO
    {
        public Guid OrderId { get; set; }
        public int ProductId { get; set; }

        public string? UserId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
