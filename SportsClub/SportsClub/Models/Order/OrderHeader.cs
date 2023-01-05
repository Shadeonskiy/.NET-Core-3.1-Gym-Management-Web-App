using SportsClub.Areas.Identity.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsClub.Models.Order
{
    [Table("OrderHeaders", Schema = "Order")]
    public class OrderHeader
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Ім'я користувача")]
        [Required(ErrorMessage = "Поле 'Ім'я' обов'язкове!")]
        public string Name { get; set; }
        [Display(Name = "Користувач (Id)")]
        public string UserId { get; set; }
        [Display(Name = "Користувач (Id)")]
        [ForeignKey("UserId")]
        public AppUser User { get; set; }
        [Phone]
        [Display(Name = "Номер телефону")]
        [Required(ErrorMessage = "Поле 'Номер телефону' обов'язкове!")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Поле 'Тренер' обов'язкове!")]
        [Display(Name = "Тренер")]
        public string Performer { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Display(Name = "Дата виконання")]
        [Required(ErrorMessage = "Поле 'Дата виконання' обов'язкове!")]
        public DateTime ExecutionDate { get; set; }
        [Display(Name = "Тип оплати")]
        [Required(ErrorMessage = "Поле 'Тип оплати' обов'язкове!")]
        public string PaymentType { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        public int ServiceCount { get; set; }
    }
}
