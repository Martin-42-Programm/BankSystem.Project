namespace BankSystem.Mappings;

public static class BankAccountMappings
{
    // Map from AccountServiceModel to Account entity
    public static BankAccount ToEntity(this BankAccountServiceModel model)
    {
        return new BankAccount()
        {
            Id = model.Id,                       // Map Guid Id
            Balance = double.Parse(model.Balance),             // Map Balance
            CurrencyId = model.Currency, // Map CurrencyId (assuming Currency has a CurrencyId property)
           // Currency = model.Currency,          // Map Currency object
            Type = model.Type,                   // Map Type
           // UserId = model.User?.Id,             // Map UserId (assuming User has an Id property)
          //  User = model.User                    // Map User object
        };
    }
    
    // Map from Account entity to AccountServiceModel
    public static BankAccountServiceModel ToModel(this BankAccount entity)
    {
        return new BankAccountServiceModel
        {
            Id = entity.Id,                     // Map Guid Id
            Balance = entity.Balance.ToString(),           // Map Balance
            Currency = entity.CurrencyId,        // Map Currency object
            Type = entity.Type,                 // Map Type
           // User = entity.User,   
         //   UserId = entity.UserId ?? "Unknown"// Map User object
        };
    }
}
