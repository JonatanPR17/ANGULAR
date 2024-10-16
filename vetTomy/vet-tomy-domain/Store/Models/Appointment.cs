using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vet_tomy_domain.Store.Models
{
    //Estoy creando modelos de cada uno de mis tablas, para dos funciones
    // Primero, a la hora de crear o editar formularios, ya no apareceran el id, o estado, ya que esto se encargara la logica
    // Segundo, estoy inicializando cada campo, para asi poner valores por defecto 
    public class Appointment
    {
        public int AppointmentNumber { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public bool State { get; set; }
        public int BranchId { get; set; }
        public int PetId { get; set; }
    }

    public class AppointmentBody
    {
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public bool State { get; set; }
        public int BranchId { get; set; }
        public int PetId { get; set; }

        public static implicit operator Appointment(AppointmentBody body)
        {
            if (body == null) return null;
            return new Appointment
            {
                AppointmentNumber = 0,
                Date = body.Date,
                Time = body.Time,
                BranchId = body.BranchId,
                PetId = body.PetId,
                State = true,
            };

        }
    }
}
