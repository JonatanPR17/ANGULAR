using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vet_tomy_domain.Utils
{
    // Estoy creando el crud de manera global, para asi solo llamarlos en los controladores
    public interface ICrud<Data>
    {
        public List<Data> GetAllInformation();
        public Data? GetInformationId(int id);
        public Data CreateNewInformation (Data entity);
        public void UpdateInformationId(int id, Data entity);
        public void DeleteInformationId(int id);
    }
}
