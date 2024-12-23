namespace BankSystem.Data.Entities;

public class Office
{
    [Key]
    public Guid Id { get; set; }
    
    public string Address { get; set; }
    
    public string Postcode { get; set; }
    
    public string City { get; set; }
    public string Country { get; set; }
    
    public WorkingTime WorkingTime { get; set; }
}