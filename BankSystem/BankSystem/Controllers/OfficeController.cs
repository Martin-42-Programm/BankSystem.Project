using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace BankSystem.Controllers;

public class OfficeController : Controller
{
    private readonly IOfficeService _officeService;
    private readonly INotificationService _notificationService;
    private readonly IHubContext<NotificationHub> _hubContext;

    public OfficeController(IOfficeService officeService, INotificationService notificationService, IHubContext<NotificationHub> hubContext)
    {
        this._officeService = officeService;
        this._notificationService = notificationService;
        this._hubContext = hubContext;
    }
    
    public IActionResult OfficeDetails(string id)
    {
        var model = _officeService.GetById(id);
        
        return View(model);
    }


    public IActionResult List()
    {
        var query = _officeService.GetAll().AsNoTracking();
        
        var model = query.ToList();
        
        return View(model);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            // Get office details before deleting
            var office = _officeService.GetById(id);
            
            if (office != null)
            {
                string officeName = $"{office.Address}, {office.City}";
                
                // Delete the office
                await _officeService.DeleteAsync(id);
                
                // Create notification message
                string notificationMessage = $"Office at {officeName} was successfully deleted.";
                
                // Store in TempData for toast display after redirect
                TempData["NotificationMessage"] = notificationMessage;
                
                // Also send via SignalR
                await _notificationService.NotifyAsync("00000000-0000-0000-0000-000000000006", true, $"Deleted office");
            }
            else
            {
                TempData["NotificationMessage"] = "Office not found or could not be deleted.";
            }
        }
        catch (Exception ex)
        {
            TempData["NotificationMessage"] = $"Error deleting office: {ex.Message}";
        }
        
        return RedirectToAction(nameof(List));
    }


    [HttpPost]
    public async Task<IActionResult> Create(string address, string postCode, string city, string country)
    {
        if (string.IsNullOrWhiteSpace(address) 
            || string.IsNullOrWhiteSpace(postCode)
            || string.IsNullOrWhiteSpace(city)
            || string.IsNullOrWhiteSpace(country))
        {
            return View();
        }

        var office = new OfficeServiceModel()
        {
            Address = address,
            City = city,
            Country = country,
            Postcode = postCode
        };
        
        bool isSuccess = false;
        
        try
        {
            var result = await _officeService.AddAsync(office);
            isSuccess = result != null;
            
            // Create notification message
            string notificationMessage = isSuccess 
                ? $"New office at {address}, {city} was successfully created!" 
                : "Failed to create new office.";
            
            // Store in TempData for toast display after redirect
            TempData["NotificationMessage"] = notificationMessage;
            
            // Also send via SignalR
            await _notificationService.NotifyAsync(
                "00000000-0000-0000-0000-000000000006", 
                isSuccess, 
                "Adding new office");
        }
        catch (Exception ex)
        {
            TempData["NotificationMessage"] = $"Error creating office: {ex.Message}";
        }

        return RedirectToAction(nameof(List));
    }
    
}