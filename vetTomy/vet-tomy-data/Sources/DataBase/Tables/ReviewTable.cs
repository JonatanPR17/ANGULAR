using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vet_tomy_data.Sources.DataBase.Tables
{
    [Table("reviews",Schema ="Store")]
    public class ReviewTable
    {
        [Key]
        public int Id { get; set; }
        public string? Comment { get; set; }
        public bool State { get; set; }
        public int CustomerId { get; set; }
    }
}
