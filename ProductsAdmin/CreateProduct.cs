using Shop.Database;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.ProductsAdmin
{
    public class CreateProduct
    {
        private ApplicationDbContext _context;

        public CreateProduct(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response> Do(Request request)
        {
            var product = new Product
            {
                Name = request.Name,
                Desctription = request.Desctription,
                Value = request.Value,
            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return new Response
            {
                Id = product.Id,
                Name = product.Name,
                Desctription = product.Desctription,
                Value = product.Value
            };
        }
        

    public class Request
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Desctription { get; set; }

        public decimal Value { get; set; }
    }
        public class Response
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public string Desctription { get; set; }

            public decimal Value { get; set; }
        }
    }
}
