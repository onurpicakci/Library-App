using System.Linq.Expressions;
using EntityLayer.Entity;

namespace DataAccessLayer.Abstract;

public interface IBookDal
{
    public void Insert(Book entity);
    
    public List<Book> GetList();
    
    public Book GetById(int id);
    
    public void Update(Book entity);
}