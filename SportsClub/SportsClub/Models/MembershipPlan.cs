using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace SportsClub.Models
{
    [Table("Memberships", Schema = "Club")]
    public class MembershipPlan
    {
        [Key]
        public long Id { get; set; }
        [Display(Name = "Назва абонементу")]
        [Required(ErrorMessage = "Будь-ласка, введіть назву абонементу.")]
        public string Name { get; set; }
        [Display(Name = "Короткий опис")]
        [Required, MinLength(4, ErrorMessage = "Опис абонементу не може бути настільки коротким.")]
        public string Description { get; set; }
        [Display(Name = "Період дії")]
        [Required(ErrorMessage = "Будь-ласка, оберіть період дії абонементу.")]
        public string Period { get; set; }
        [Display(Name = "Кількість тренувань")]
        [Required(ErrorMessage = "Будь-ласка, введіть кількість тренувань.")]
        public long AmountOfWorkouts { get; set; } = 1;
        [Display(Name = "Ціна")]
        [Required(ErrorMessage = "Будь-ласка, введіть ціну абонементу.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Значення параметру має бути більшим")]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }
        [Display(Name = "Кількість клієнтів")]
        public long TotalAmount { get; set; }
        [Display(Name = "Статус")]
        public string Status { get; set; }
    }
}
