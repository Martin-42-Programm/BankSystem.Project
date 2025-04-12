using BankSystem.Data.Entities;
using BankSystem.Repositories;
using BankSystem.ServiceModels;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Services;

public class AuditLogService : IAuditLogService
{
    private readonly AuditLogRepository _auditLogRepository;
    
    public AuditLogService(AuditLogRepository auditLogRepository)
    {
        _auditLogRepository = auditLogRepository;
    }
    
    public async Task<AuditLogServiceModel> LogActionAsync(string action, string entityType, string entityId, string details = null)
    {
        var auditLog = await _auditLogRepository.LogAction(action, entityType, entityId, details);
        
        return new AuditLogServiceModel
        {
            Id = auditLog.Id,
            UserId = auditLog.UserId,
            User = auditLog.User,
            Action = auditLog.Action,
            EntityType = auditLog.EntityType,
            EntityId = auditLog.EntityId,
            Timestamp = auditLog.Timestamp,
            Details = auditLog.Details,
            IpAddress = auditLog.IpAddress,
            UserAgent = auditLog.UserAgent
        };
    }
    
    public IQueryable<AuditLogServiceModel> SearchLogs(
        string userId = null, 
        string action = null, 
        string entityType = null, 
        DateTime? startDate = null, 
        DateTime? endDate = null)
    {
        return _auditLogRepository.SearchLogs(userId, action, entityType, startDate, endDate)
            .Select(log => new AuditLogServiceModel
            {
                Id = log.Id,
                UserId = log.UserId,
                User = log.User,
                Action = log.Action,
                EntityType = log.EntityType,
                EntityId = log.EntityId,
                Timestamp = log.Timestamp,
                Details = log.Details,
                IpAddress = log.IpAddress,
                UserAgent = log.UserAgent
            });
    }
} 