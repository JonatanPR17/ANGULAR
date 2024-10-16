using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vet_tomy_domain.Store.Models
{
    public class MedicalHistory
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? Reason { get; set; }
        public string? Detail { get; set; }
        public bool State { get; set; }
        public int AppointmentId { get; set; }
    }

    public class MedicalHistoryBody
    {
        public DateTime Date { get; set; }
        public string? Reason { get; set; }
        public string? Detail { get; set; }
        public bool State { get; set; }
        public int AppointmentId { get; set; }
        public static implicit operator MedicalHistory(MedicalHistoryBody body)
        {
            if (body == null) return null;
            return new MedicalHistory
            {
                Id = 0,
                Date = body.Date,
                Reason = body.Reason,
                Detail = body.Detail,
                AppointmentId = body.AppointmentId,
                State = true,
            };
        }
    }
}
