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
    public class ImageServiceDbImpl : IImageService
    {
        private readonly VetDbContext _db;

        public ImageServiceDbImpl(VetDbContext db) 
        {
            _db = db;
        }

        public Image CreateNewInformation(Image entity)
        {
            ImageTable imageTable = entity.ToTable();
            _db.Image.Add(imageTable);

            int r = _db.SaveChanges();
            if (r == 1)
            {
                entity.Id = imageTable.Id;
                return entity;
            }
            else
            {
                throw new vet_tomy_domain.Errors.MessageExeption("No se puede agregar una nueva imagen");
            }
        }

        public void DeleteInformationId(int id)
        {
            ImageTable? imageTable = _db.Image.FirstOrDefault(r => r.Id == id && r.State);
            if (imageTable == null) throw new MessageExeption("No se pudo encontrar la imagen");
            imageTable.State = false;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se puedo eliminar la imagen");
        }

        public List<Image> GetAllInformation()
        {
            throw new NotImplementedException();
        }

        public Image? GetInformationId(int id)
        {
            ImageTable? imageTable = _db.Image.FirstOrDefault(r => r.Id == id && r.State);
            if (imageTable == null) return null;
            return imageTable.ToModel();
        }

        public void UpdateInformationId( int id, Image entity)
        {
            ImageTable? imageTable = _db.Image.FirstOrDefault(r => r.Id == id && r.State);
            if (imageTable == null) throw new MessageExeption("No se encontro la imagen");
            imageTable.Url = entity.Url;
            imageTable.ProductServiceId = entity.ProducServiceId;

            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se puedo actualizar la imagen");
        }
    }
}
