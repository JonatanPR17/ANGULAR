using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vet_tomy_domain.Store.Models;
using vet_tomy_domain.Utils;

namespace vet_tomy_domain.Store.Services
{
    //Estoy conectando cada Interfaz de mi tablas con el crud que cree globalmente
    public interface IAppointmentService : ICrud<Appointment>
    {
    }
}
