using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vet_tomy_data.Sources.DataBase.Tables;
using vet_tomy_domain.Store.Models;

namespace vet_tomy_data.Store.Extentions
{
    public static class ReviewExtentions
    {
        public static Review ToModel(this ReviewTable reviewBody)
        {
            return new Review
            {
                Id = reviewBody.Id,
                Comment = reviewBody.Comment,
                CustomerId = reviewBody.CustomerId,
            };
        }

        public static ReviewTable ToTable(this Review review)
        {
            return new ReviewTable 
            {
                Id = review.Id,
                Comment = review.Comment,
                CustomerId = review.CustomerId,
                State = true,
            };
        }
    }
}
