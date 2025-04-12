namespace BankSystem.ServiceModels;

public class TransactionServiceModel
{
    public string TransactionId { get; set; }
    public string ReceiverId { get; set; }
    public decimal Amount { get; set; }
    public string Type { get; set; }
    
    public string SenderId { get; set; }
    
    public string Currency { get; set; }
    
    public string Status { get; set; }
    
    public string FlagReason { get; set; }


    public TransactionServiceModel()
    {
    }
    
    
}