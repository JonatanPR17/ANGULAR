using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vet_tomy_domain.Store.Services;

namespace vet_tomy_domain.Store.Repositories
{
    //Estoy separando mis tablas en dos repositorios, para asi poder realizar consultas mas facil y rapido, ademas que conecto mis servicios y modelos, 
    public interface IPetRepository
    {
        public IPetService Pet();
        public IBreedService Breed();
        public IAppointmentService Appointment();
        public IMedicalHistoryService MedicalHistory();
        public IBranchService Branch();
    }
}
