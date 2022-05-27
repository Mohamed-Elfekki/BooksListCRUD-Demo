using BooksListRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace BooksListRazor.Pages.BooksList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext db;
        public EditModel(ApplicationDbContext db)
        {
            this.db = db;
        }
        [BindProperty]
        public Book Book { get; set; }
        public async Task OnGet(int id)
        {
            Book = await db.Books.FindAsync(id);

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var book = await db.Books.FindAsync(Book.Id);
                book.Name = Book.Name;
                book.Author = Book.Author;
                book.ISBN = Book.ISBN;

                await db.SaveChangesAsync();
                return RedirectToPage("Index");

            }
            return Page();

        }
    }
}
