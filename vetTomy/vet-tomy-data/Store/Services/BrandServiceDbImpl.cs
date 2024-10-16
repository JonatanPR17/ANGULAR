using Microsoft.EntityFrameworkCore;
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
using vet_tomy_domain.Utils;

namespace vet_tomy_data.Store.Services
{
    public class BrandServiceDbImpl : IBrandService
    {

        //Realizando el constructor, para asi poder emplear las tablas que cree ahi, en otras palabras lo estamos inyectando
        private readonly VetDbContext _db;

        public BrandServiceDbImpl(VetDbContext db)
        {
            _db = db;
        }

        //Creamos una marca, convertimos nuestro modelo a un registro de tabla
        public Brand CreateNewInformation(Brand entity)
        {
            BrandTable brandTable = entity.ToTable();
            //Guardamos la nueva marca en la tabla de marcas
            _db.Brand   .Add(brandTable);

            int r = _db.SaveChanges();
            if (r == 1) 
            {
                entity.Id = brandTable.Id; //Asignamos el id generado al nuestro nuevo objeto
                return entity;  
            }
            else
            {
                throw new vet_tomy_domain.Errors.MessageExeption("No se puede crear esta nueva marca");
            }
        }
         
        public void DeleteInformationId(int id)
        {
            // En nuestro objeto, buscamos la marca por el id, y el estado active, y lo guardamos en nuestra variable
            BrandTable? brandTable = _db.Brand.FirstOrDefault(r => r.Id == id && r.State);
            //Si es nulo, lanzamos un mensaje de error
            if (brandTable == null) throw new MessageExeption("No se pudo encontrar la marca");
            //Cambiamos el estado de true, a false, para simular su eliminacion
            brandTable.State = false;
            //Guardamos los cambios en una variable
            int r = _db.SaveChanges();
            //Si la variable tiene el valor 1, significa que hubo un camnbio en la base, devolviendolo
            if (r == 1) return; 
            //Si r es 0, significa que no hubo ningun cambio, lanzando un mensaje de error
            else throw new MessageExeption("No se puedo eliminar la marca");
        }

        public List<Brand> GetAllInformation()
        {
            //Listamos todas las marcas
            List<Brand> roles = _db.Brand
                //Buscamos solo las que esten con el estado activo
                .Where(b => b.State)
                //Convertimos caga registro a un modelo de negocio
                .Select<BrandTable, Brand>(
                    body => body.ToModel()
                )
                /*.Include(x=> x.Person)*/ 
                .ToList();
            return roles;
        }



        public Brand? GetInformationId(int id)
        {
            //Creamos una objeto de nuestro tabla, este dese coincidir con el id que le pasemos y el estado deber ser true
            BrandTable? brandTable = _db.Brand.FirstOrDefault(r => r.Id == id && r.State);
            if (brandTable == null) return null ;
            return brandTable.ToModel();
        }

        public void  UpdateInformationId( int id, Brand body)
        {
            BrandTable? brandTable = _db.Brand.FirstOrDefault(r => r.Id == id && r.State);
            if (brandTable == null) throw new MessageExeption("No se encontro la marca");
            brandTable.Name = body.Name;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se puedo actualizar la marca");
        }

    }
}
