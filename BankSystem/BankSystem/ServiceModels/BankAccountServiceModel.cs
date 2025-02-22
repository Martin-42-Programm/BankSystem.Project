namespace BankSystem.ServiceModels;

public class BankAccountServiceModel 
{

    public Guid Id { get; set; }
    
    public string Balance { get; set; }
    
    public string Currency { get; set; }
    
    public string Type { get; set; }


}