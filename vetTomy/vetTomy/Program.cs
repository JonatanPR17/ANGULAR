using vet_tomy_domain.Store.Repositories;
using vet_tomy_domain.Store.Services;

using Microsoft.EntityFrameworkCore;
using vet_tomy_data.Sources.DataBase;
using vet_tomy_data.Store.Services;
using vet_tomy_data.Store.Repositories;
using vet_tomy_data.Utils;
using Microsoft.AspNetCore.Authentication;
using vet_tomy_domain.Auth.Repositories;
using vet_tomy_data.Auth.Repository;
using vet_tomy_data.Auth.Service;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddScoped<IStoreRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options => options.AddPolicy(name: "vet_tomy",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod();
    }

    ));
//.net es el framework de c#
//delegar responsabilidades, y que cada capa, tenga una funcion 
// controller, solo sirve datos
//Domain se encarga de hacer logica,y lo manada a data 
// agregar funciones, debemos hacer una  funcion, y hacer un this, para heredar, crear propios servicios
builder.Services.AddSwaggerGen();

//builder.Configuration.GetValue<string>("");


string conf = "Data Source=DESKTOP-MMF206J;Initial Catalog=vet_tomy;Integrated Security=True; TrustServerCertificate=True";
builder.Services.AddDbContext<VetDbContext>(
    par => par.UseSqlServer(
        conf,
        b => b.MigrationsAssembly("vet_tomy"))
    );


//Herdar mas funcionalidad al service 
//builder.Services.AddConectionDb(builder.Configuration);
builder.Services.AddScoped<vet_tomy_domain.Auth.Services.IAuthenticationService, AuthenticationServiceDbImpl>();

//Inyeccion de auth

//Inyeccion de dependencias de Store
builder.Services.AddScoped<IBrandService, BrandServiceDbImpl>();
builder.Services.AddScoped<ICategoryService, CategoryServiceDbImpl>();
builder.Services.AddScoped<IImageService, ImageServiceDbImpl>();
builder.Services.AddScoped<IProductServiceService, ProductServiceServiceDbImpl>();
builder.Services.AddScoped<IReviewService, ReviewServiceDbImpl>();
builder.Services.AddScoped<ISaleDetailService, SaleDetailServiceDbImpl>();
builder.Services.AddScoped<ISaleService, SalesServiceDbImpl>();


//Inyeccion de dependencias de Pet
builder.Services.AddScoped<IPetService, PetServiceDbImpl>();
builder.Services.AddScoped<IBreedService, BreedServiceDbImpl>();
builder.Services.AddScoped<IBranchService, BranchServiceDbImpl>();
builder.Services.AddScoped<IMedicalHistoryService, MedicalHistoryServiceDbImpl>();
builder.Services.AddScoped<IAppointmentService, AppointmentServiceDbImpl>();

//Repository
builder.Services.AddScoped<IStoreRepository, StoreRepositryImpl>();
builder.Services.AddScoped<IPetRepository, PetRepositryImpl>();
builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepositoryImpl>();

var app = builder.Build();   

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("vet_tomy");

app.MapControllers();

app.Run();
