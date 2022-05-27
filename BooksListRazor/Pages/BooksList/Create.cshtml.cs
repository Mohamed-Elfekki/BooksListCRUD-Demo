using BooksListRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace BooksListRazor.Pages.BooksList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext db;
        public CreateModel(ApplicationDbContext db)
        {
            this.db = db;
        }
        [BindProperty]
        public Book Book { get; set; }
        public void OnGet()
        {


        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await db.Books.AddAsync(Book);
                await db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
