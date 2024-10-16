using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vet_tomy_domain.Store.Models
{
    
    public class Review
    {
        public int Id { get; set; }
        public string? Comment { get; set; }
        public bool State { get; set; }
        public int CustomerId { get; set; }
    }

    public class ReviewBody
    {
        public string? Comment { get; set; }
        public bool State { get; set; }
        public int CustomerId { get; set; }
        public static implicit operator Review(ReviewBody body)
        {
            if (body == null) return null;
            return new Review
            {
                Id = 0,
                Comment = body.Comment,
                CustomerId = body.CustomerId,
                State = true,
            };
        } 
    }
}
