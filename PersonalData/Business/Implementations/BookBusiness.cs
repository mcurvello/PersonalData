using PersonalData.Model;
using PersonalData.Repository;

namespace PersonalData.Business.Implementations
{
	public class BookBusiness : IBookBusiness
	{
        private readonly IRepository<Book> _repository;

        public BookBusiness(IRepository<Book> repository)
		{
            _repository = repository;
		}

        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }


        public Book FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Book Create(Book book)
        {
            return _repository.Create(book);
        }

        public Book Update(Book book)
        {
            return _repository.Update(book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
