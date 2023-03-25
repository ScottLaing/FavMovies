using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace testWebMVCApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Ranking")]
        [Range(1,1000,ErrorMessage ="Range must be between 1 and 1000!")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public string LastChangedBy { get; set; } = "scott";
        public DateTime LastChangedTime { get; set; } = DateTime.Now;
    }
}
