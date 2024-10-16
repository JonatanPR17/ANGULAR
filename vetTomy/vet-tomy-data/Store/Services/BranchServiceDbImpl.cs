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
    public class BranchServiceDbImpl : IBranchService
    {
        private readonly VetDbContext _db;

        public BranchServiceDbImpl(VetDbContext db)  
        {
            _db = db; 
        }

        public Branch CreateNewInformation(Branch entity)
        {
            BranchTable branchTable = entity.ToTable();
            _db.Branch.Add(branchTable);

            int r = _db.SaveChanges();
            if (r == 1)
            {
                entity.Id = branchTable.Id;
                return entity;
            }
            else
            {
                throw new MessageExeption("No se puede crear un nuevo establecimiento");
            }
        }

        public void DeleteInformationId(int id)
        {
            BranchTable? branchTable = _db.Branch.FirstOrDefault(r => r.Id == id && r.State);
            if (branchTable == null) throw new MessageExeption("No se pudo encontrar el establecimiento");
            branchTable.State = false;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se puedo eliminar el establecimiento");
        }

        public List<Branch> GetAllInformation()
        {
            List<Branch> roles = _db.Branch
                .Where(b => b.State)
                .Select<BranchTable, Branch>(
                    body => body.ToModel()
                )
                .ToList();
            return roles;
        }

        public Branch? GetInformationId(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateInformationId(int id, Branch entity)
        {
            BranchTable? branchTable = _db.Branch.FirstOrDefault(r => r.Id == id && r.State);
            if (branchTable == null) throw new MessageExeption("No se encontro el establecimiento");
            branchTable.Location = entity.Location;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se puedo actualizar el establiecimiento");
        }
    }
}
