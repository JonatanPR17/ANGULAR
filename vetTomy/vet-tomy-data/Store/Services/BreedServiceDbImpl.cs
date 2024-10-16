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
    public class BreedServiceDbImpl : IBreedService
     {
        private readonly VetDbContext _db;

        public BreedServiceDbImpl(VetDbContext db) 
        {
            _db = db;
        }

        public Breed CreateNewInformation(Breed entity)
        {
            BreedTable breedTable = entity.ToTable();
            _db.Breed.Add(breedTable);

            int r = _db.SaveChanges();
            if (r == 1)
            {
                entity.Id = breedTable.Id;
                return entity;
            }
            else
            {
                throw new MessageExeption("No se puede crear un nueva raza");
            }
        }

        public void DeleteInformationId(int id)
        {
            BreedTable? breedTable = _db.Breed.FirstOrDefault(r => r.Id == id && r.State);
            if (breedTable == null) throw new MessageExeption("No se pudo encontrar la raza");
            breedTable.State = false;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se puedo eliminar la raza");
        }

        public List<Breed> GetAllInformation()
        {
            List<Breed> roles = _db.Breed
                .Where(b => b.State)
                .Select<BreedTable, Breed>(
                    body => body.ToModel()
                )
                .ToList();
            return roles;
        }

        public Breed? GetInformationId(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateInformationId(int id, Breed entity)
        {
            BreedTable? breedTable = _db.Breed.FirstOrDefault(r => r.Id == id && r.State);
            if (breedTable == null) throw new MessageExeption("No se encontro la raza");
            breedTable.Name = entity.Name;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se puedo actualizar la raza");
        }
    }
}
