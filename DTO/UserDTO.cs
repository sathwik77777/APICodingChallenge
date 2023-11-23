using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace APIChallenge.DTO
{
    public class UserDTO
    {
        public string? UserId { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }
        public string? Role { get; set; }
    }
}
