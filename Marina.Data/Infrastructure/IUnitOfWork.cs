using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marina.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        DbContextTransaction BeginTransaction();
        void Commit();
    }
}
