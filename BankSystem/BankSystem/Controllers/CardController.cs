using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;


namespace BankSystem.Controllers;

    


public class CardController : Controller

{
    private readonly ICardService _cardService;
    private readonly INotificationService _notificationService;
    private readonly IOfficeService _officeService;
    private readonly IHubContext<NotificationHub> _hubContext;
   

    public CardController(ICardService cardService, INotificationService notificationService, IHubContext<NotificationHub> hubContext, IOfficeService officeService)
    {
        this._cardService = cardService;
        this._notificationService = notificationService;
        this._hubContext = hubContext;
        this._officeService = officeService;

    }

    public  IActionResult CardDetails(string id)
    {
        var model =  _cardService.GetById(id);
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
        var card = list.FirstOrDefault(c => c.Number == id);
        
        
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
        var offices = _officeService.GetAll().AsEnumerable()
            .Select(c => new SelectListItem
            {
                Value = c.Id,    // Currency code (e.g., "USD")
                Text = $"{c.Address}, {c.City}"      // Currency name (e.g., "US Dollar")
            }).ToList();
      
        ViewBag.Offices = offices; // Pass to the view
      
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
        // Get the card to determine its type
        var card = await _cardService.GetByIdAsync(id);
        
        if (card != null)
        {
            bool isDebitCard = card.Type.ToLower() == "debit";
            string cardType = card.Type;
            
            // Delete the card
            await _cardService.DeleteAsync(id);
            
            // Set notification message
            string notificationMessage = isDebitCard ? 
                $"Debit card ({card.Pseudonym}) was successfully deleted." : 
                $"{cardType} card ({card.Pseudonym}) was deleted.";
            
            // Store in TempData for toast display after redirect
            TempData["NotificationMessage"] = notificationMessage;
            
            // Also send via SignalR for real-time notification
            await _notificationService.NotifyAsync("00000000-0000-0000-0000-000000000006", true, 
                isDebitCard ? $"Deleted debit card" : $"Deleted {cardType} card");
        }
        else
        {
            TempData["NotificationMessage"] = "Card not found or could not be deleted.";
        }
        
        return RedirectToAction(nameof(List));
    }

    [HttpPost]
    public async Task<IActionResult> Create(string type, string pickupOffice, string pseudonym)
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
           // Id = Guid.NewGuid().ToString(),
            Number =  (random.Next(10000000, 99999999))+ random.Next(10000000, 99999999).ToString(),
            ExpirationDate = DateTime.Now.AddYears(5),
            PickupOffice  = pickupOffice,
            Pseudonym = pseudonym
        };
        
        var isSuccess = await _cardService.AddAsync(card) != null;
        
        // Create notification message
        var notificationMessage = isSuccess ? $"Adding new {type} card successful!" : $"Adding new {type} card failed!";
        
        // Store in TempData to display toast after redirect
        TempData["NotificationMessage"] = notificationMessage;
        
        // Also send via SignalR
        await _notificationService.NotifyAsync("00000000-0000-0000-0000-000000000006", isSuccess, $"Adding new {type} card");

        return RedirectToAction(nameof(List));
    }
    
    
    
}