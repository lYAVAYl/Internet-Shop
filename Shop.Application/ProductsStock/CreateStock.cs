using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Shop.Database;
using Shop.Domain.Models;

namespace Shop.Application.StockAdmin
{
    public class CreateStock
    {
        private ApplicationDbContext _ctx;

        public CreateStock(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Response> Do(Request request)
        {
            var stock = new Stock()
            {
                Descriprion = request.Descriprion,
                Qty = request.Qty,
                ProductId = request.ProductId
            };

            await _ctx.Stocks.AddAsync(stock);
            await _ctx.SaveChangesAsync();


            return new Response()
            {
                Id = stock.Id,
                Descriprion = stock.Descriprion,
                Qty = stock.Qty
            };
        }

        public class Request
        {
            public string Descriprion { get; set; }
            public int Qty { get; set; }
            public int ProductId { get; set; }
        }

        public class Response
        {
            public int Id { get; set; }
            public string Descriprion { get; set; }
            public int Qty { get; set; }
        }
    }

}
