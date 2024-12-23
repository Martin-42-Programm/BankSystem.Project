using BankSystem.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace BankSystem.Data;

public class ProjectDbContext : IdentityDbContext
{
    
    public DbSet<Currency> Currencies { get; set; }
    public DbSet<Account> Accounts { get; set; }
    

    
    public DbSet<Card> Cards { get; set; }
    
    public DbSet<User> Users { get; set; }
    
    public DbSet<Transaction> Transactions { get; set; }
    
    public DbSet<Transfer> Transfers { get; set; }
    
   
    
    public DbSet<WorkingTime> WorkingTimes { get; set; }
    
    public DbSet<Office> Offices { get; set; }
    
  //  public DbSet<Credit> Credits { get; set; }
    
    
    
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