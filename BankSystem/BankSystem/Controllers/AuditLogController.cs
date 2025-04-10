using BankSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Controllers;

[Authorize(Roles = "Admin")]
public class AuditLogController : Controller
{
    private readonly IAuditLogService _auditLogService;

    public AuditLogController(IAuditLogService auditLogService)
    {
        _auditLogService = auditLogService;
    }

    public IActionResult Index(
        string userId = null, 
        string action = null, 
        string entityType = null, 
        DateTime? startDate = null, 
        DateTime? endDate = null)
    {
        var logsQuery = _auditLogService.SearchLogs(userId, action, entityType, startDate, endDate);
        
        ViewBag.UserId = userId;
        ViewBag.Action = action;
        ViewBag.EntityType = entityType;
        ViewBag.StartDate = startDate;
        ViewBag.EndDate = endDate;
        
        var logs = logsQuery.ToList();
        
        return View(logs);
    }
    
    public IActionResult Details(Guid id)
    {
        var log = _auditLogService.SearchLogs().FirstOrDefault(l => l.Id == id);
        
        if (log == null)
        {
            return NotFound();
        }
        
        return View(log);
    }
} 