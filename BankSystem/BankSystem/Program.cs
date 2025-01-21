using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BankSystem.Data;
using BankSystem.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connectionString = builder
                              .Configuration
                              .GetConnectionString("ApplicationContextConnectionString") ??
                          throw new InvalidDataException("No valid connection string!");

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ProjectDbContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 2))));

// Add Identity services
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ProjectDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

using (var serviceScope = app.Services.CreateScope())
{
    using (var context = serviceScope.ServiceProvider.GetRequiredService<ProjectDbContext>())
    {
        context.Database.Migrate();
    }
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication(); // Add this line
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
