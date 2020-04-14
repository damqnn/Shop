using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.OrdersAdmin;
using Shop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.UI.Controllers
{
    [Route("Admin")]
    [Authorize(Policy = "Manager")]
    public class OrderController :Controller
    {
        private ApplicationDbContext _ctx;

        public OrderController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        [HttpGet("orders")]
        public IActionResult GetOrders(int status) => Ok(new GetOrders(_ctx).Do(status));
        [HttpGet("ordersGet/{id}")]
        public IActionResult GetOrder(int id) => Ok(new GetOrder(_ctx).Do(id));
        [HttpPut("ordersUpdate")]
        public async Task<IActionResult> UpdateOrder(int id) => Ok(await new UpdateOrder(_ctx).Do(id));

    }
}
