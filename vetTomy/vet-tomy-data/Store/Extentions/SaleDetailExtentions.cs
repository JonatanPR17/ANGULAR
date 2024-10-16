using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vet_tomy_data.Sources.DataBase.Tables;
using vet_tomy_domain.Store.Models;

namespace vet_tomy_data.Store.Extentions
{
    public static class SaleDetailExtentions
    {
        public static SaleDetail ToModel(this SaleDetailTable detailBody) 
        {
            return new SaleDetail
            {
                Id = detailBody.Id,
                Price = detailBody.Price,
                Quantity = detailBody.Quantity,
                ProductId = detailBody.ProductId,
                SaleId = detailBody.SaleId,
            };
        }

        public static SaleDetailTable ToTable(this SaleDetail detail) 
        {
            return new SaleDetailTable
            {
                Id = detail.Id,
                Price = detail.Price,
                Quantity = detail.Quantity,
                ProductId = detail.ProductId,
                SaleId = detail.SaleId,
            };
        } 
    }
}
