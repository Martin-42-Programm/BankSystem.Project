using Microsoft.AspNetCore.Mvc;
using BankSystem.Services;
using BankSystem.ServiceModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authorization;

namespace BankSystem.Controllers;

[Authorize(Roles = "Admin,User")]
public class BankAccountController : Controller
{
    private readonly IBankAccountService _bankAccountService;
    private readonly ICurrencyService _currencyService;
    private readonly INotificationService _notificationService;
    private readonly IHubContext<NotificationHub> _hubContext;

    public BankAccountController(
        IBankAccountService bankAccountService, 
        ICurrencyService currencyService,
        INotificationService notificationService,
        IHubContext<NotificationHub> hubContext)
    {
        _bankAccountService = bankAccountService;
        _currencyService = currencyService;
        _notificationService = notificationService;
        _hubContext = hubContext;
    }

    public IActionResult BankAccountDetails(string id)
    {
        var model = _bankAccountService.GetById(id);
        
        return View(model);
    }

    public IActionResult List(string id)
    {
        
        var query = _bankAccountService.GetAll().AsNoTracking();
        var list = new List<BankAccountServiceModel>();
        foreach (var item in query)
        {
            if (item.UserId == id)
                 list.Add(item);
                
        }
        
        
            

        var model = list.AsEnumerable();
        
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
        try
        {
            // Get bank account details before deleting
            var account = _bankAccountService.GetById(id);
            
            if (account != null)
            {
                string accountInfo = $"{account.Type} account ({account.Currency})";
                
                // Delete the account
                await _bankAccountService.DeleteAsync(id);
                
                // Create notification message
                string notificationMessage = $"{accountInfo} was successfully deleted.";
                
                // Store in TempData for toast display after redirect
                TempData["NotificationMessage"] = notificationMessage;
                
                // Also send via SignalR
                await _notificationService.NotifyAsync(
                    "00000000-0000-0000-0000-000000000006", 
                    true, 
                    $"Deleted bank account");
            }
            else
            {
                TempData["NotificationMessage"] = "Bank account not found or could not be deleted.";
            }
        }
        catch (Exception ex)
        {
            TempData["NotificationMessage"] = $"Error deleting bank account: {ex.Message}";
        }
        
        return RedirectToAction(nameof(List));
    }

    [HttpPost]
    public async Task<IActionResult> Create(string type, string currency, string id)
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
            Id = Guid.NewGuid().ToString(), 
            UserId = id
        };

        try
        {
            var result = await _bankAccountService.AddAsync(account);
            bool isSuccess = result != null;
            
            // Create notification message
            string notificationMessage = isSuccess 
                ? $"New {type} account in {currency} was successfully created!" 
                : "Failed to create new bank account.";
            
            // Store in TempData for toast display after redirect
            TempData["NotificationMessage"] = notificationMessage;
            
            // Also send via SignalR
            await _notificationService.NotifyAsync(
                "00000000-0000-0000-0000-000000000006", 
                isSuccess, 
                $"Creating new {type} account");
        }
        catch (Exception ex)
        {
            TempData["NotificationMessage"] = $"Error creating bank account: {ex.Message}";
        }

        return RedirectToAction(nameof(List), new { id = id });
    }
}

