using BusinessLayer.Manager;
using DataAccessLayer.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApplication.ViewComponents.Book;

public class BookList : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        BookManager bookManager = new BookManager(new EfBookDal());
        
        var values = bookManager.GetList();
        return View(values);
    }
}