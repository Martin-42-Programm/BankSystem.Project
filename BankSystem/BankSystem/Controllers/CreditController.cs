using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.Controllers;
[Authorize(Roles = "Admin, User")]
public class CreditController : Controller
{
     private readonly ProjectDbContext _context;
    private readonly IAuditLogService _auditLogService;

    public CreditController(ProjectDbContext context, IAuditLogService auditLogService)
    {
        _context = context;
        _auditLogService = auditLogService;
    }

    //[HttpGet]
    public IActionResult Index()
    {
        var requests = _context.Credits.Where(r => r.Status == "Pending").ToList();
        var model = requests.AsEnumerable();
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Approve(int id)
    {
        var request = await _context.Credits.FindAsync(id);
        if (request != null)
        {
            request.Status = "Approved";
            var credit = new Credit
            {
                UserId = request.UserId,
                RequestedAmount = request.RequestedAmount,
                Status = "Active",
               // ApprovalDate = DateTime.Now
            };
            _context.Credits.Add(credit);
            await _context.SaveChangesAsync();
            
            // Log the admin action
            var details = JsonSerializer.Serialize(new 
            { 
                RequestId = id,
                RequestAmount = request.RequestedAmount,
                RequestUserId = request.UserId,
                CreditId = credit.Id
            });
            
            await _auditLogService.LogActionAsync(
                "Credit Request Approved", 
                "CreditRequest", 
                id.ToString(), 
                details);
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Reject(int id)
    {
        var request = await _context.Credits.FindAsync(id);
        if (request != null)
        {
            request.Status = "Rejected";
            await _context.SaveChangesAsync();
            
            // Log the admin action
            var details = JsonSerializer.Serialize(new 
            { 
                RequestId = id,
                RequestAmount = request.RequestedAmount,
                RequestUserId = request.UserId
            });
            
            await _auditLogService.LogActionAsync(
                "Credit Request Rejected", 
                "CreditRequest", 
                id.ToString(), 
                details);
        }
        return RedirectToAction("Index");
    }
}