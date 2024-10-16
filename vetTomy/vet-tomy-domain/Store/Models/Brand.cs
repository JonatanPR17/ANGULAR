using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vet_tomy_domain.Store.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool State { get; set; }
    }

    public class BrandBody
    {
        public string? Name { get; set; }

        public static implicit operator Brand(BrandBody body)
        {
            if (body == null) return null;
            return new Brand
            {
                Id = 0,
                Name = body.Name,
            };
        }
    }
}
