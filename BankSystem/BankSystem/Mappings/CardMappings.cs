namespace BankSystem.Mappings;

public static class CardMappings
{
    public static Card ToEntity(this CardServiceModel model)
    {
        Random random = new Random();
        return new Card()
        {
           // Id = Guid.TryParse(model.Id, out Guid parsedId) ? parsedId : Guid.NewGuid(),
            Type = model.Type,
            CardholderId = "00000000-0000-0000-0000-000000000006",
            SecretCode = random.Next(100, 999).ToString(),
            IsActive = model.IsActive,
            ExpirationDate = model.ExpirationDate,
            Number = model.Number,
            PickupOffice = model.PickupOffice,
            Pseudonym = model.Pseudonym
        };
    }

    public static CardServiceModel ToModel(this Card entity)
    {
        return new CardServiceModel()
        {
            //Id = entity.Id.ToString(),
            Type = entity.Type,
           // Pseudonym = entity.CardholderId,
            Number = entity.Number,
            IsActive = entity.IsActive,
            ExpirationDate = entity.ExpirationDate,
            PickupOffice = entity.PickupOffice,
            Pseudonym = entity.Pseudonym
        };
    }
}