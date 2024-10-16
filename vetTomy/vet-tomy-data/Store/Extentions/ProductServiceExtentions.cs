using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vet_tomy_data.Sources.DataBase.Tables;
using vet_tomy_domain.Store.Models;

namespace vet_tomy_data.Store.Extentions
{
    public static class ProductServiceExtentions
    {
        public static ProductService ToModel(this ProducServiceTable productServiceBody) 
        {
            return new ProductService
            {
                Id = productServiceBody.Id,
                Name = productServiceBody.Name,
                Description = productServiceBody.Description,
                CategoryId = productServiceBody.CategoryId,
                BrandId = productServiceBody.BrandId,
                Price = productServiceBody.Price,
                Type = productServiceBody.Type,
                Stock = productServiceBody.Stock,
                State = true,
            };
        }

        public static ProducServiceTable ToTable(this ProductService producService)
        {
            return new ProducServiceTable
            {
                Id = producService.Id,
                Name = producService.Name,
                Description = producService.Description,
                CategoryId = producService.CategoryId,
                BrandId = producService.BrandId,
                Price = producService.Price,
                Type = producService.Type,
                Stock = producService.Stock,
                State = true,
            };
        }
    }
}
