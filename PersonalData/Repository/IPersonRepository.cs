﻿using PersonalData.Data.VO;
using PersonalData.Model;

namespace PersonalData.Repository
{
	public interface IPersonRepository : IRepository<Person>
	{
		Person Disable(long id);
		List<Person> FindByName(string firstName, string lastName);
    }
}
