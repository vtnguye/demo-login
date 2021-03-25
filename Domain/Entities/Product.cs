
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Product:BaseEntities
    {
        [Required]
        public string Name { get; set; }
        
        public int Quantity { get; set; }

        public string Image { get; set; }
    }
}
