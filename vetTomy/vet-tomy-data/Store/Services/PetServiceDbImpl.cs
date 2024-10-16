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
    public class PetServiceDbImpl : IPetService
    {
        private readonly VetDbContext _db;

        public PetServiceDbImpl(VetDbContext db) 
        {
            _db = db;
        }

        public Pet CreateNewInformation(Pet entity)
        {
            PetTable petTable = entity.ToTable();
            _db.Pet.Add(petTable);

            int r = _db.SaveChanges();
            if (r == 1)
            {
                entity.Id = petTable.Id;
                return entity;
            }
            else
            {
                throw new vet_tomy_domain.Errors.MessageExeption("No se puede agregar un nueva nueva mascota");
            }
        }

        public void DeleteInformationId(int id)
        {
            PetTable? petTable = _db.Pet.FirstOrDefault(r => r.Id == id && r.State);
            if (petTable == null) throw new MessageExeption("No se pudo encontrar la mascota");
            petTable.State = false;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se puedo eliminar la mascota");
        }

        public List<Pet> GetAllInformation()
        {
            List<Pet> roles = _db.Pet
                .Where(b => b.State)
                .Select<PetTable, Pet>(
                    body => body.ToModel()
                )
                .ToList();
            return roles;
        }

        public Pet? GetInformationId(int id)
        {
            PetTable? petTable = _db.Pet.FirstOrDefault(r => r.Id == id && r.State);
            if (petTable == null) return null;
            return petTable.ToModel();
        }

        public void UpdateInformationId(int id, Pet entity)
        {
            PetTable? petTable = _db.Pet.FirstOrDefault(r => r.Id == id && r.State);
            if (petTable == null) throw new MessageExeption("No se encontro la mascota");
            petTable.Name = entity.Name;
            petTable.HistoryNumber = entity.HistoryNumber;
            petTable.Birthday = entity.Birthday;
            petTable.CreationDate = entity.CreationDate;
            petTable.Image = entity.Image;
            petTable.BreedId = entity.BreedId;
            petTable.CustomerId = entity.CustomerId;

            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se puedo actualizar la mascota");
        }
    }
}
