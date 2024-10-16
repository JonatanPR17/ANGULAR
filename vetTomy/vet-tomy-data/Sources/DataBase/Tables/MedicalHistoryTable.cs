using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vet_tomy_data.Sources.DataBase.Tables
{
    [Table("medicalHistory",Schema ="Pet")]
    public class MedicalHistoryTable
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? Reason { get; set; }
        public string? Detail { get; set; }
        public bool State { get; set; }
        public int AppointmentId { get; set; }
    }
}
