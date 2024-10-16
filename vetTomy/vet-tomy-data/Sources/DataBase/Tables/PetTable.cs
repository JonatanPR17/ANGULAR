using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vet_tomy_data.Sources.DataBase.Tables
{
    [Table("pets",Schema ="Pet")]
    public class PetTable
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public int? HistoryNumber { get; set; }
        public DateOnly CreationDate { get; set; }
        public DateOnly? Birthday { get; set; }
        public bool State { get; set; }
        public string? Image {  get; set; }
        public int BreedId { get; set; }
        public int CustomerId { get; set; }


    }
}
