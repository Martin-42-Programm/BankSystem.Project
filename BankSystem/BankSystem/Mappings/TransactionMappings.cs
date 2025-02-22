namespace BankSystem.Mappings;

public static class TransactionMappings
{
    public static Transaction ToEntity(this TransactionServiceModel model)
    {
        return new Transaction()
        { 
            Id = Guid.Parse(model.TransactionId),
            ReceiverAccountId = Guid.Parse(model.ReceiverId),
            Amount = model.Amount,
            Type = model.Type
        };
    }
    
    
    public static TransactionServiceModel ToModel(this Transaction entity)
    {
        return new TransactionServiceModel()
        {
            ReceiverId = entity.ReceiverAccountId.ToString(),
            Amount = entity.Amount,
            Type = entity.Type,
            TransactionId = entity.Id.ToString(),
        };
    }
}