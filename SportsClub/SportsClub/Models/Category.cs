using System.ComponentModel.DataAnnotations.Schema;

namespace SportsClub.Models
{
    [Table("Categories", Schema = "Cart")]
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string URLFriendlyName { get; set; }
    }
}
