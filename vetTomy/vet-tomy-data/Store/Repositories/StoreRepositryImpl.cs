using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vet_tomy_domain.Store.Repositories;
using vet_tomy_domain.Store.Services;

namespace vet_tomy_data.Store.Repositories
{
    public class StoreRepositryImpl : IStoreRepository
    {
        private readonly IBrandService _brand;
        private readonly ICategoryService _category;
        private readonly IImageService _image;
        private readonly IProductServiceService _productService;
        private readonly IReviewService _review;
        private readonly ISaleDetailService _saleDetail;
        private readonly ISaleService _sale;    

        public StoreRepositryImpl(
            IBrandService brand,
            ICategoryService category, 
            IImageService image, 
            IProductServiceService productService, 
            IReviewService review, 
            ISaleDetailService saleDetail, 
            ISaleService sale)
        {
            _brand = brand;
            _category = category;
            _image = image;
            _productService = productService;
            _review = review;
            _saleDetail = saleDetail;
            _sale = sale;
        }

        public IBrandService Brand()
        {
            return _brand;
        }
            
        public ICategoryService Category()
        {
            return _category;
        }

        public IImageService Image()
        {
            return _image;
        }

        public IProductServiceService ProductService()
        {
            return _productService;
        }

        public IReviewService Review()
        {
            return _review;
        }

        public ISaleService Sale()
        {
            return _sale;
        }

        public ISaleDetailService SaleDetail()
        {
            return _saleDetail;
        }
    }
}
