using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vet_tomy_data.Sources.DataBase;
using vet_tomy_data.Sources.DataBase.Tables;
using vet_tomy_data.Store.Extentions;
using vet_tomy_domain.Errors;
using vet_tomy_domain.Store.Models;
using vet_tomy_domain.Store.Services;

namespace vet_tomy_data.Store.Services
{
    public class AppointmentServiceDbImpl :IAppointmentService
    {
        private readonly VetDbContext _db;

        public AppointmentServiceDbImpl(VetDbContext db)
        {
            _db = db;
        }

        public Appointment CreateNewInformation(Appointment entity)
        {
            AppointmentTable appointmentTable = entity.ToTable();
            _db.Appointment.Add(appointmentTable);

            int r = _db.SaveChanges();
            if (r == 1)
            {
                entity.AppointmentNumber = appointmentTable.AppointmentNumber;
                return entity;
            }
            else
            {
                throw new MessageExeption("No se puede crear esta cita");
            }
        }

        public void DeleteInformationId(int id)
        {
            AppointmentTable? appointmentTable = _db.Appointment.FirstOrDefault(r => r.AppointmentNumber == id && r.State);
            if (appointmentTable == null) throw new MessageExeption("No se pudo encontrar la cita");
            appointmentTable.State = false;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se puedo eliminar la cita");
        }

        public List<Appointment> GetAllInformation()
        {
            List<Appointment> roles = _db.Appointment
                .Where(b => b.State)
                .Select<AppointmentTable, Appointment>(
                    body => body.ToModel()
                )
                .ToList();
            return roles;
        }

        public Appointment? GetInformationId(int id)
        {
            AppointmentTable? appointmentTable = _db.Appointment.FirstOrDefault(r => r.AppointmentNumber ==  id && r.State);
            if (appointmentTable == null) return null;
            return appointmentTable.ToModel();
        }

        public void UpdateInformationId(int id, Appointment entity)
        {
            AppointmentTable? appointmentTable = _db.Appointment.FirstOrDefault(r => r.AppointmentNumber == id && r.State);
            if (appointmentTable == null) throw new MessageExeption("No se encontro la cita");
            appointmentTable.Date = entity.Date;
            appointmentTable.Time = entity.Time;
            appointmentTable.BranchId = entity.BranchId;
            appointmentTable.PetId = entity.PetId;

            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se puedo actualizar la cita");
        }
    }
}
