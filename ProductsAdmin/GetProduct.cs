﻿using Shop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.ProductsAdmin
{
    public class GetProduct
    {
        
        private ApplicationDbContext _ctx;

        public GetProduct(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public ProductViewModels Do(int id) =>
            _ctx.Products.Where(x => x.Id == id).ToList().Select(x => new ProductViewModels
            {
                Id= x.Id,
                Name = x.Name,
                Desctription = x.Desctription,
                Value = x.Value
            })
            .FirstOrDefault();
        public class ProductViewModels
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public string Desctription { get; set; }

            public decimal Value { get; set; }
        }
    }
}
