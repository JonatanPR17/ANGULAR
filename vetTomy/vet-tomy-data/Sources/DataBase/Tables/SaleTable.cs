using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vet_tomy_data.Sources.DataBase.Tables
{
    [Table("sales", Schema ="Store")]
    public class SaleTable
    {
        [Key]
        public int SaleNumber { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public TimeSpan Time { get; set; }
        [Required]
        public string? ReceiptNumber { get; set; }
        [Required]
        public int? EmployeId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int ReceiptType { get; set; }
        public int BranchId { get; set; }
    }
}
