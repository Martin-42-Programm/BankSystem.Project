using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace BankSystem.Controllers;

    


public class CardController : Controller

{
    private readonly ICardService _cardService;
    private readonly INotificationService _notificationService;

    public CardController(ICardService cardService, INotificationService notificationService)
    {
        this._cardService = cardService;
        this._notificationService = notificationService;
    }

    public  IActionResult CardDetails(string id)
    {
        var model =  _cardService.GetById(id.ToString());
        return View(model);
    }
    public IActionResult List()
    {
        var query = _cardService.GetAll().AsNoTracking();
        
        var model = query.ToList();
        
        return View(model);
        
    }

    public async Task<IActionResult> Switch(string id)
    {
        //var card = await _cardService.GetByIdAsync(id);
        var cards = _cardService.GetAllAsNoTracking();
        var list = cards.ToList();
        var card = list.FirstOrDefault(c => c.Id == id);
        
        
        card.IsActive = !card.IsActive;
        
        

       /* if (card == null)
        {
            return NotFound();
        }

       
        card.IsActive = !card.IsActive;*/

        
        //TODO: implement edit service methods
        await _cardService.UpdateAsync(card);

        return RedirectToAction(nameof(List));
    }
    //Method for adding new entity from type card
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
    public async Task<IActionResult> Delete(string id)
    {
        await _cardService.DeleteAsync(id);
        return RedirectToAction(nameof(List));
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

        var isSuccess =  await _cardService.AddAsync(card) == null ? false : true;
        await _notificationService.NotifyAsync("00000000-0000-0000-0000-000000000006", true, $"Adding new {type} card");

        return RedirectToAction(nameof(List));
    }
    
    
    
}