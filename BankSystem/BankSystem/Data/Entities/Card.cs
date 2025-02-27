using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.Data.Entities;

public class Card : MetadataBaseEntity
{
    [Key]
    public string Number { get; set; }
    
    [ForeignKey("User")]
    public string CardholderId { get; set; }
    
    public virtual User User { get; set; }
    
    public string Type { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string SecretCode { get; set; }
    public bool IsActive { get; set; }

    public string PickupOffice { get; set; }

    public string Pseudonym { get; set; }


    /*public virtual void DisplayCardInfo()
    {
        Console.WriteLine($"Cardholder: ");
        Console.WriteLine($"Expiration Date: {ExpirationDate}");
        Console.WriteLine($"Card Number: {CardNumber}");
    }*/
    
}