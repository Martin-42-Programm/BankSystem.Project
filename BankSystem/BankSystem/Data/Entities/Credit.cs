using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.Data.Entities;

public class Credit
{
    [Key]
    public Guid Id { get; set; }
    
    [ForeignKey("User")]
    public string UserId { get; set; }
    
    public virtual User User { get; set; }
    
    public decimal RequestedAmount { get; set; }
    
    public string Purpose { get; set; }
    
    public DateTime DesiredRepaymentTerm { get; set; }
}