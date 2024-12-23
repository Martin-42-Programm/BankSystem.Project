using Microsoft.AspNetCore.Identity;

namespace BankSystem.Data.Entities;

public class User : IdentityUser
{
    public Guid Id { get; set; }
    public string EGN { get; set; }
    //public string Username { get; set; }
  //  public string Email { get; set; }
   // public string Password { get; set; }
    public string FirstName { get; set; }
    public string FathersName { get; set; }
    public string LastName { get; set; }
    public string IDNumber { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    
    
}