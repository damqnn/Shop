using Microsoft.EntityFrameworkCore;
using Shop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Products
{
    public class GetProducts
    {
        
        private ApplicationDbContext _ctx;

        public GetProducts(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public IEnumerable<ProductViewModels> Do() =>
            _ctx.Products
            .Include(x => x.Stock)
            .Select(x => new ProductViewModels
            {
                Name = x.Name,
                Desctription = x.Desctription,
                Value = $"${x.Value.ToString("N2")}",
                StockCount = x.Stock.Sum(y => y.Qty)
            }).ToList();
        public class ProductViewModels
        {
            public string Name { get; set; }

            public string Desctription { get; set; }

            public string Value { get; set; }
            public int StockCount { get; set; }
            
        }
    }
}
