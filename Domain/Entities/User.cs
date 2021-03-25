

using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class User:BaseEntities
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string Role { get; set; }

         
    }
}
