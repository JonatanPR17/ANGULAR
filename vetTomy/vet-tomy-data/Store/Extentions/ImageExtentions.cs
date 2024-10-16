using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vet_tomy_data.Sources.DataBase.Tables;
using vet_tomy_domain.Store.Models;

namespace vet_tomy_data.Store.Extentions
{
    public static class ImageExtentions
    {
        public static Image ToModel(this ImageTable imageBody) 
        {
            return new Image
            {
                Id = imageBody.Id,
                ProducServiceId = imageBody.ProductServiceId,
                Url = imageBody.Url,
            };
        }

        public static ImageTable ToTable(this Image image) 
        {
            return new ImageTable
            {
                Id = image.Id,
                 ProductServiceId = image.ProducServiceId,
                Url = image.Url,
                State = true,
            };
        }
    }
}
