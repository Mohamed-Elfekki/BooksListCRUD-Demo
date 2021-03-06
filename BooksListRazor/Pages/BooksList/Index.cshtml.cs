using BooksListRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksListRazor.Pages.BooksList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public IndexModel(ApplicationDbContext db)
        {
            this.db = db;

        }
        public IEnumerable<Book> Books { get; set; }
        public async Task OnGet()
        {
            Books = await db.Books.ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = await db.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            db.Books.Remove(book);
            await db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
