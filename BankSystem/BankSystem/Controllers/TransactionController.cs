using Microsoft.AspNetCore.Mvc;

namespace BankSystem.Controllers;

public class TransactionController : Controller
{
    private readonly ITransactionService _transactionService;

    public TransactionController(ITransactionService transactionService)
    {
        this._transactionService = transactionService;
    }
    
}