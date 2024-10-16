using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vet_tomy_data.Sources.DataBase;

namespace vet_tomy_data.Utils
{
    //para no tener la conexion de base de datos en el program 
    public static class ConfigDbConect
    {
        //agregar nueva funcinalidad a program
       /*public static void AddConectionDb(this IServiceCollection service , IConfiguration configuration)
        {

            if (configuration["ConnectionStrings:VetTomyDb"] != null) {
                string? conf = configuration["ConnectionStrings:VetTomyDb"];

                service.AddDbContext<VetDbContext>(
                par => par.UseSqlServer(
                    conf,
                    b => b.MigrationsAssembly("vet_tomy"))
                );

            } 

            
        }*/
    }
}
