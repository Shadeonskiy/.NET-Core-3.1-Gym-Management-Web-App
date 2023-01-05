using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SportsClub.Models;
using System.IO;

namespace SportsClub.Data
{
    public class SeedData
    {
        public static void SeedDatabase(SportsClubContext context)
        {
            context.Database.Migrate();
            if (!context.Services.Any())
            {
                var training = new Category { Name = "Тренувальні послуги", URLFriendlyName = "training services" };
                var goods = new Category { Name = "Товари", URLFriendlyName = "goods" };

                context.Services.AddRange(
                    new Service
                    {
                        Name = "Тренування у групах",
                        URLFriendlyName = "group training",
                        Description = "Наш клуб надає вам можливість тренуватися у групах",
                        Price = 1000,
                        Category = training,
                        Image = "group.jpg"
                    },
                    new Service
                    {
                        Name = "Тренажерна зала",
                        URLFriendlyName = "gym",
                        Description = "Чим старшим ти стаєш, тим менше у тебе стає м'язових волокон: " +
                        "\"швидких\" - приблизно на 50 відсотків і \"повільних\" - на 25 відсотків. " +
                        "Але необхідно враховувати, що за силу і реакцію відповідають безпосередньо " +
                        "«швидкі» волокна.\r\nЕластичні м'язи та міцні кістки – ще один величезний плюс " +
                        "занять у тренажерному залі.\nПри виконанні силових вправ значно прискорюється " +
                        "інтенсивність циркуляції крові в організмі, а кров'яний тиск зменшується, що " +
                        "допоможе тобі уникнути таких серйозних захворювань як інсульт та інфаркт. Також " +
                        "знижується рівень цукру на крові, що допомагає уникнути цукрового діабету. Крім " +
                        "всього, спостереження показують, що регулярні заняття у тренажерному залі зменшують " +
                        "окислювальний стрес, а це не що інше як профілактика раку.",
                        Price = 2000,
                        Category = training,
                        Image = "gym.jpg"
                    },
                    new Service
                    {
                        Name = "Аксесуари",
                        URLFriendlyName ="accessories",
                        Description = "Ви можете придбати у нас будь-які аксесуари для тренувань, які полегшать " +
                        "вашу роботу в майбутньому",
                        Price = 500,
                        Category = goods,
                        Image = "accessories.jpg"
                    });
                context.SaveChanges();
            }
        }
    }
}
