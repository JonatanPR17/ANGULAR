using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vet_tomy_data.Sources.DataBase.Tables
{
    //tOTAL , PRECIO,

    //Sale sub total, descuento, 

    [Table("saleDetails",Schema ="Store")]
    public class SaleDetailTable
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Precision(6, 2)]
        public decimal? Price { get; set; }
        [Required]
        public int? Quantity { get; set; }
        [Required]
        public int? ProductId { get; set; }
        [Required]
        public int? SaleId { get; set; }

    }
}
