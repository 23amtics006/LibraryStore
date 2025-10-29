using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryStore.Models
{
    public class BorrowRecord
    {
        public int Id { get; set; }

        [Required] public int UserId { get; set; }
        [Required] public int BookId { get; set; }

        [ForeignKey("UserId")] public User User { get; set; }
        [ForeignKey("BookId")] public Book Book { get; set; }

        public DateTime BorrowDate { get; set; } = DateTime.Now;
        public DateTime? ReturnDate { get; set; }
        public bool IsReturned { get; set; } = false;
    }
}
