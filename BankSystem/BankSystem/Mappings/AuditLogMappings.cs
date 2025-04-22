using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BankSystem.Mappings;

public static class AuditLogMappings
{
    public static AuditLog ToEntity(this AuditLogServiceModel model)
    {
        
        return new AuditLog()
        {
           
            UserId = model.UserId,
            Action = model.Action,
            EntityType = model.EntityType,
            EntityId = model.EntityId,
            Details = model.Details,
            Timestamp = DateTime.UtcNow,
            IpAddress = model.IpAddress,
            UserAgent = model.UserAgent
    
    
        };
    }

    public static AuditLogServiceModel ToModel(this AuditLog auditLog)
    {
        return new AuditLogServiceModel()
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
}