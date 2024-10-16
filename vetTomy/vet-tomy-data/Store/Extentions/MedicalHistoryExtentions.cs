using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vet_tomy_data.Sources.DataBase.Tables;
using vet_tomy_domain.Store.Models;

namespace vet_tomy_data.Store.Extentions
{
    public static class MedicalHistoryExtentions
    {
        public static MedicalHistory ToModel(this MedicalHistoryTable historyBody) 
        {
            return new MedicalHistory
            {
                Id = historyBody.Id,
                Date = historyBody.Date,
                Reason = historyBody.Reason,
                Detail = historyBody.Detail,
                AppointmentId = historyBody.AppointmentId,
            };
        }

        public static MedicalHistoryTable ToTable(this MedicalHistory history) 
        {
            return new MedicalHistoryTable
            {
                Id = history.Id,
                Date = history.Date,
                Reason = history.Reason,
                Detail = history.Detail,
                AppointmentId = history.AppointmentId,
                State = true,
            };
        }   
    }
}
