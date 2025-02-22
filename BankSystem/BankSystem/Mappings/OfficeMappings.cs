namespace BankSystem.Mappings;

public static class OfficeMappings
{
    public static Office ToEntity(this OfficeServiceModel model)
    {
        return new Office()
        {
            Id = Guid.NewGuid(),
            Address = model.Address,
            City = model.City,
            Country = model.Country,
            Postcode = model.Postcode
        };
    }

    public static OfficeServiceModel ToModel(this Office office)
    {
        return new OfficeServiceModel(
            office.Address,
            office.City,
            office.Country,
            office.Postcode);
        
    }
}