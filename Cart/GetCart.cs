﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Shop.Database;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Cart
{
    public class GetCart
    {
        private ISession _session;
        private ApplicationDbContext _ctx;

        public GetCart(ISession session, ApplicationDbContext ctx)
        {
            _session = session;
            _ctx = ctx;
        }

        public class Response
        {
            public string Name { get; set; }
            public string Value  { get; set; }
            public decimal ValueDec { get; set; }
            public int Qty { get; set; }
            public decimal TotalValue { get; set; }
            public int StockId { get; set; }

        }
        
        public IEnumerable<Response> Do()
        {
            
            var stringObject = _session.GetString("cart");
            if (string.IsNullOrEmpty(stringObject))
            {
                return new List<Response>();

            }
            
            
            var cartList = JsonConvert.DeserializeObject<List<CartProduct>>(stringObject);

            var response = cartList.Select(item => _ctx.Stock.Include(x => x.Product)
                    .Where(x => x.Id == item.StockId)
                    .Select(x => new Response
                    {
                        Name = x.Product.Name,
                        Value = $"$ {x.Product.Value.ToString("N2")}",
                        ValueDec = x.Product.Value,
                        StockId = item.StockId,
                        Qty = item.Qty,
                        TotalValue = x.Product.Value * item.Qty

                    })
                    .FirstOrDefault())
                    .ToList();

                return response;
            
            
        }
    }
}
