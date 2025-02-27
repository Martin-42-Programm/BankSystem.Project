using Microsoft.AspNetCore.Mvc;

namespace BankSystem.Controllers;

public class TransactionController : Controller
{
    private readonly ITransactionService _transactionService;
    private readonly IBankAccountService _bankAccountService;

    public TransactionController(ITransactionService transactionService, IBankAccountService bankAccountService)
    {
        this._transactionService = transactionService;
        this._bankAccountService = bankAccountService;
    }
    
    public IActionResult NewTransaction(string senderId, string currency)
    {
        ViewBag.Currency = currency;
        ViewBag.SenderId = senderId;
        return View("Create");
    }

    public IActionResult List()
    {
        var query = _transactionService.GetAll().AsNoTracking();
        
        var model = query.ToList();
        
        return View(model);
    }
   

    [HttpPost]
    public async Task<IActionResult> Create(string receiverId, decimal amount, string senderId, string currency, string type)
    {
        if (string.IsNullOrWhiteSpace(receiverId) 
            || string.IsNullOrWhiteSpace(senderId)
            || string.IsNullOrWhiteSpace(currency)
            || string.IsNullOrWhiteSpace(type)
            )
            
        {
            ModelState.AddModelError("", "Type and Currency are required.");
            return View();
        }

        var transaction = new TransactionServiceModel()
        {
            Amount = amount,
            ReceiverId = receiverId,
            Type = type,
            TransactionId = Guid.NewGuid().ToString(),
            SenderId = senderId,
            Currency = currency,
            Status = "Working on"
            
        };
        
        var accounts = _bankAccountService.GetAllAsNoTracking();
        var list = accounts.ToList();
        var senderAccount = list.FirstOrDefault(c => c.Id == senderId);
        var receiverAccount = list.FirstOrDefault(c => c.Id == receiverId);
        
        senderAccount.Balance = (decimal.Parse(senderAccount.Balance) - amount).ToString();
        receiverAccount.Balance = (decimal.Parse(receiverAccount.Balance) + amount).ToString();
        

        
        await _bankAccountService.UpdateAsync(senderAccount);
        await _bankAccountService.UpdateAsync(receiverAccount);

        await _transactionService.AddAsync(transaction); // ✅ Ensure it's awaited.

        return RedirectToAction(nameof(List));
    }
    
}