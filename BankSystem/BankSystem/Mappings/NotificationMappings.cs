namespace BankSystem.Mappings;

public static class NotificationMappings
{
    public static Notification ToEntity(this NotificationServiceModel model)
    {
        return new Notification()
        { 
            Id = Guid.NewGuid(),
            UserId = model.UserId, 
            Message = model.Message
           
        };
    }

    public static NotificationServiceModel ToModel(this Notification entity)
    {
        return new NotificationServiceModel
        {
          //  Id = entity.Id.ToString(),
            UserId = entity.UserId.ToString(),
            Message = entity.Message
        };
    }
}