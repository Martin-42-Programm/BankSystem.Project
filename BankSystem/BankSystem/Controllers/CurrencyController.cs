using Microsoft.AspNetCore.Mvc;

namespace BankSystem.Controllers;

public class CurrencyController : Controller
{
    private readonly ICurrencyService _currencyService;

    public CurrencyController(ICurrencyService currencyService)
    {
        this._currencyService = currencyService;
    }
    
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create( string currency, string exchangeRate)
    {
        if (string.IsNullOrWhiteSpace(exchangeRate) || string.IsNullOrWhiteSpace(currency))
        {
            ModelState.AddModelError("", "Type and Currency are required.");
            return View();
        }

        var account = new CurrencyServiceModel
        {
            
            Currency = currency,
            ExchangeRate = exchangeRate,
            
        };

        await _currencyService.AddAsync(account); // ✅ Ensure it's awaited.

        return RedirectToAction(nameof(Create));
    }
}