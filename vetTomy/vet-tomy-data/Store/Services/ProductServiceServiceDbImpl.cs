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
    public class ProductServiceServiceDbImpl : IProductServiceService
    {
        private readonly VetDbContext _db;

        public ProductServiceServiceDbImpl(VetDbContext db) 
        {
            _db = db;
        }

        public ProductService CreateNewInformation(ProductService entity)
        {
            ProducServiceTable productServiceTable = entity.ToTable();
            _db.ProducService.Add(productServiceTable);

            int r = _db.SaveChanges();
            if (r == 1)
            {
                entity.Id = productServiceTable.Id;
                return entity;
            }
            else
            {
                throw new vet_tomy_domain.Errors.MessageExeption("No se puede agregar el nuevo producto o servicio");
            }
        }

        public void DeleteInformationId(int id)
        {
            ProducServiceTable? productServiceTable = _db.ProducService.FirstOrDefault(r => r.Id == id && r.State);
            if (productServiceTable == null) throw new MessageExeption("No se pudo encontrar el producto o servicio");
            productServiceTable.State = false;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se puedo eliminar el producto o servicio");
        }

        public List<ProductService> GetOnlyProducts()
        {
            List<ProductService> roles = _db.ProducService
                .Where(b =>b.Type =="Servicio" && b.State)
                .Select<ProducServiceTable, ProductService>(
                    body => body.ToModel()
                )
                .ToList();
            return roles;
        }

        public List<ProductService> GetAllInformation()
        {
            List<ProductService> roles = _db.ProducService
                .Where(b => b.State)
                .Select<ProducServiceTable, ProductService>(
                    body => body.ToModel()
                )
                .ToList();
            return roles;
        }

        public ProductService? GetInformationId(int id)
        {
            ProducServiceTable? productServiceTable = _db.ProducService.FirstOrDefault(r => r.Id == id && r.State);
            if (productServiceTable == null) return null;
            return productServiceTable.ToModel();
        }

        public void UpdateInformationId( int id, ProductService entity)
        {
            ProducServiceTable? productServiceTable = _db.ProducService.FirstOrDefault(r => r.Id == id && r.State);
            if (productServiceTable == null) throw new MessageExeption("No se encontro el producto u imagen");
            productServiceTable.Name = entity.Name;
            productServiceTable.Description = entity.Description;
            productServiceTable.Price = entity.Price;
            productServiceTable.Stock = entity.Stock;
            productServiceTable.Type = entity.Type;
            productServiceTable.BrandId = entity.BrandId;
            productServiceTable.CategoryId = entity.CategoryId;

            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se puedo actualizar el producto o image");
        }
    }
}
