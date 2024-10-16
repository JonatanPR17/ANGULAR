using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vet_tomy_data.Sources.DataBase.Tables;
using vet_tomy_domain.Store.Models;

namespace vet_tomy_data.Store.Extentions
{
    public static class BrandExtentions
    {
        // esta funcion que herede de brandTable, sirve para heredar
        public static Brand ToModel(this BrandTable brandBody)
        {
            return new Brand
            {
                Id = brandBody.Id,
                Name = brandBody.Name,
            };
        }
        // modelo, quitamos el estado, para no filtrar, hacemos una conversion para que nuestro dato tenga estate, y de tu base de datos te trare con state
        //
        public static BrandTable ToTable(this Brand brand) 
        {
            return new BrandTable
            {
                Id = brand.Id,
                Name = brand.Name,
                State = true,
            };
        }
    }
}
