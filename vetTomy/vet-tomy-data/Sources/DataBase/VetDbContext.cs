using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vet_tomy_data.Sources.DataBase.Seeds;
using vet_tomy_data.Sources.DataBase.Tables;

namespace vet_tomy_data.Sources.DataBase
{
    public class VetDbContext : DbContext
    {
        public VetDbContext( DbContextOptions<VetDbContext> opts ) 
            : base(opts) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Brand-ProductService
            modelBuilder.Entity<BrandTable>()
                .HasMany<ProducServiceTable>()
                .WithOne()
                .HasForeignKey(p => p.BrandId)
                .IsRequired();

            //Category-ProductService
            modelBuilder.Entity<CategoryTable>()
                .HasMany<ProducServiceTable>()
                .WithOne()
                .HasForeignKey(p=>p.CategoryId)
                .IsRequired();

            //Image-ProductService
            modelBuilder.Entity<ProducServiceTable>()
                .HasMany<ImageTable>()
                .WithOne()
                .HasForeignKey(i=>i.ProductServiceId)
                .IsRequired();

            //ProductService to SaleDetail
            modelBuilder.Entity<ProducServiceTable>()
                .HasMany<SaleDetailTable>()
                .WithOne()
                .HasForeignKey(s=>s.ProductId)
                .IsRequired();

            //Sale to SaleDetail
            modelBuilder.Entity<SaleTable>()
                .HasMany<SaleDetailTable>()
                .WithOne()
                .HasForeignKey(sd=>sd.SaleId)
                .IsRequired();


            //Person to User
            modelBuilder.Entity<PersonTable>()
                .HasOne<UserTable>()
                .WithOne()
                .HasForeignKey<UserTable>(u=>u.PersonId)
                .IsRequired();

            //Role to User
            modelBuilder.Entity<RoleTable>()
                .HasMany<UserTable>()
                .WithOne()
                .HasForeignKey(r=>r.RolId)
                .IsRequired();

            //Branch to Sail
            modelBuilder.Entity<BranchTable>()
                .HasMany<SaleTable>()
                .WithOne()
                .HasForeignKey (s=>s.BranchId)
                .IsRequired();

            //Breed to Pet
            modelBuilder.Entity<BreedTable>()
                .HasMany<PetTable>()
                .WithOne()
                .HasForeignKey(p=>p.BreedId)
                .IsRequired();

            //Pet to Appointment 
            modelBuilder.Entity<PetTable>()
                .HasMany<AppointmentTable>()
                .WithOne()
                .HasForeignKey(a=>a.PetId)
                .IsRequired();


            //Branch to Appointment
            modelBuilder.Entity<BranchTable>()
                .HasMany<AppointmentTable>()
                .WithOne()
                .HasForeignKey(a => a.BranchId)
                .IsRequired();

            //Apointment  to MedicalHistory
            modelBuilder.Entity<AppointmentTable>()
                .HasMany<MedicalHistoryTable>()
                .WithOne()
                .HasForeignKey(mh=>mh.AppointmentId)
                .IsRequired();

            //Customer to Review
           modelBuilder.Entity<CustomerTable>()
                .HasMany<ReviewTable>()
                .WithOne()
                .HasForeignKey(r=>r.CustomerId)
                .IsRequired();

            // Customer to Pet
            modelBuilder.Entity<CustomerTable>()
                .HasMany<PetTable>()
                .WithOne()
                .HasForeignKey(p=>p.CustomerId)
                .IsRequired();


            //Category to category
            modelBuilder.Entity<CategoryTable>()
                .HasMany<CategoryTable>()
                .WithOne()
                .HasForeignKey(c => c.CategoryId);

            //Employe to sale
            /*modelBuilder.Entity<EmployeTable>()
                .HasMany<SaleTable>()
                .WithOne()
                .HasForeignKey(s=>s.EmployeId)
                .IsRequired();

            //Customer to Sale
            modelBuilder.Entity<CustomerTable>()
                .HasMany<SaleTable>()
                .WithOne()
                .HasForeignKey(s => s.CustomerId)
                .IsRequired();*/


            modelBuilder.Seed();
        }

        #region Tables Store
        public DbSet<ProducServiceTable> ProducService { get; set; }
        public DbSet<CategoryTable> Category { get; set; }   
        public DbSet<BrandTable> Brand { get; set; } 
        public DbSet<ImageTable> Image { get; set; }
        public DbSet<SaleTable> Sale { get; set; }
        public DbSet<SaleDetailTable> SaleDetail { get; set; }
        public DbSet<ReviewTable> Review { get; set; }
        #endregion

        #region Tables Security
        public DbSet<RoleTable> Role { get; set; }
        public DbSet<UserTable> User { get; set; }
        public DbSet<PersonTable> Person { get; set; }
        public DbSet<EmployeTable> Employe { get; set; }
        public DbSet<CustomerTable> Customer { get; set; }

        #endregion

        #region Tables Pet
        public DbSet<PetTable> Pet { get; set; }
        public DbSet<BreedTable> Breed { get; set; }
        public DbSet<AppointmentTable> Appointment { get; set; }
        public DbSet<MedicalHistoryTable> MedicalHistory { get; set; }
        public DbSet<BranchTable> Branch { get; set; }
        #endregion

    }
}
