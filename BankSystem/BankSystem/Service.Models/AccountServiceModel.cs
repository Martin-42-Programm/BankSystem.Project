namespace BankSystem.Service.Models;

public class AccountServiceModel : MetadataBaseServiceModel
{

    public Guid Id { get; set; }
    

    
    public virtual User User { get; set; }
    
    public string Balance { get; set; }


    
    public virtual Currency Currency { get; set; }
    
    public string Type { get; set; }


}