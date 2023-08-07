using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Entity;

public class Book
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; }

    public string AuthorName { get; set; }

    public string ImageURL { get; set; }

    public bool Status { get; set; } = true;
    
    public string? Accepter { get; set; }
    
    public DateTime? ReturnDate { get; set; }
}