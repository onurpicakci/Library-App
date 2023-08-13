using EntityLayer.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete;

public class Context : IdentityDbContext<IdentityUser, IdentityRole, string>
{
    // Context sınıfı DbContext sınıfından kalıtım alarak oluşturuldu.
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=LibraryApplication;User Id=sa;Password=myPassw0rd;TrustServerCertificate=True;");
    }
    
    public DbSet<Book> Books { get; set; }
}