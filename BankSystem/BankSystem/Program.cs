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
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ProjectDbContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 2))));

<<<<<<< HEAD
=======

// Add Identity services
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ProjectDbContext>();


>>>>>>> 1cfc6134cdb97d7f7050177ef953733fe25064b6
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<AccountRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

using (var serviceScope = app.Services.CreateScope())
{


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
}
<<<<<<< HEAD

app.UseHttpsRedirection();
app.UseStaticFiles(); // To serve static files

app.UseRouting();

app.UseAuthentication(); // Only if you're using authentication
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
=======
>>>>>>> 1cfc6134cdb97d7f7050177ef953733fe25064b6
