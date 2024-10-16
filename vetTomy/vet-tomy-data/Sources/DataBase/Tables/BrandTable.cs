using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vet_tomy_domain.Store.Models;

namespace vet_tomy_data.Sources.DataBase.Tables
{
    [Table("brands", Schema ="Store")]
    public class BrandTable
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string? Name { get; set; }
        public bool State { get; set; }

    }
}
