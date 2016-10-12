using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marina.Data
{
    public partial interface IMarinaContext
    {
        System.Data.Entity.IDbSet<ApplicationUser> Users { get; set; } // Users
        System.Data.Entity.IDbSet<MarinaRole> Roles { get; set; } // Roles
        DbContextTransaction BeginTransaction();

        void Commit();        

    }
}
