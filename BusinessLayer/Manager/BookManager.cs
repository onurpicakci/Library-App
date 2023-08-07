using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entity;

namespace BusinessLayer.Manager;

public class BookManager : IBookService
{
    private readonly IBookDal _bookDal;
    
    public BookManager(IBookDal bookDal)
    {
        _bookDal = bookDal;
    }
    
    public void Add(Book entity)
    {
        _bookDal.Insert(entity);
    }

    public List<Book> GetList()
    {
        return _bookDal.GetList();
    }

    public Book GetById(int id)
    {
        return _bookDal.GetById(id);
    }

    public void Update(Book entity)
    {
        _bookDal.Update(entity);
    }
}