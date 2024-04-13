using System.ComponentModel.DataAnnotations;

namespace _3LayerAPI.DTOs.Note
{
    public class NoteDTO
    {
        public int Id { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(255)]
        [Display(Name = "Content")]
        public string Content { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
