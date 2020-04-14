using Microsoft.AspNetCore.Mvc;
using Shop.Application.Products;
using Shop.Application.ProductsAdmin;
using Shop.Application.StockAdmin;
using Shop.Database;
using System.Threading.Tasks;

namespace Shop.UI.Controllers
{
    [Route("Admin")]
    public class DataController : Controller
    {
        private ApplicationDbContext _ctx;

        public DataController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        [HttpGet("products")]
        public IActionResult GetProducts() => Ok(new Application.ProductsAdmin.GetProducts(_ctx).Do());
        [HttpGet("products/{Id}")]
        public IActionResult GetProduct(int id) => Ok(new GetProduct(_ctx).Do(id));
        [HttpGet("products")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProduct.Request request) => Ok((await new CreateProduct(_ctx).Do(request)));
        [HttpGet("products/{Id}")]
        public async Task<IActionResult> DeleteProduct(int id) => Ok((await new DeleteProduct(_ctx).Do(id)));
        [HttpGet("products")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProduct.Request request) => Ok(await new UpdateProduct(_ctx).Do(request));



        [HttpGet("stocks")]
        public IActionResult GetStock() => Ok(new GetStock(_ctx).Do());
      
        [HttpGet("stocks")]
        public async Task<IActionResult> CreateStock([FromBody] CreateStock.Request request) => Ok((await new CreateStock(_ctx).Do(request)));
        [HttpGet("stocks/{Id}")]
        public async Task<IActionResult> DeleteStock(int id) => Ok((await new DeleteStock(_ctx).Do(id)));
        [HttpGet("stocks")]
        public async Task<IActionResult> UpdateStock([FromBody] UpdateStock.Request request) => Ok(await new UpdateStock(_ctx).Do(request));
    }
}
