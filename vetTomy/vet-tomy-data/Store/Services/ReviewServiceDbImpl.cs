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
    public class ReviewServiceDbImpl : IReviewService
    {
        private readonly VetDbContext _db;

        public ReviewServiceDbImpl(VetDbContext db)
        {
            _db = db;
        }

        public Review CreateNewInformation(Review entity)
        {
            ReviewTable reviewTable = entity.ToTable();
            _db.Review.Add(reviewTable);

            int r = _db.SaveChanges();
            if (r == 1)
            {
                entity.Id = reviewTable.Id;
                return entity;
            }
            else
            {
                throw new vet_tomy_domain.Errors.MessageExeption("No se puede agregar la nueva reseña");
            }
        }

        public void DeleteInformationId(int id)
        {
            ReviewTable? reviewTable = _db.Review.FirstOrDefault(r => r.Id == id && r.State);
            if (reviewTable == null) throw new MessageExeption("No se pudo encontrar la reseña");
            reviewTable.State = false;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se puedo eliminar la reseña");
        }

        public List<Review> GetAllInformation()
        {
            List<Review> roles = _db.Review
                .Where(b => b.State)
                .Select<ReviewTable, Review>(
                    body => body.ToModel()
                )
                .ToList();
            return roles;
        }

        public Review? GetInformationId(int id)
        {
            ReviewTable? reviewTable = _db.Review.FirstOrDefault(r => r.Id == id && r.State);
            if (reviewTable == null) return null;
            return reviewTable.ToModel();
        }

        public void UpdateInformationId( int id, Review entity)
        {
            ReviewTable? reviewTable = _db.Review.FirstOrDefault(r => r.Id == id && r.State);
            if (reviewTable == null) throw new MessageExeption("No se encontro la reseña");
            reviewTable.Comment = entity.Comment;

            int r = _db.SaveChanges();
            if (r == 1) return ;
            else throw new MessageExeption("No se puedo actualizar la reseña");
        }
    }
}
