using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vet_tomy_data.Sources.DataBase.Tables;
using vet_tomy_domain.Store.Models;

namespace vet_tomy_data.Store.Extentions
{
    public static class BranchExtentions
    {
        public static Branch ToModel(this BranchTable branchBody) 
        {
            return new Branch
            {
                Id = branchBody.Id,
                Location = branchBody.Location,
                
            };
        }

        public static BranchTable ToTable(this Branch branch)
        {
            return new BranchTable
            {
                Id = branch.Id,
                Location = branch.Location,
                State = true,
            };
        }
    }
}
