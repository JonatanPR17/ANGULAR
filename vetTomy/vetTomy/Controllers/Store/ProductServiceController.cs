using Microsoft.AspNetCore.Mvc;
using vet_tomy.Models;
using vet_tomy_data.Sources.DataBase;
using vet_tomy_domain.Errors;
using vet_tomy_domain.Store.Models;
using vet_tomy_domain.Store.Repositories;

namespace vet_tomy.Controllers.Store
{
    [ApiController]
    [Route("api/store/products_services")]
    public class ProductServiceController : ControllerBase
    {
        private readonly ILogger<ProductServiceController> _logger;
        private readonly IStoreRepository _storeRepo;
        private readonly VetDbContext _db;

        public ProductServiceController(ILogger<ProductServiceController> logger, IStoreRepository storeRepo, VetDbContext db)
        {
            _logger = logger;
            _storeRepo = storeRepo;
            _db = db;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<ProductService>> ListAll()
        {
            try
            {
                List<ProductService> productService = _storeRepo.ProductService().GetAllInformation();
                return Ok(productService);
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[ProductServiceController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[ProductServiceController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }


        [HttpGet]
        [Route("{id}")]
        public ActionResult<ProductService> GetOnlyId([FromRoute] int id)
        {
            try
            {
                ProductService? productService = _storeRepo.ProductService().GetInformationId(id);
                if (productService == null)
                {
                    return NotFound();
                }
                return Ok(productService);
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[ProductServiceController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[ProductServiceController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }


        [HttpGet]
        [Route("join/{id}")]
        public ActionResult All([FromRoute] int id )
        {
            var request = _db.ProducService
                .Where(i => i.Id == id && i.State )
                .Join(
                _db.Brand,
                (p) => p.BrandId,
                (b) => b.Id,
                (p, b) => new { po = p, br = b }
                ).Join(
                _db.Category,
                (pb) => pb.po.CategoryId,
                (c) => c.Id,
                (pb, c) => new { po = pb, c = c }
                ).Join(
                _db.Image,
                (pbc) => pbc.po.po.Id,
                (i) => i.ProductServiceId,
                (pbc, i) => new
                {
                    id = pbc.po.po.Id,
                    name = pbc.po.po.Name,
                    type = pbc.po.po.Type,
                    description = pbc.po.po.Description,
                    price = pbc.po.po.Price,
                    stock = pbc.po.po.Stock,
                    brand = pbc.po.br.Name,
                    category = pbc.c.Name,
                    image = new { i.Url }
                }
                ).ToList().FirstOrDefault();
            return Ok(request);
        }


        [HttpGet]
        [Route("only_products")]
        public ActionResult JoinAllProduct()
        {
            var request = _db.ProducService
                .Where(s=>s.State)
                .Join(
                _db.Brand,
                (p) => p.BrandId,
                (b) => b.Id,
                (p,b) => new { po = p, br = b }
                ).Join(
                _db.Category,
                (pb)=>pb.po.CategoryId,
                (c) => c.Id,
                (pb, c) => new { po = pb, c = c }
                ).GroupJoin(
                _db.Image,
                (pbc)=> pbc.po.po.Id,
                (i) => i.ProductServiceId,
                (pbc , i) => new 
                {
                    id = pbc.po.po.Id,
                    name=pbc.po.po.Name,
                    type=pbc.po.po.Type,
                    description=pbc.po.po.Description,
                    price=pbc.po.po.Price,
                    stock=pbc.po.po.Stock,
                    brand=pbc.po.br.Name,
                    category=pbc.c.Name,
                    image = i
                }
                ).Where(a => a.type == "Producto").ToList();
            return Ok(request);
        }

        [HttpGet]
        [Route("only_service")]
        public ActionResult JoinAllService()
        {
            var request = _db.ProducService
                .Where(s=>s.State)
                .Join(
                _db.Brand,
                (p) => p.BrandId,
                (b) => b.Id,
                (p, b) => new { po = p, br = b }
                ).Join(
                _db.Category,
                (pb) => pb.po.CategoryId,
                (c) => c.Id,
                (pb, c) => new { po = pb, c = c }
                ).GroupJoin(
                _db.Image,
                (pbc) => pbc.po.po.Id,
                (i) => i.ProductServiceId,
                (pbc, i) => new
                {
                    id = pbc.po.po.Id,
                    name = pbc.po.po.Name,
                    type = pbc.po.po.Type,
                    description = pbc.po.po.Description,
                    image = i
                }
                ).Where(a => a.type == "Servicio").ToList();
            return Ok(request);
        }



        [HttpPost]
        [Route("")]
        public ActionResult<ProductService> Create([FromBody] ProductServiceBody body)
        {
            try
            {
                ProductService productService = _storeRepo.ProductService().CreateNewInformation((ProductService)body);
                return Ok(productService);
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[ProductServiceController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[ProductServiceController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<CustomResponse> Update([FromRoute] int id, [FromBody] ProductServiceBody body)
        {
            try
            {
                _storeRepo.ProductService().UpdateInformationId( id, (ProductService)body);
                return Ok(new CustomResponse());
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[ProductServiceController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[ProductServiceController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<CustomResponse> Delete([FromRoute] int id)
        {
            try
            {
                _storeRepo.ProductService().DeleteInformationId(id);
                return Ok(new CustomResponse());
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[ProductServiceController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[ProductServiceController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

    }
}
