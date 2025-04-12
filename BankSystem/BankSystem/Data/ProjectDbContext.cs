using BankSystem.Data.Entities;
using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace BankSystem.Data;

public class ProjectDbContext : IdentityDbContext<User>
{
    
    public DbSet<Currency> Currencies { get; set; }
    public DbSet<BankAccount> BankAccounts { get; set; }
    
    public DbSet<Card> Cards { get; set; }
    
    //public DbSet<User> Users { get; set; }
    
    public DbSet<Transaction> Transactions { get; set; }
    
    public DbSet<Transfer> Transfers { get; set; }
    
   
    
    public DbSet<WorkingTime> WorkingTimes { get; set; }
    
    public DbSet<Office> Offices { get; set; }
    
    public DbSet<CreditRequest> CreditRequests { get; set; }
    public DbSet<CreditManagement> CreditManagements { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<AuditLog> AuditLogs { get; set; }
     
    public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
        : base(options)
    {
            
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
                     .SelectMany(e => e.GetForeignKeys()))
        {
            foreignKey.DeleteBehavior = DeleteBehavior.Cascade;
               
        }
    
        modelBuilder.Entity<WorkingTime>()
            .Ignore(e => e.WeeklySchedule);
    
    }
}