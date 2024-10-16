using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vet_tomy_domain.Store.Models
{
    public class Sale
    {
        public int SaleNumber { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string? ReceiptNumber { get; set; }
        public int? EmployeId { get; set; }
        public int CustomerId { get; set; }
        public int ReceiptType { get; set; }
        public int BranchId { get; set; }
    }

    public class SaleBody
    {
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string? ReceiptNumber { get; set; }
        public int? EmployeId { get; set; }
        public int CustomerId { get; set; }
        public int ReceiptType { get; set; }
        public int BranchId { get; set; }
        public static implicit operator Sale(SaleBody body)
        {
            if (body == null) return null;
            return new Sale
            {
                SaleNumber = 0,
                Date = body.Date,
                Time = body.Time,
                ReceiptNumber = body.ReceiptNumber,
                EmployeId = body.EmployeId,
                CustomerId = body.CustomerId,
                ReceiptType = body.ReceiptType,
                BranchId = body.BranchId,
            };
        }
    }
}
