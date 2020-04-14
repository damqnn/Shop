using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Products;
using Shop.Application.ProductsAdmin;
using Shop.Database;
using static Shop.Application.ProductsAdmin.CreateProduct;

namespace Shop.UI.Pages
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _ctx;

        public IndexModel(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        //private readonly ILogger<IndexModel> _logger;

        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}
        [BindProperty]
        public Request Product { get; set; }

        public IEnumerable<Application.Products.GetProducts.ProductViewModels> Products { get; set; }

        public void OnGet()
        {
            Products = new Application.Products.GetProducts(_ctx).Do();
        }
        public async Task<IActionResult> OnPost()
        {
            await new CreateProduct(_ctx).Do(Product);
            return RedirectToPage("Index");
        }

        
    }
}
