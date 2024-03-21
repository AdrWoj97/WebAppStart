using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Kategorie
    {
        public int KategorieId { get; set; }
        [Required]
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
