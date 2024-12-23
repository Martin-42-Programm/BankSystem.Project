namespace BankSystem.Data.Entities;

public class DayHours
{
    public TimeSpan? OpeningTime { get; set; } // Nullable for closed days
    public TimeSpan? ClosingTime { get; set; } // Nullable for closed days

    public DayHours(TimeSpan? opening, TimeSpan? closing)
    {
        OpeningTime = opening;
        ClosingTime = closing;
    }

}