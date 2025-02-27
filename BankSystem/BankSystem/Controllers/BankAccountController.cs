using Microsoft.AspNetCore.Mvc;
using BankSystem.Services;
using BankSystem.ServiceModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BankSystem.Controllers;

public class BankAccountController : Controller
{
    private readonly IBankAccountService _bankAccountService;
    private readonly ICurrencyService _currencyService;

    public BankAccountController(IBankAccountService bankAccountService, ICurrencyService currencyService)
    {
        _bankAccountService = bankAccountService;
        _currencyService = currencyService;
    }

    public IActionResult BankAccountDetails(string id)
    {
        var model = _bankAccountService.GetById(id);
        
        return View(model);
    }

    public IActionResult List()
    {
        var query = _bankAccountService.GetAll().AsNoTracking();
        
        var model = query.AsEnumerable();
        
        return View(model);
    }

    public IActionResult Create()
    {
        var currencies = _currencyService.GetAll().AsEnumerable()
            .Select(c => new SelectListItem
            {
                Value = c.Currency,    // Currency code (e.g., "USD")
                Text = c.Currency      // Currency name (e.g., "US Dollar")
            }).ToList();
        //TODO: Multiple choice for type of bankaccount
        ViewBag.Currencies = currencies; // Pass to the view
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Delete(string id)
    {
        await _bankAccountService.DeleteAsync(id);
        
        return RedirectToAction(nameof(List));
    }

    [HttpPost]
    public async Task<IActionResult> Create(string type, string currency)
    {
        if (string.IsNullOrWhiteSpace(type) || string.IsNullOrWhiteSpace(currency))
        {
            ModelState.AddModelError("", "Type and Currency are required.");
            return View();
        }

        var account = new BankAccountServiceModel
        {
            Type = type,
            Currency = currency,
            Balance = "0.0",
            Id = Guid.NewGuid().ToString(), // ✅ Use Guid.NewGuid() instead of new Guid()
           // UserId = "00000000-0000-0000-0000-00000000000"
        };

        await _bankAccountService.AddAsync(account); // ✅ Ensure it's awaited.

        return RedirectToAction(nameof(List));
    }
}