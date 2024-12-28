namespace BankSystem.Mappings;

public static class AccountMappings
{
    public static Account ToEntity(this AccountServiceModel model)
    {
        throw new NotImplementedException();
    }
    
    public static AccountServiceModel ToModel(this Account entity)
    {
    
        return new AccountServiceModel
        {
            Id = entity.Id,
            Type = entity.Type,
            Balance = entity.Balance,
            
        };
    }
}