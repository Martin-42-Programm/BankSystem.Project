using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BankSystem.Models;
using System.Linq;
using System.Threading.Tasks;

[Authorize(Roles = "Admin")]
public class CreditManagementController : Controller
{
    private readonly ProjectDbContext _context;

    public CreditManagementController(ProjectDbContext context)
    {
        _context = context;
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
        }
        return RedirectToAction("Index");
    }
}
