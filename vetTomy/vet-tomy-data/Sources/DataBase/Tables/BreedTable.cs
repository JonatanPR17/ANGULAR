using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vet_tomy_data.Sources.DataBase.Tables
{
    [Table("breeds",Schema ="Pet")]
    public class BreedTable
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public bool State { get; set; }
    }
}
