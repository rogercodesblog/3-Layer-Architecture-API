using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _3LayerAPI.Models
{
    [Table("Notes")]
    public class Note
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(255)]
        [Display(Name = "Content")]
        public string Content { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
