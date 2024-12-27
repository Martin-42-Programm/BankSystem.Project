namespace BankSystem.Data.Entities;

public class WorkingTime:BaseEntity
{
    public Dictionary<string, DayHours> WeeklySchedule { get; private set; }

    public WorkingTime()
    {
        WeeklySchedule = new Dictionary<string, DayHours>
        {
            { "Monday", new DayHours(null, null) },
            { "Tuesday", new DayHours(null, null) },
            { "Wednesday", new DayHours(null, null) },
            { "Thursday", new DayHours(null, null) },
            { "Friday", new DayHours(null, null) },
            { "Saturday", new DayHours(null, null) },
            { "Sunday", new DayHours(null, null) }
        };
    }


    public void SetDayHours(string day, TimeSpan? opening, TimeSpan? closing)
    {
        if (WeeklySchedule.ContainsKey(day))
        {
            WeeklySchedule[day] = new DayHours(opening, closing);
        }
        else
        {
            throw new ArgumentException("Invalid day of the week.");
        }
    }
}