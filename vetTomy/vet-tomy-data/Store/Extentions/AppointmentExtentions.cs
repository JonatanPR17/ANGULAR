using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vet_tomy_data.Sources.DataBase.Tables;
using vet_tomy_domain.Store.Models;

namespace vet_tomy_data.Store.Extentions
{
    public static class AppointmentExtentions
    {
        public static Appointment ToModel (this AppointmentTable appointmentBody) 
        {
            return new Appointment
            {
                AppointmentNumber = appointmentBody.AppointmentNumber,
                Date = appointmentBody.Date,
                Time = appointmentBody.Time,
                BranchId = appointmentBody.BranchId,
                PetId = appointmentBody.PetId,
            };
        }

        public static AppointmentTable ToTable(this Appointment appointment)
        {
            return new AppointmentTable
            {
                AppointmentNumber = appointment.AppointmentNumber,
                Date = appointment.Date,
                Time = appointment.Time,
                BranchId = appointment.BranchId,
                PetId= appointment.PetId,
                State = true,
            };
        }
    }
}
