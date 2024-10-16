using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vet_tomy_data.Sources.DataBase.Tables
{
    [Table("roles",Schema ="Security")]
    public class RoleTable
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool State { get; set; }
    }
}
