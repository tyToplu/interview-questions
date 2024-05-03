using System.ComponentModel.DataAnnotations;

namespace WebServicesAndEntityLinking.Models
{
    public class Record
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Surname { get; set; }
        public int Age { get; set; }
    }
}
