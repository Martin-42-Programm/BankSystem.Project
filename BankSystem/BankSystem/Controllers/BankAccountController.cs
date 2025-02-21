using Microsoft.AspNetCore.Mvc;

namespace BankSystem.Controllers;

public class BankAccountController : Controller
{
    private AccountService accountService;

    public BankAccountController(AccountService accountService)
    {
        this.accountService = accountService;
    }

    public IActionResult Details()
    {
        
        
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(AccountServiceModel BankAccount)
    {

        if (BankAccount == null)
           return View(nameof(Create));
        accountService.AddAsync(BankAccount);

        return RedirectToAction(nameof(Details));
    }
    
}