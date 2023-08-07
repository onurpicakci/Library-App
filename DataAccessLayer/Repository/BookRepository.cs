using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Entity;

namespace DataAccessLayer.Repository;

public class BookRepository : IBookDal
{
    // IBookDal'dan implemente edilen metotlar bu sınıfta override edildi.
    public void Insert(Book entity)
    {
        using var context = new Context();
        context.Add(entity);
        context.SaveChanges();
    }

    public List<Book> GetList()
    {
        using var context = new Context();
        return context.Books.OrderBy(x => x.Name).ToList();
    }

    public Book GetById(int id)
    {
        using var context = new Context();
        return context.Books.Find(id);
    }

    public void Update(Book entity)
    {
        using var context = new Context();
        context.Update(entity);
        context.SaveChanges();
    }
}