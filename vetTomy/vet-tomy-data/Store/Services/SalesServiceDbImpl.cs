using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vet_tomy_data.Sources.DataBase;
using vet_tomy_domain.Store.Models;
using vet_tomy_domain.Store.Services;

namespace vet_tomy_data.Store.Services
{
    public class SalesServiceDbImpl : ISaleService
    {
        private readonly VetDbContext _db;

        public SalesServiceDbImpl(VetDbContext db) 
        {
            _db = db;
        }

        public Sale CreateNewInformation(Sale entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteInformationId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Sale> GetAllInformation()
        {
            throw new NotImplementedException();
        }

        public Sale? GetInformationId(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateInformationId( int id, Sale entity)
        {
            throw new NotImplementedException();
        }
    }
}
