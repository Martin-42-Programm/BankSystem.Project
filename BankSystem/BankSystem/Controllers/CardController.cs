using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace BankSystem.Controllers;

    


public class CardController : Controller

{
    private readonly ICardService _cardService;

    public CardController(ICardService cardService)
    {
        this._cardService = cardService;
    }
    public IActionResult List()
    {
        var query = _cardService.GetAll().AsNoTracking();
        
        var model = query.ToList();
        
        return View(model);
        
    }

    public IActionResult Switch(string id)
    {
        var card = _cardService.GetById(id);

        if (card == null)
        {
            return NotFound();
        }

        // Toggle the IsActive property
        card.IsActive = !card.IsActive;

        // Save the changes to the database
        //TODO: implement edit service methods
        _cardService.UpdateAsync(card);

        return RedirectToAction(nameof(List));
    }
    public IActionResult Create()
    {
        var types = new List<string>{ "debit", "credit" };
        var  viewBagTypes = types.Select(c => new SelectListItem
            {
                Value = c,    // Currency code (e.g., "USD")
                Text = c      // Currency name (e.g., "US Dollar")
            }).ToList();
        //TODO: Multiple choice for type of bankaccount
        ViewBag.Types = viewBagTypes; // Pass to the view
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(string type)
    {
        if (string.IsNullOrWhiteSpace(type) )
        {
            ModelState.AddModelError("", "Type is required.");
            return View();
        }
        Random random = new Random();
        
        var card = new CardServiceModel
        {
            Type = type,
            IsActive = true,
            Id = Guid.NewGuid().ToString(),
            Number = random.NextDouble()*9_000_000_000_000L + 1_000_000_000_000L.ToString(),
            ExpirationDate = DateTime.Now.AddYears(5)
            
        };

        await _cardService.AddAsync(card); // ✅ Ensure it's awaited.

        return RedirectToAction(nameof(Create));
    }
    
    
    
}