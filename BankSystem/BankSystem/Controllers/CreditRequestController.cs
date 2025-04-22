using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BankSystem.Models;
using System.Threading.Tasks;

//[Authorize]
public class CreditRequestController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly ProjectDbContext _context;

    public CreditRequestController(UserManager<User> userManager, ProjectDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Credit model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.GetUserAsync(User);
            model.UserId = user.Id;
            model.Status = "Pending";
            //model.RequestDate = DateTime.Now;

            _context.Credits.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> MyRequests()
    {
        var user = await _userManager.GetUserAsync(User);
        var requests = _context.Credits.Where(r => r.UserId == user.Id).ToList();
        return View(requests);
    }
}
