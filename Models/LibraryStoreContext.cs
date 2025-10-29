using Microsoft.EntityFrameworkCore;
using LibraryStore.Models;

namespace LibraryStore.Models
{
    public class LibraryStoreContext : DbContext
    {
        public LibraryStoreContext(DbContextOptions<LibraryStoreContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BorrowRecord> BorrowRecords { get; set; }
    }
}
public static class DbInitializer
{
    public static void Seed(LibraryStoreContext context)
    {
        if (!context.Users.Any())
        {
            context.Users.Add(new User { Name = "Admin", Email = "admin@librarystore.com", Password = "admin123", Role = "Admin" });
        }

        if (!context.Books.Any())
{
    context.Books.AddRange(
        new Book { Title = "Clean Code", Author = "Robert C. Martin", Genre = "Programming" },
        new Book { Title = "The Pragmatic Programmer", Author = "Andrew Hunt & David Thomas", Genre = "Software Development" },
        new Book { Title = "Design Patterns", Author = "Erich Gamma et al.", Genre = "Software Engineering" },
        new Book { Title = "Introduction to Algorithms", Author = "Thomas H. Cormen", Genre = "Computer Science" },
        new Book { Title = "Artificial Intelligence: A Modern Approach", Author = "Stuart Russell & Peter Norvig", Genre = "Artificial Intelligence" },
        new Book { Title = "Deep Learning", Author = "Ian Goodfellow", Genre = "Machine Learning" },
        new Book { Title = "The Mythical Man-Month", Author = "Frederick P. Brooks Jr.", Genre = "Software Project Management" },
        new Book { Title = "Structure and Interpretation of Computer Programs", Author = "Harold Abelson", Genre = "Programming" },
        new Book { Title = "The Lean Startup", Author = "Eric Ries", Genre = "Business / Innovation" },
        new Book { Title = "Zero to One", Author = "Peter Thiel", Genre = "Entrepreneurship" },
        new Book { Title = "Thinking, Fast and Slow", Author = "Daniel Kahneman", Genre = "Psychology" },
        new Book { Title = "Atomic Habits", Author = "James Clear", Genre = "Self Improvement" },
        new Book { Title = "Deep Work", Author = "Cal Newport", Genre = "Productivity" },
        new Book { Title = "The Power of Habit", Author = "Charles Duhigg", Genre = "Behavioral Science" },
        new Book { Title = "The 7 Habits of Highly Effective People", Author = "Stephen Covey", Genre = "Self Development" },
        new Book { Title = "Sapiens: A Brief History of Humankind", Author = "Yuval Noah Harari", Genre = "History" },
        new Book { Title = "Homo Deus: A Brief History of Tomorrow", Author = "Yuval Noah Harari", Genre = "Future Studies" },
        new Book { Title = "The Intelligent Investor", Author = "Benjamin Graham", Genre = "Finance" },
        new Book { Title = "Rich Dad Poor Dad", Author = "Robert T. Kiyosaki", Genre = "Finance / Personal Growth" },
        new Book { Title = "The Art of War", Author = "Sun Tzu", Genre = "Strategy" },
        new Book { Title = "A Brief History of Time", Author = "Stephen Hawking", Genre = "Science" },
        new Book { Title = "Cosmos", Author = "Carl Sagan", Genre = "Astronomy" },
        new Book { Title = "The Selfish Gene", Author = "Richard Dawkins", Genre = "Biology" },
        new Book { Title = "Guns, Germs, and Steel", Author = "Jared Diamond", Genre = "History / Sociology" },
        new Book { Title = "The Innovator’s Dilemma", Author = "Clayton M. Christensen", Genre = "Innovation / Business" }
    );
}


        context.SaveChanges();
    }
}
