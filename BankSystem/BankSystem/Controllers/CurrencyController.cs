using Microsoft.AspNetCore.Mvc;

namespace BankSystem.Controllers;
[Authorize(Roles = "Admin")]
public class CurrencyController : Controller
{
    private readonly ICurrencyService _currencyService;

    public CurrencyController(ICurrencyService currencyService)
    {
        this._currencyService = currencyService;
    }
    public IActionResult List()
    {
        var query = _currencyService.GetAll().AsNoTracking();
        
        var model = query.ToList();
        
        return View(model);
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
    
    
    [HttpPost]
    public async Task<IActionResult> Delete(string id)
    {
        // Get the card to determine its type
        var currency = await _currencyService.GetByIdAsync(id);
        
        if (currency != null)
        {

            string notificationMessage = $"Debit card ({currency.Currency}) was successfully deleted.";
           
            await _currencyService.DeleteAsync(id);
            
            
            
            TempData["NotificationMessage"] = notificationMessage;
            
         
           
        }
        else
        {
            TempData["NotificationMessage"] = "Card not found or could not be deleted.";
        }
        
        return RedirectToAction(nameof(List));
    }
}