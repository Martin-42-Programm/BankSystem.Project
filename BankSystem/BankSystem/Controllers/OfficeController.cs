using Microsoft.AspNetCore.Mvc;

namespace BankSystem.Controllers;

public class OfficeController : Controller
{
    private readonly IOfficeService officeService;

    public OfficeController(IOfficeService officeService)
    {
        this.officeService = officeService;
    }
    
    public IActionResult OfficeDetails(string id)
    {
        var model = officeService.GetById(id);
        
        return View(model);
    }


    public IActionResult List()
    {
            var query = officeService.GetAll().AsNoTracking();
        
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
        await officeService.DeleteAsync(id);
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
            //ModelState.AddModelError("", "Type and Currency are required.");
            return View();
        }

        var office = new OfficeServiceModel()
        {
            Address = address,
            City = city,
            Country = country,
            Postcode = postCode
        };
        

        await officeService.AddAsync(office); // ✅ Ensure it's awaited.

        return RedirectToAction(nameof(Create));
    }
    
}