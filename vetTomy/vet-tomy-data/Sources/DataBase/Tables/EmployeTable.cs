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
    [Table("employees",Schema ="Security")]
    public class EmployeTable 
    {
        [Key]
        public int Id { get; set; }
        public string? Position { get; set; }
        [Precision(6, 2)]
        public decimal? Salary { get; set; }
        public DateOnly? Birthday { get; set; }
    }
}
