using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.Data.Entities;

public class Transaction
{
    [Key]
    public Guid Id { get; set; }
    
    [ForeignKey("Account")]
    public Guid SenderAccountId { get; set; }
    
    public Account SenderAccount { get; set; }
    
    [ForeignKey("Account")]
    public Guid ReceiverAccountId { get; set; }
    
    public Account ReceiverAccount { get; set; }

    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    
    [ForeignKey("Currency")]
    public string Currency { get; set; }
    
    public string Type { get; set; }
    
    public string Status { get; set; }
    
   
    
    
}