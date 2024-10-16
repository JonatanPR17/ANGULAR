using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vet_tomy_data.Sources.DataBase.Tables
{
    [Table("images",Schema ="Store")]
    public class ImageTable
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Url { get; set; }
        public bool State { get; set; }
        [Required]
        public int ProductServiceId { get; set; }

    }
}
