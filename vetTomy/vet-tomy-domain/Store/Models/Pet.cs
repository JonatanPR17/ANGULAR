using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vet_tomy_domain.Store.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? HistoryNumber { get; set; }
        public DateOnly CreationDate { get; set; }
        public DateOnly? Birthday { get; set; }
        public string? Image { get; set; }
        public bool State { get; set; }
        public int BreedId { get; set; }
        public int CustomerId { get; set; }   

    }

    public class PetBody
    {
        public string? Name { get; set; }
        public int? HistoryNumber { get; set; }
        public DateOnly CreationDate { get; set; }
        public DateOnly? Birthday { get; set; }
        public string? Image { get; set; }
        public bool State { get; set; }
        public int BreedId { get; set; }
        public int CustomerId { get; set; }
        public static implicit operator Pet(PetBody body)
        {
            if (body == null) return null;
            return new Pet
            {
                Id = 0,
                Name = body.Name,
                HistoryNumber = body.HistoryNumber,
                CreationDate = body.CreationDate,
                Birthday = body.Birthday,
                BreedId = body.BreedId,
                Image = body.Image,
                CustomerId = body.CustomerId,
                State = true,

            };
        }
    }
}
