using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vet_tomy_data.Sources.DataBase.Tables;
using vet_tomy_domain.Store.Models;

namespace vet_tomy_data.Store.Extentions
{
    public static class CategoryExtentions
    {
        public static Category ToModel(this CategoryTable categoryBody)
        {
            return new Category
            {
                Id = categoryBody.Id,
                CategoryId = categoryBody.CategoryId,
                Name = categoryBody.Name,
            };
        }

        public static CategoryTable ToTable(this Category category) 
        {
            return new CategoryTable
            {
                Id = category.Id,
                CategoryId = category.CategoryId,
                Name = category.Name,
                State = true,
            };
        }
    }
}
