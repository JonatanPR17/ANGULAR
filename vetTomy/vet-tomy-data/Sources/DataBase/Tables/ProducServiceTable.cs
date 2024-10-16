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
    [Table("productServices", Schema ="Store")]
    public class ProducServiceTable
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string? Name { get; set; }
        [Required]
        [StringLength(10)]
        public string? Type { get; set; }
        [Required]
        public string? Description { get; set; }
        [Precision(6, 2)]
        public decimal? Price { get; set; }
        public int? Stock { get; set; }
        public bool State { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
    }
}
