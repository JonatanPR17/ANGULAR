using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vet_tomy_domain.Store.Models
{
    public class ProductService
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? Stock { get; set; }
        public bool State { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
    }

    public class ProductServiceBody
    {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? Stock { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }

        public static implicit operator ProductService(ProductServiceBody body)
        {
            if (body == null) return null;
            return new ProductService
            {
                Id = 0,
                Name = body.Name,
                Type = body.Type,
                Description = body.Description,
                Price = body.Price,
                Stock = body.Stock,
                BrandId = body.BrandId,
                CategoryId = body.CategoryId,
                State = true,
            };
        }

    }
}
