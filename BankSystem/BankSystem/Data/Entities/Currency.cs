namespace BankSystem.Data.Entities;

public class Currency : MetadataBaseEntity
{
    [Key] 
    public string CurrencyId { get; set; }
    
    public double ExchangeRate { get; set; }
    
    
}