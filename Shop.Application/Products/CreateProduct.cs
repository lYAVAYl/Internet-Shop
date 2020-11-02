using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Shop.Database;
using Shop.Domain.Models;

namespace Shop.Application.Products
{
    public class CreateProduct
    {
        private ApplicationDbContext _context;

        public CreateProduct(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Создание Продукта
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        public async Task Do(ProductViewModel vm)
        { 
            await _context.Products.AddAsync(
                new Product()
                {
                    Name = vm.Name, 
                    Description = vm.Description, 
                    Value = vm.Value
                });

            await _context.SaveChangesAsync();
        }

        public class ProductViewModel
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }
        }

    }
}
