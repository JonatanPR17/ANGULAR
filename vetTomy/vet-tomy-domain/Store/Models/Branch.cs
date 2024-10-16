using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vet_tomy_domain.Store.Models
{
    public class Branch
    {
        public int Id { get; set; }
        public string? Location { get; set; }
        public bool State { get; set; }
    }

    public class BranchBody
    {
        public string? Location { get; set; }
        public bool State { get; set; }
        public static implicit operator Branch(BranchBody body)
        {
            if (body == null) return null;
            return new Branch
            {
                    Id=0,
                    Location=body.Location,
                    State=true,
            };
        }
    }
}
