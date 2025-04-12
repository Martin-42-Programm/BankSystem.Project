using BankSystem.Data.Entities;
using BankSystem.ServiceModels;

namespace BankSystem.Services;

public interface IAuditLogService
{
    Task<AuditLogServiceModel> LogActionAsync(string action, string entityType, string entityId, string details = null);
    
    IQueryable<AuditLogServiceModel> SearchLogs(
        string userId = null, 
        string action = null, 
        string entityType = null, 
        DateTime? startDate = null, 
        DateTime? endDate = null);
} 