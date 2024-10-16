using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vet_tomy_data.Sources.DataBase.Tables
{
    [Table("appointments",Schema ="Pet")]
    public class AppointmentTable
    {
        [Key]
        public int AppointmentNumber { get; set; }
        public DateTime Date { get; set; }

        public TimeSpan Time { get; set; }
        public bool State { get; set; }
        public int BranchId { get; set; }
        public int PetId { get; set; }

    }
}
