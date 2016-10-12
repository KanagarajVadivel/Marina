using Marina.Data;
using Marina.Data.Infrastructure;
using Marina.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marina.Service
{   

    public interface IPersonService
    {
        IEnumerable<Person> GetPersons(string name = null);
        Person GetPerson(int id);        
        void CreatePerson(Person person);
        void SavePerson();
    }

    public class PersonService : IPersonService
    {
        private readonly IPersonRepository personsRepository;
        private readonly IUnitOfWork unitOfWork;

        public PersonService(IPersonRepository personsRepository, IUnitOfWork unitOfWork)
        {
            this.personsRepository = personsRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IPersonService Members

        public IEnumerable<Person> GetPersons(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return personsRepository.GetAll();
            else
                return personsRepository.GetPersonByName(name);
        }

        public Person GetPerson(int id)
        {
            var person = personsRepository.GetById(id);
            return person;
        }

        public void CreatePerson(Person person)
        {
            personsRepository.Add(person);
        }

        public void SavePerson()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}
