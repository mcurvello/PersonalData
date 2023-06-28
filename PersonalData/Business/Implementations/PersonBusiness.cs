﻿using PersonalData.Data.Converter.Implementations;
using PersonalData.Data.VO;
using PersonalData.Model;
using PersonalData.Repository;

namespace PersonalData.Business.Implementations
{
	public class PersonBusiness : IPersonBusiness
	{
        private readonly IPersonRepository _repository;
        private readonly PersonConverter _converter;


        public PersonBusiness(IPersonRepository repository)
		{
            _repository = repository;
            _converter = new PersonConverter();
		}

        public List<PersonVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }


        public PersonVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }

        public PersonVO Disable(long id)
        {
            var personEntity = _repository.Disable(id);
            return _converter.Parse(personEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
