namespace BankSystem.Data.Entities;

public class Transfer : Transaction
{
    public string Type = "Transfer";
    
    public DateTime ScheduleDate { get; set; }
}