﻿using PersonalData.Model;
using PersonalData.Model.Context;

namespace PersonalData.Repository.Implementations
{
	public class PersonRepository : IPersonRepository
	{
        private MySQLContext _context;

        public PersonRepository(MySQLContext context)
		{
            _context = context;
		}

        public List<Person> FindAll()
        {
            return _context.People.ToList();
        }


        public Person FindById(long id)
        {
            return _context.People.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return person;
        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return new Person();

            var result = _context.People.SingleOrDefault(p => p.Id.Equals(person.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return person;
        }

        public void Delete(long id)
        {
            var result = _context.People.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.People.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Exists(long id)
        {
            return _context.People.Any(p => p.Id.Equals(id));
        }
    }
}
