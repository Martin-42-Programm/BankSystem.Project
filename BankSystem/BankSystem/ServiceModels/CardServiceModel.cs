namespace BankSystem.ServiceModels;

public class CardServiceModel
{
    public string Type { get; set; }
    public string Number { get; set; }
   // public string Pseudonym { get; set; }
    public bool IsActive { get; set; }
    public string Id { get; set; }
    
    public DateTime ExpirationDate { get; set; }

    public CardServiceModel()
    {
        
    }
}