using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using SportsClub.Data.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsClub.Models
{
    [Table("Services", Schema = "Cart")]
    public class Service
    {
        [Key]
        public long Id { get; set; }
        [Display(Name = "Назва послуги")]
        [Required(ErrorMessage = "Поле 'Назва послуги' обов'язкове!")]
        public string Name { get; set; }
        public string URLFriendlyName { get; set; }
        [Display(Name = "Опис")]
        [Required, MinLength(4, ErrorMessage = "Minimum length is 2")]
        public string Description { get; set; }
        [Display(Name = "Ціна послуги")]
        [Required(ErrorMessage = "Поле 'Ціна' обов'язкове!")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a value")]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }
        [Display(Name = "Категорія")]
        [Required(ErrorMessage = "Поле 'Категорія' обов'язкове!")]
        [Range(1, int.MaxValue, ErrorMessage = "Будь-ласка, оберіть категорію.")]
        public long CategoryId { get; set; }
        public Category Category { get; set; }
        public string Image { get; set; } = "noimage.jpg";
        [NotMapped]
        [FileExtension]
        public IFormFile ImageUpload { get; set; }
    }
}
