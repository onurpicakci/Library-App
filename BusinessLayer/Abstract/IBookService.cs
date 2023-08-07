using EntityLayer.Entity;

namespace BusinessLayer.Abstract;

public interface IBookService
{
    public void Add(Book entity);
    
    public List<Book> GetList();
    
    public Book GetById(int id);
    
    public void Update(Book entity);
}