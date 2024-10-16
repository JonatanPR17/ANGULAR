using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vet_tomy_domain.Store.Models
{
    public class Breed
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool State { get; set; }
    }

    public class BreedBody
    {
        public string? Name { get; set; }
        public bool State { get; set; }
        public static implicit operator Breed(BreedBody body)
        {
            if (body == null) return null;
            return new Breed
            {
                Id = 0,
                Name = body.Name,
                State = true,
            };
        }
    }
}
