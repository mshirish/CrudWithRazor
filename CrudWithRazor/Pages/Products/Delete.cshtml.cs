using CrudWithRazor.DAL;
using CrudWithRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CrudWithRazor.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly MyAppDbContext _context;
        public DeleteModel(MyAppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Products { get; set; }

        public async Task<IActionResult> OnGetAsync(int? itemid)
        {
            if (itemid == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == itemid);

            if (product == null)
            {
                return NotFound();
            }

            Products = product;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? itemid)
        {
            if (itemid == null)
            {
                return NotFound();
            }

            var productToDelete = await _context.Products.FindAsync(itemid);

            if (productToDelete == null)
            {
                return NotFound();
            }

            Products = productToDelete;
            _context.Remove(Products);
            await _context.SaveChangesAsync();

            return Redirect("Index");
        }
    }
}
