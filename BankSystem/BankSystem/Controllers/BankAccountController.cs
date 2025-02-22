using Microsoft.AspNetCore.Mvc;
using BankSystem.Services;
using BankSystem.ServiceModels;

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

    public IActionResult Details()
    {
        
        // var accounts = _bankAccountService.GetAll()
        //     .Select(account => new
        //     {
        //         account.Id,
        //         UserId = account.UserId != null ? account.UserId : "Unknown", // Avoiding ?? for compatibility
        //        
        //     })
        //     .ToList();
        
        var query = _bankAccountService.GetAll().AsNoTracking();
        
        var model = query.AsEnumerable();
        foreach (var account in model)
        {
            Console.WriteLine($"Account: {account.Id}");
        }
        return View(model);
    }

    public IActionResult Create()
    {
        return View();
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
            Id = Guid.NewGuid(), // ✅ Use Guid.NewGuid() instead of new Guid()
           // UserId = "00000000-0000-0000-0000-00000000000"
        };

        await _bankAccountService.AddAsync(account); // ✅ Ensure it's awaited.

        return RedirectToAction(nameof(Details));
    }
}