using CrudWithRazor.DAL;
using CrudWithRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CrudWithRazor.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly MyAppDbContext _context;

        public IndexModel(MyAppDbContext context)
        {
            _context = context;
        }
        public List<Product> Products { get; set; }
        public async Task OnGetAsync()
        {
            if(_context.Products != null)
            {
                Products = await _context.Products.ToListAsync();
            }
        }
    }
}
