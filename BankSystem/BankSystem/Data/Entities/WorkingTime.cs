namespace BankSystem.Data.Entities;

public class WorkingTime:BaseEntity
{
    public Dictionary<string, DayHours> WeeklySchedule { get; private set; }

    public WorkingTime()
    {
        // Initialize the dictionary with the days of the week
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

    // Method to set working hours for a specific day
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