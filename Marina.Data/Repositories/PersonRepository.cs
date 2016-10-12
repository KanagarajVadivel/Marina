using Marina.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marina.Data.Repositories
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public IEnumerable<Person> GetPersonByName(string personName)
        {
            return this.DbContext.People.Where(c => (c.FirstName + " " +c.LastName).Contains(personName)).ToList();
        }       
    }

    public interface IPersonRepository : IRepository<Person>
    {
        IEnumerable<Person> GetPersonByName(string personName);
    }
}
