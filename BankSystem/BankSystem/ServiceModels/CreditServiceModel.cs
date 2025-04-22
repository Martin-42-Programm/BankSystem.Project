namespace BankSystem.ServiceModels;

public class CreditServiceModel
{
    public string Id { get; set; }
    
    public string UserId { get; set; }
    
    //public virtual User User { get; set; }
    
    public decimal RequestedAmount { get; set; }
    
    public string Purpose { get; set; }
    
    public string Status { get; set; }
    
    public DateTime DesiredRepaymentTerm { get; set; }
}