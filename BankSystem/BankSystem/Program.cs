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



// Add Identity services
builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ProjectDbContext>();

builder.Services.AddHttpContextAccessor();

//Add repositories
builder.Services.AddScoped<BankAccountRepository>();
builder.Services.AddScoped<CardRepository>();
builder.Services.AddScoped<TransactionRepository>();
builder.Services.AddScoped<CreditRepository>();
builder.Services.AddScoped<OfficeRepository>();
builder.Services.AddScoped<CurrencyRepository>();
builder.Services.AddScoped<NotificationRepository>();


//Add services
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IBankAccountService, BankAccountService>();
builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<ICreditService, CreditService>();
builder.Services.AddScoped<IOfficeService, OfficeService>();
builder.Services.AddScoped<ICurrencyService, CurrencyService>();
builder.Services.AddScoped<INotificationService, NotificationService>();

builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        b =>
        {
            b.WithOrigins("https://localhost:5204")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
});

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
    app.MapControllers();
    app.MapRazorPages();  
    app.UseCors("AllowAll");
    app.MapHub<NotificationHub>("/notificationHub");
    app.UseAuthentication(); // Add this line
    app.UseAuthorization();

    app.MapStaticAssets();

    app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}")
        .WithStaticAssets();

    app.Run();
}

