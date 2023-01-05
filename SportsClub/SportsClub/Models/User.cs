using System.ComponentModel.DataAnnotations;

namespace SportsClub.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Нікнейм")]
        [Required(ErrorMessage = "Поле 'Нікнейм' обов'язкове!")]
        public string Username { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Ім'я користувача")]
        [Required(ErrorMessage = "Поле 'Ім'я' обов'язкове!")]
        public string FirstName { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Прізвище")]
        [Required(ErrorMessage = "Поле 'Прізвище' обов'язкове!")]
        public string LastName { get; set; }
        [EmailAddress]
        [Display(Name = "Пошта")]
        [Required(ErrorMessage = "Поле 'Пошта' обов'язкове!")]
        public string Email { get; set; }
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Поле 'Пароль' обов'язкове!")]
        public string Password { get; set; }
        [Phone]
        [Display(Name = "Номер телефону")]
        [Required(ErrorMessage = "Поле 'Номер телефону' обов'язкове!")]
        public string PhoneNumber { get; set; }
        public User()
        {

        }
    }
}
