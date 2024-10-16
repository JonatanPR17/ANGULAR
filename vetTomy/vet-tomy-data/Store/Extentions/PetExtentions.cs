using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vet_tomy_data.Sources.DataBase.Tables;
using vet_tomy_domain.Store.Models;

namespace vet_tomy_data.Store.Extentions
{
    public static class PetExtentions
    {
        public static Pet ToModel(this PetTable petBody) 
        {
            return new Pet
            {
                Id = petBody.Id,
                Name = petBody.Name,
                HistoryNumber = petBody.HistoryNumber,
                CreationDate = petBody.CreationDate,
                Birthday = petBody.Birthday,
                Image = petBody.Image,
                BreedId = petBody.BreedId,
                CustomerId = petBody.CustomerId,

            };
        }

        public static PetTable ToTable(this Pet pet)
        {
            return new PetTable
            {
                Id = pet.Id,
                Name = pet.Name,
                HistoryNumber = pet.HistoryNumber,
                CreationDate = pet.CreationDate,
                Birthday = pet.Birthday,
                Image = pet.Image,
                BreedId = pet.BreedId,
                CustomerId = pet.CustomerId,
                State = true,
            };
        }
    }
}
