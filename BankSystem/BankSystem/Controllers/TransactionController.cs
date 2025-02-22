using Microsoft.AspNetCore.Mvc;

namespace BankSystem.Controllers;

public class TransactionController : Controller
{
    private readonly ITransactionService _transactionService;

    public TransactionController(ITransactionService transactionService)
    {
        this._transactionService = transactionService;
    }
    
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(string receiverId, decimal amount, string type)
    {
        if (string.IsNullOrWhiteSpace(receiverId) 
            || string.IsNullOrWhiteSpace(type))
            
        {
            //ModelState.AddModelError("", "Type and Currency are required.");
            return View();
        }

        var transaction = new TransactionServiceModel()
        {
            Amount = amount,
            ReceiverId = receiverId,
            Type = type,
            TransactionId = Guid.NewGuid().ToString()
            
        };
        

        await _transactionService.AddAsync(transaction); // ✅ Ensure it's awaited.

        return RedirectToAction(nameof(Create));
    }
    
}