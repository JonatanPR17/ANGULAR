using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vet_tomy_data.Sources.DataBase.Tables
{
    [Table("branchs",Schema ="Pet")]
    public class BranchTable
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Location {  get; set; }
        public bool State { get; set; }
    }
}
