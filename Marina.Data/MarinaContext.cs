using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Marina.Data
{
   public partial class MarinaContext
    {

        public static MarinaContext Create()
        {
            return new MarinaContext();
        }

        public DbContextTransaction BeginTransaction()
        {
            return this.Database.BeginTransaction();
        }

        public void Commit()
        {
            SaveChanges();
        }

        public override int SaveChanges()
        {

            try
            {
                var entities = ChangeTracker.Entries().Where(x => x.Entity is IEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

                var currentUserId = 0;
                DateTime saveTime = DateTime.Now;
                foreach (var entity in entities)
                {
                    if (entity.State == EntityState.Added)
                    {
                        ((IEntity)entity.Entity).CreatedOn = saveTime;
                        ((IEntity)entity.Entity).CreatedBy = currentUserId;
                    }

                    ((IEntity)entity.Entity).UpdatedOn = saveTime;
                    ((IEntity)entity.Entity).UpdatedBy = currentUserId;
                }

                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                );
            }

        }
    }
}
