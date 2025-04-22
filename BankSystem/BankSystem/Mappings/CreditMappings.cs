namespace BankSystem.Mappings;

public static class CreditMappings
{
    public static Credit ToEntity(this CreditServiceModel model)
    {
        return new Credit()
        {
            Id = Guid.Parse(model.Id),
            UserId = model.UserId,
            Status = model.Status,
            Purpose = model.Purpose,
            RequestedAmount = model.RequestedAmount,
            DesiredRepaymentTerm = model.DesiredRepaymentTerm,
        };
    }

    public static CreditServiceModel ToModel(this Credit entity)
    {
        return new CreditServiceModel()
        {

            Id = entity.Id.ToString(),
            UserId = entity.UserId,
            Status = entity.Status,
            Purpose = entity.Purpose,
            RequestedAmount = entity.RequestedAmount,
            DesiredRepaymentTerm = entity.DesiredRepaymentTerm,
        };
    }
    
}