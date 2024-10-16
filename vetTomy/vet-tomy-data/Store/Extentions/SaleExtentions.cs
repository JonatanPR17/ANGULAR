using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vet_tomy_data.Sources.DataBase.Tables;
using vet_tomy_domain.Store.Models;

namespace vet_tomy_data.Store.Extentions
{
    public static class SaleExtentions
    {
        public static Sale ToModel(this SaleTable saleBody)
        {
            return new Sale
            {
                SaleNumber = saleBody.SaleNumber,
                Date = saleBody.Date,
                Time = saleBody.Time,
                ReceiptType = saleBody.ReceiptType,
                ReceiptNumber = saleBody.ReceiptNumber,
                EmployeId = saleBody.EmployeId,
                CustomerId = saleBody.CustomerId,
                BranchId = saleBody.BranchId,
            };
        }

        public static SaleTable ToTable(this Sale sale)
        {
            return new SaleTable
            {
                SaleNumber = sale.SaleNumber,
                Date = sale.Date,
                Time = sale.Time,
                ReceiptType = sale.ReceiptType,
                ReceiptNumber = sale.ReceiptNumber,
                EmployeId = sale.EmployeId,
                CustomerId = sale.CustomerId,
                BranchId = sale.BranchId,
            };
        }
    }
}
