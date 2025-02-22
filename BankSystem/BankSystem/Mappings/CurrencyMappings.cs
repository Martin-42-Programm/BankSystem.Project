namespace BankSystem.Mappings;

public static class CurrencyMappings
{
    public static Currency ToEntity(this CurrencyServiceModel model)
    {
        return new Currency()
        {
            CurrencyId = model.Currency,
            ExchangeRate = double.Parse(model.ExchangeRate)
        };
    }

    public static CurrencyServiceModel ToModel(this Currency currency)
    {
        return new CurrencyServiceModel()
        {
            Currency = currency.CurrencyId,
            ExchangeRate = currency.ExchangeRate.ToString()
        };
    }
}