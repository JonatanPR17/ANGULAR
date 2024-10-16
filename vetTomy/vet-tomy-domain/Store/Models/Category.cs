using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vet_tomy_domain.Store.Models
{
    public class Category
    {
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public string? Name { get; set; }
        public bool State { get; set; }
    }

    public class CategoryBody
    {
        public int? CategoryId { get; set; }
        public string? Name { get; set; }

        public static implicit operator Category(CategoryBody body)
        {
            if (body == null) return null;
            return new Category
            {
                Id = 0,
                CategoryId = body.CategoryId,
                Name = body.Name,
            };
        }

    }

}
