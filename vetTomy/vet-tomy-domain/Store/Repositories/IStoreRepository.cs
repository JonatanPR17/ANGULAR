using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vet_tomy_domain.Store.Services;

namespace vet_tomy_domain.Store.Repositories
{

    public interface IStoreRepository
    {
        public IBrandService Brand();
        public ICategoryService Category();
        public IProductServiceService ProductService();
        public ISaleDetailService SaleDetail();
        public ISaleService Sale();
        public IReviewService Review();
        public IImageService Image();
    }
}
