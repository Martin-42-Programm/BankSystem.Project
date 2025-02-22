using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BankSystem.Data.Entities;



public class BankAccount : MetadataBaseEntity
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public string? UserId  { get; set; }
    [ForeignKey("UserId")]
    public virtual User User { get; set; }
    
    public double Balance { get; set; }
    
    [ForeignKey("Currency")]
    public string? CurrencyId { get; set; }
    
    public virtual Currency Currency { get; set; }
    
    public string Type { get; set; }

    public BankAccount()
    {
        
    }
}