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
    public class SaleDetailServiceDbImpl : ISaleDetailService
    {
        private readonly VetDbContext _db;

        public SaleDetailServiceDbImpl(VetDbContext db)
        {
            _db = db;
        }

        public SaleDetail CreateNewInformation(SaleDetail entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteInformationId(int id)
        {
            throw new NotImplementedException();
        }

        public List<SaleDetail> GetAllInformation()
        {
            throw new NotImplementedException();
        }

        public SaleDetail? GetInformationId(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateInformationId(int id, SaleDetail entity)
        {
            throw new NotImplementedException();
        }
    }
}
