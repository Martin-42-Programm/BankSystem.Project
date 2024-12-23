namespace BankSystem.Data.Entities;

public class Currency
{
    [Key] 
    public string CurrencyId { get; set; }
    
    public double ExchangeRate { get; set; }
    
    
}