using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.Data.Entities;

public class Card
{
    [Key]
    public Guid Id { get; set; }
    
    [ForeignKey("User")]
    public string CardholderId { get; set; }
    
    public virtual User User { get; set; }
    
    public string Number { get; set; }
    public string Type { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string SecretCode { get; set; }
    
    
    
    /*public virtual void DisplayCardInfo()
    {
        Console.WriteLine($"Cardholder: ");
        Console.WriteLine($"Expiration Date: {ExpirationDate}");
        Console.WriteLine($"Card Number: {CardNumber}");
    }*/
    
}