using BankSystem.Data.Entities;
using BankSystem.Service.Models;

namespace BankSystem.Mappings;

public static class AccountMappings
{
    public static Account ToEntity(this AccountServiceModel model)
    {
        throw new NotImplementedException();
    }
    
    public static BankSystem.Service.Models.AccountServiceModel ToModel(this Account entity)
    {
    
        return new AccountServiceModel
        {
            Id = Guid.Parse(entity.Id.ToString()),
            Type = entity.Type
            
        };
    }
}