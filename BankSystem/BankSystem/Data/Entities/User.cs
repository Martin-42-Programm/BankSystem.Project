using Microsoft.AspNetCore.Identity;

namespace BankSystem.Data.Entities;

public class User : IdentityUser
{
    [Key]
    public string? Id { get; set; } 
    public string? EGN { get; set; }
    public string? FirstName { get; set; }
    public string? FathersName { get; set; }
    public string? LastName { get; set; }
    public string? IDNumber { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    
    public User()
    {
        Id = Guid.NewGuid().ToString();
        
    }
}