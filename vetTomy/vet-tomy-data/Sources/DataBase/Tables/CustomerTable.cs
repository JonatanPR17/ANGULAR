using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vet_tomy_data.Sources.DataBase.Tables
{
    [Table("customers",Schema ="Security")]
    public class CustomerTable 
    {
        [Key]
        public int Id { get; set; }
        
        /*public void CustomerData()
        {
            int id = Id;

        }*/

       /* public string? Origin { get; set; }*/
        


    }

    /*public class CustomerData
    {
        public CustomerTable Od;
        public void nose()
        {
            string nose1 = Od.Name;
            string nose2 = Od.Origin;
        }
    }*/

}
