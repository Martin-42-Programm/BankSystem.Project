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

    public IActionResult List(string status)
    {
        var query = _transactionService.GetAll().AsNoTracking();
        
        // Apply status filter if provided
        if (!string.IsNullOrEmpty(status))
        {
            query = query.Where(t => t.Status == status);
            ViewData["CurrentStatus"] = status;
        }
        
        var model = query.ToList();
        
        return View(model);
    }
   
    public async Task<IActionResult> Details(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return NotFound();
        }

        var transaction = await _transactionService.GetByIdAsync(id);
        
        if (transaction == null)
        {
            return NotFound();
        }

        return View(transaction);
    }
    
    [HttpPost]
    public async Task<IActionResult> Approve(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return NotFound();
        }

        var transaction = await _transactionService.GetByIdAsync(id);
        
        if (transaction == null)
        {
            return NotFound();
        }

        transaction.Status = "Approved";
        await _transactionService.UpdateAsync(transaction);
        
        // Add success message
        TempData["SuccessMessage"] = "Transaction has been approved.";
        
        return RedirectToAction(nameof(Details), new { id });
    }
    
    [HttpPost]
    public async Task<IActionResult> Decline(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return NotFound();
        }

        var transaction = await _transactionService.GetByIdAsync(id);
        
        if (transaction == null)
        {
            return NotFound();
        }

        transaction.Status = "Declined";
        await _transactionService.UpdateAsync(transaction);
        
        // Refund the amount back to sender if it was deducted
        if (transaction.Status != "Flagged")
        {
            var accounts = _bankAccountService.GetAllAsNoTracking();
            var list = accounts.ToList();
            var senderAccount = list.FirstOrDefault(c => c.Id == transaction.SenderId);
            var receiverAccount = list.FirstOrDefault(c => c.Id == transaction.ReceiverId);
            
            if (senderAccount != null && receiverAccount != null)
            {
                // Reverse the transaction
                senderAccount.Balance = (decimal.Parse(senderAccount.Balance) + transaction.Amount).ToString();
                receiverAccount.Balance = (decimal.Parse(receiverAccount.Balance) - transaction.Amount).ToString();
                
                await _bankAccountService.UpdateAsync(senderAccount);
                await _bankAccountService.UpdateAsync(receiverAccount);
            }
        }
        
        // Add success message
        TempData["SuccessMessage"] = "Transaction has been declined.";
        
        return RedirectToAction(nameof(Details), new { id });
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
        
        // Check for suspicious activity or exceeding limits
        bool isFlagged = false;
        string flagReason = "";
        
        // Example flag conditions (customize based on your business rules)
        if (amount > 10000)
        {
            isFlagged = true;
            flagReason = "Amount exceeds daily limit";
        }
        
        var accounts = _bankAccountService.GetAllAsNoTracking();
        var list = accounts.ToList();
        var senderAccount = list.FirstOrDefault(c => c.Id == senderId);
        var receiverAccount = list.FirstOrDefault(c => c.Id == receiverId);
        
        if (isFlagged)
        {
            transaction.Status = "Flagged";
            transaction.FlagReason = flagReason;
            await _transactionService.AddAsync(transaction);
            
            TempData["WarningMessage"] = "Transaction has been flagged for review.";
            return RedirectToAction(nameof(Details), new { id = transaction.TransactionId });
        }
        else
        {
            senderAccount.Balance = (decimal.Parse(senderAccount.Balance) - amount).ToString();
            receiverAccount.Balance = (decimal.Parse(receiverAccount.Balance) + amount).ToString();
            
            await _bankAccountService.UpdateAsync(senderAccount);
            await _bankAccountService.UpdateAsync(receiverAccount);

            await _transactionService.AddAsync(transaction);
            
            return RedirectToAction(nameof(List));
        }
    }
}