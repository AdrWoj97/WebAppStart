using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Kategorie
    {
        public int KategorieId { get; set; }
        [Required(ErrorMessage = "Pole nazwa nie może być puste")]
        [MaxLength(30,ErrorMessage = "Nazwa musi zawierać mniej niż 30 znaków")]
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [DisplayName("Kolejność wyświetlania")]
        [Required(ErrorMessage = "Pole kolejność wyświetlania nie może być puste")]
        [Range(1,100,ErrorMessage = "Kolejośc wyświetlania musi być między 1 - 100")]
        public int DisplayOrder { get; set; }
    }
}
