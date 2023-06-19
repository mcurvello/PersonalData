﻿using PersonalData.Model;
using PersonalData.Repository;

namespace PersonalData.Business.Implementations
{
	public class PersonBusiness : IPersonBusiness
	{
        private readonly IRepository<Person> _repository;

        public PersonBusiness(IRepository<Person> repository)
		{
            _repository = repository;
		}

        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }


        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
