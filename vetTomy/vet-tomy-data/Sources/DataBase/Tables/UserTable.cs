using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vet_tomy_data.Sources.DataBase.Tables
{
    [Table("users",Schema ="Security")]
    public class UserTable
    {
        [Key]
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int RolId { get; set; }
        [StringLength(50)]
        public string? Mail { get; set; }
        [StringLength(512)]
        public string? Password { get; set; }
        [StringLength(128)]
        public string Salt { get; set; }
        public bool State { get; set; }

        /*[ForeignKey("PersonId")]
        public virtual PersonTable Person { get; set; }

        [ForeignKey("RolId")]
        public virtual RoleTable Role { get; set; }*/

    }
}
