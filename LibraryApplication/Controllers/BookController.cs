using BusinessLayer.Manager;
using BusinessLayer.Validation;
using DataAccessLayer.EntityFrameworkCore;
using EntityLayer.Entity;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApplication.Controllers;

public class BookController : Controller
{
    BookManager bookManager = new BookManager(new EfBookDal());

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult AddBook()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddBook(Book book, IFormFile? imageFile)
    {
        // Image null kontrolü ve karakter kontrolü yapıldı
        if (imageFile != null && imageFile.Length > 0)
        {
            // Yüklenecek resim wwwroot/img klasörüne kaydedildi
            var fileName = Path.GetFileName(imageFile.FileName);
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img");
            
            if (!Directory.Exists(imagePath))
            {
                Directory.CreateDirectory(imagePath);
            }
            
            using (var stream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create))
            {
                imageFile.CopyTo(stream);
            }

            book.ImageURL = fileName;
        }

        BookValidator bookValidator = new BookValidator();
        ValidationResult result = bookValidator.Validate(book);

        // Validation kontrolü yapıldı
        if (result.IsValid)
        {
            bookManager.Add(book);
            return RedirectToAction("Index", "Book");
        }
        else
        {
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
        }

        return View();
    }

    [HttpGet]
    public IActionResult BorrowBook(int id)
    {
        var bookValue = bookManager.GetById(id);
        return View(bookValue);
    }

    [HttpPost]
    public IActionResult BorrowBook(int id, string accepter, DateTime returnDate)
    {
        var bookValue = bookManager.GetById(id);
        bookValue.Status = false;
        bookValue.Accepter = accepter;
        bookValue.ReturnDate = returnDate;
        bookManager.Update(bookValue);
        return RedirectToAction("Index", "Book");
    }
}