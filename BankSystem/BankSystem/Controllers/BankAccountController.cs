using Microsoft.AspNetCore.Mvc;

namespace BankSystem.Controllers;

public class BankAccountController : Controller
{
    private IAccountService accountService;
    private ICurrencyService currencyService;

    public BankAccountController(IAccountService accountService)
    {
        this.accountService = accountService;
    }

    public IActionResult Details()
    {

        var model = accountService.GetAll().ToList();
        return View(model);
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(string type, string currency)
    {
        var account = new AccountServiceModel
        {
            Type = type,
            Currency = new Currency
            {
                CurrencyId = currency
            },
            Balance = "0.0",
            Id = new Guid(),
        };

        
        accountService.AddAsync(account);

        return RedirectToAction(nameof(Details));
    }
    
}