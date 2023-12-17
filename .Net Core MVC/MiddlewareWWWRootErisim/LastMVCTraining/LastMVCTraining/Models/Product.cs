using System.ComponentModel.DataAnnotations;

namespace LastMVCTraining.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "gerekli1 ")]
        public string Name { get; set; }
        [Required(ErrorMessage = "gerekli2 ")]
        public decimal Price { get; set; }

    }
}
