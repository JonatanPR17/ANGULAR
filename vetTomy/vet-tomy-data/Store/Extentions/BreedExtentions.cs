using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vet_tomy_data.Sources.DataBase.Tables;
using vet_tomy_domain.Store.Models;

namespace vet_tomy_data.Store.Extentions
{
    public static class BreedExtentions
    {
        public static Breed ToModel(this BreedTable breedBody) 
        {
            return new Breed
            {
                Id = breedBody.Id,
                Name = breedBody.Name,
            };
        }

        public static BreedTable ToTable(this Breed breed)
        {
            return new BreedTable
            {
                Id = breed.Id,
                Name = breed.Name,
                State = true,
            };
        }
    }
}
