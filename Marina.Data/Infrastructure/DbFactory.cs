using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marina.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        MarinaContext dbContext;

        public MarinaContext Init()
        {
            return dbContext ?? (dbContext = new MarinaContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
