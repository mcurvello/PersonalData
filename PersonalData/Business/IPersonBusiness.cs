using PersonalData.Data.VO;
using PersonalData.Hypermedia.Utils;

namespace PersonalData.Business
{
	public interface IPersonBusiness
	{
		PersonVO Create(PersonVO person);
		PersonVO FindById(long id);
		List<PersonVO> FindByName(string firstName, string lastName);
		List<PersonVO> FindAll();
		PersonVO Update(PersonVO person);
		PersonVO Disable(long id);
		void Delete(long id);
		PagedSearchVO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);

	}
}
