using CrudWithRazor.DAL;
using CrudWithRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrudWithRazor.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly MyAppDbContext _context;

        public CreateModel(MyAppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Products { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync() 
        {
            if (!ModelState.IsValid || _context.Products == null || Products == null)
            { 
                return Page();
            }
            _context.Products.Add(Products);
            await _context.SaveChangesAsync();
            return RedirectToPage(nameof(Index));
        }
    }
}
