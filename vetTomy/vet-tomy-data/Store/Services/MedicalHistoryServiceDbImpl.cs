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
    public class MedicalHistoryServiceDbImpl : IMedicalHistoryService
    {
        private readonly VetDbContext _db;

        public MedicalHistoryServiceDbImpl(VetDbContext db) 
        {
            _db = db;
        }

        public MedicalHistory CreateNewInformation(MedicalHistory entity)
        {
            MedicalHistoryTable medicalHistoryTable = entity.ToTable();
            _db.MedicalHistory.Add(medicalHistoryTable);

            int r = _db.SaveChanges();
            if (r == 1)
            {
                entity.Id = medicalHistoryTable.Id;
                return entity;
            }
            else
            {
                throw new vet_tomy_domain.Errors.MessageExeption("No se puede agregar un nuevo registro medico");
            } 
        }

        public void DeleteInformationId(int id)
        {
            MedicalHistoryTable? medicalHistoryTable = _db.MedicalHistory.FirstOrDefault(r => r.Id == id && r.State);
            if (medicalHistoryTable == null) throw new MessageExeption("No se pudo encontrar el registro medico");
            medicalHistoryTable.State = false;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se puedo eliminar el registro medico");
        }

        public List<MedicalHistory> GetAllInformation()
        {
            List<MedicalHistory> roles = _db.MedicalHistory
                .Where(b => b.State)
                .Select<MedicalHistoryTable, MedicalHistory>(
                    body => body.ToModel()
                )
                .ToList();
            return roles;
        }

        public MedicalHistory? GetInformationId(int id)
        {
            MedicalHistoryTable? medicalHistoryTable = _db.MedicalHistory.FirstOrDefault(r => r.Id == id && r.State);
            if (medicalHistoryTable == null) return null;
            return medicalHistoryTable.ToModel();
        }

        public void UpdateInformationId(int id, MedicalHistory entity)
        {
            MedicalHistoryTable? medicalHistoryTable = _db.MedicalHistory.FirstOrDefault(r => r.Id == id && r.State);
            if (medicalHistoryTable == null) throw new MessageExeption("No se encontro el registro medico");
            medicalHistoryTable.Date = entity.Date;
            medicalHistoryTable.Reason = entity.Reason;
            medicalHistoryTable.Detail = entity.Detail;
            medicalHistoryTable.AppointmentId = entity.AppointmentId;

            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se puedo actualizar el registro medico");

        }
    }
}
