using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marina.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private MarinaContext dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public MarinaContext DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }       

        public DbContextTransaction BeginTransaction()
        {
           return DbContext.BeginTransaction();
        }

        public void Commit()
        {
            DbContext.Commit();
        }
    }
}
