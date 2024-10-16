using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vet_tomy_domain.Store.Repositories;
using vet_tomy_domain.Store.Services;

namespace vet_tomy_data.Store.Repositories
{
    public class PetRepositryImpl : IPetRepository
    {
        private readonly IAppointmentService _appointment;
        private readonly IBranchService _branch;
        private readonly IBreedService _breed;
        private readonly IMedicalHistoryService _medicalHistory;
        private readonly IPetService _pet;

        public PetRepositryImpl(IAppointmentService appointment, IBranchService branch, IBreedService breed, IMedicalHistoryService medicalHistory, IPetService pet)
        {
            _appointment = appointment;
            _branch = branch;
            _breed = breed;
            _medicalHistory = medicalHistory;
            _pet = pet;
        }

        public IAppointmentService Appointment()
        {
            return _appointment;
        }

        public IBranchService Branch()
        {
            return _branch;
        }

        public IBreedService Breed()
        {
            return _breed;
        }

        public IMedicalHistoryService MedicalHistory()
        {
            return _medicalHistory;
        }

        public IPetService Pet()
        {
            return _pet;
        }
    }
}
