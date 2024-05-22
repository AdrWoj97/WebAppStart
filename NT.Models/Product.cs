using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace NT.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Pole Nazwa nie może być puste")]
        [DisplayName("Nazwa")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Pole Opis nie może być puste")]
        [DisplayName("Opis")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Pole ISBN nie może być puste")]
        [DisplayName("ISBN")]
        public string ISBN { get; set; }
        [Required(ErrorMessage = "Pole Autor nie może być puste")]
        [DisplayName("Autor")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Pole Cena detaliczna nie może być puste")]
        [DisplayName("Cena detaliczna")]
        [Range(1, 1000)]
        public double ListPrice { get; set; }
        [Required(ErrorMessage = "Pole Cena 1-50 nie może być puste")]
        [DisplayName("Cena 1-50")]
        [Range(1, 1000)]
        public double Price { get; set; }
        [Required(ErrorMessage = "Pole Cena za 50+ nie może być puste")]
        [DisplayName("Cena za 50+")]
        [Range(1, 1000)]
        public double Price50 { get; set; }
        [Required(ErrorMessage = "Pole Cena za 100+ nie może być puste")]
        [DisplayName("Cena za 100+")]
        [Range(1, 1000)]
        public double Price100 { get; set; }

        public int KategorieId { get; set; }
        [ForeignKey("KategorieId")]
        public Kategorie Kategorie{ get; set; }
    }
}
