namespace BankSystem.Mappings;

public static class AccountMappings
{
    public static Account ToEntity(this AccountServiceModel model)
    {
        return new Account()
        {
            Id = model.Id,
            Balance = model.Balance,
            Currency = model.Currency,
            Type = model.Type,
            User = model.User
        };
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