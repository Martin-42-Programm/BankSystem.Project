namespace BankSystem.ServiceModels;

public class OfficeServiceModel
{
    
    public string Address { get; set; }
    public string Postcode { get; set; }
    public string City { get; set; }
    public string Country { get; set; }

    public OfficeServiceModel()
    {
        
    }
    public OfficeServiceModel(string address, string postcode, string city, string country)
    {
        Address = address;
        Postcode = postcode;
        City = city;
        Country = country;
    }
}