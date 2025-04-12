using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BankSystem.Models;
using BankSystem.Services;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace BankSystem.Controllers;

[Authorize(Roles = "Admin")]
public class CreditManagementController : Controller
{
    private readonly ProjectDbContext _context;
    private readonly IAuditLogService _auditLogService;

    public CreditManagementController(ProjectDbContext context, IAuditLogService auditLogService)
    {
        _context = context;
        _auditLogService = auditLogService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var requests = _context.CreditRequests.Where(r => r.Status == "Pending").ToList();
        return View(requests);
    }

    [HttpPost]
    public async Task<IActionResult> Approve(int id)
    {
        var request = await _context.CreditRequests.FindAsync(id);
        if (request != null)
        {
            request.Status = "Approved";
            var credit = new CreditManagement
            {
                UserId = request.UserId,
                Amount = request.Amount,
                Status = "Active",
                ApprovalDate = DateTime.Now
            };
            _context.CreditManagements.Add(credit);
            await _context.SaveChangesAsync();
            
            // Log the admin action
            var details = JsonSerializer.Serialize(new 
            { 
                RequestId = id,
                RequestAmount = request.Amount,
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
        var request = await _context.CreditRequests.FindAsync(id);
        if (request != null)
        {
            request.Status = "Rejected";
            await _context.SaveChangesAsync();
            
            // Log the admin action
            var details = JsonSerializer.Serialize(new 
            { 
                RequestId = id,
                RequestAmount = request.Amount,
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
