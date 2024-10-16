using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vet_tomy_domain.Store.Models
{
    public class SaleDetail
    {
        public int Id { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public int? ProductId { get; set; }
        public int? SaleId { get; set; }
    }

    public class SaleDetailBody
    {
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public int? ProductId { get; set; }
        public int? SaleId { get; set; }
        public static implicit operator SaleDetail(SaleDetailBody body)
        {
            if (body == null) return null;
            return new SaleDetail
            {
                Id = 0,
                Price = body.Price,
                Quantity = body.Quantity,
                ProductId = body.ProductId,
                SaleId = body.SaleId,
            };
        }
    }
}
