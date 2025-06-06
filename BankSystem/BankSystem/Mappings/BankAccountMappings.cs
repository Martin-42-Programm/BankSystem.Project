using System.Globalization;


namespace BankSystem.Mappings;

public static class BankAccountMappings
{
    private static readonly UserManager<User> _userManager;
    // Map from AccountServiceModel to Account entity
    public static BankAccount ToEntity(this BankAccountServiceModel model)
    {
        return new BankAccount()
        {
            Id = Guid.Parse(model.Id),                       // Map Guid Id
            Balance = double.Parse(model.Balance, CultureInfo.InvariantCulture),  // Use InvariantCulture to parse
            CurrencyId = model.Currency, // Map CurrencyId (assuming Currency has a CurrencyId property)
           // Currency = model.Currency,          // Map Currency object
            Type = model.Type,                   // Map Type
            UserId = model.UserId,             // Map UserId (assuming User has an Id property)
          //  User = model.User                    // Map User object
        };
    }
    
    // Map from Account entity to AccountServiceModel
    public static BankAccountServiceModel ToModel(this BankAccount entity)
    {
        return new BankAccountServiceModel
        {
            Id = entity.Id.ToString(),                     // Map Guid Id
            Balance = entity.Balance.ToString(CultureInfo.InvariantCulture),  // Use InvariantCulture for consistent formatting
            Currency = entity.CurrencyId,        // Map Currency object
            Type = entity.Type, 
            CreatedDate = entity.CreatedDate,// Map Type
           // User = entity.User,   
            UserId = entity.UserId ?? "Unknown"// Map User object
        };
    }
}
