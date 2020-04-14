using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Products;
using Shop.Application.ProductsAdmin;
using Shop.Application.StockAdmin;
using Shop.Application.UsersAdmin;
using Shop.Database;
using System.Threading.Tasks;

namespace Shop.UI.Controllers
{
    [Route("Admin")]
    [Authorize(Policy = "Admin")]
    public class UsersContoller : Controller
    {
        private CreateUser _createUser;

        public UsersContoller(CreateUser createUser)
        {
            _createUser = createUser;
        }
        [HttpPost("users")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUser.Request request)
        {
            await _createUser.Do(request);

            return Ok();
        }

      
    }
}
