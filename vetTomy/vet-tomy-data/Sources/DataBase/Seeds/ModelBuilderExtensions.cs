using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vet_tomy_data.Sources.DataBase.Tables;

namespace vet_tomy_data.Sources.DataBase.Seeds
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleTable>().HasData(
          new RoleTable { Id = 1, Name = "Administrador", Description = "Administrador del sistema", State = true },
          new RoleTable { Id = 2, Name = "Vendedor", Description = "Vendedor del sistema", State = true },
          new RoleTable { Id = 3, Name = "Cliente", Description = "Cliente del sistema", State = true }
            );

            modelBuilder.Entity<PersonTable>().HasData(
                new PersonTable
                {
                    Id = 1,
                    Name = "Jose",
                    LastName = "Madero",
                    DocumentType = "dni",
                    Address = "nose",
                    DocumentNumber = "45454545",
                    CellPhoneNumber = "999666331",
                    BussinessName = "Nose",
                    State = true
                },
                new PersonTable
                {
                    Id = 2,
                    Name = "Arturo",
                    LastName = "Damian",
                    DocumentType = "dni",
                    Address = "nose",
                    DocumentNumber = "45454546",
                    CellPhoneNumber = "999666332",
                    BussinessName = "Nose",
                    State = true
                },
                new PersonTable
                {
                    Id = 3,
                    Name = "Roberto",
                    LastName = "Pereira",
                    DocumentType = "dni",
                    Address = "nose",
                    DocumentNumber = "45454547",
                    CellPhoneNumber = "999666333",
                    BussinessName = "Nose",
                    State = true
                }
            );
            modelBuilder.Entity<UserTable>().HasData(
                new UserTable { Id = 1, PersonId = 1, RolId = 1, Mail = "admin@admin.com", Password = "123456", State = true, Salt = "qweretrt21212" },
                new UserTable { Id = 2, PersonId = 2, RolId = 2, Mail = "user1@user.com", Password = "123456", State = true, Salt = "qweretrt21213" },
                new UserTable { Id = 3, PersonId = 3, RolId = 3, Mail = "user2@user.com", Password = "123456", State = true, Salt = "qweretrt21213" }
                );
        }
    }
}
