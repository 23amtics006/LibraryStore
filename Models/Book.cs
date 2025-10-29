using System.ComponentModel.DataAnnotations;

namespace LibraryStore.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required] public string Title { get; set; }
        [Required] public string Author { get; set; }
        public string Genre { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}
