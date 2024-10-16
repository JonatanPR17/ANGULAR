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
    public class CategoryServiceDbImpl : ICategoryService
    {
        private readonly VetDbContext _db;

        public CategoryServiceDbImpl(VetDbContext db) 
        {
            _db = db;
        }

        public Category CreateNewInformation(Category entity)
        {
            CategoryTable categoryTable = entity.ToTable();
            _db.Category.Add(categoryTable);

            int r = _db.SaveChanges();
            if (r == 1)
            {
                entity.Id = categoryTable.Id; 
                return entity;
            }
            else
            {
                throw new MessageExeption("No se puede crear esta nueva categoria");
            }
        }

        public void DeleteInformationId(int id)
        {
            CategoryTable? categoryTable = _db.Category.FirstOrDefault(r => r.Id == id && r.State);
            if (categoryTable == null) throw new MessageExeption("No se pudo encontrar la categoria");
            categoryTable.State = false;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se puedo eliminar la categoria");
        }

        public List<Category> GetAllInformation()
        {
            List<Category> roles = _db.Category
                .Where(b => b.State)
                .Select<CategoryTable, Category>(
                    body => body.ToModel()
                )
                .ToList();
            return roles;
        }

        public Category? GetInformationId(int id)
        {
            CategoryTable? categoryTable = _db.Category.FirstOrDefault(r => r.Id == id && r.State);
            if (categoryTable == null) return null;
            return categoryTable.ToModel();
        }

        public void UpdateInformationId( int id, Category entity)
        {
            CategoryTable? categoryTable = _db.Category.FirstOrDefault(r => r.Id == id && r.State);
            if (categoryTable == null) throw new MessageExeption("No se encontro la categoria");
            categoryTable.Name = entity.Name;

            int r = _db.SaveChanges();
            if (r == 1) return ;
            else throw new MessageExeption("No se puedo actualizar la categoria");
        }
    }
}
