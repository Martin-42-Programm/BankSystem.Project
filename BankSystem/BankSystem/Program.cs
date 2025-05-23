using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BankSystem.Data;
using BankSystem.Data.DataSeed;
using BankSystem.Models;
using Rotativa.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connectionString = builder
                              .Configuration
                              .GetConnectionString("ApplicationContextConnectionString") ??
                          throw new InvalidDataException("No valid connection string!");

builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
builder.Services.AddControllersWithViews();



builder.Services.AddRazorPages();

builder.Services.AddDbContext<ProjectDbContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 2))));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ProjectDbContext>()
    .AddDefaultTokenProviders();

// Add Identity services
// builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
//     .AddEntityFrameworkStores<ProjectDbContext>()
//     .AddDefaultTokenProviders();

// builder.Services.AddIdentity<User, IdentityRole>(
//     
//         options => options.SignIn.RequireConfirmedAccount = false
//     )
//     .AddEntityFrameworkStores<ProjectDbContext>()
//     .AddDefaultTokenProviders();



builder.Services.AddHttpContextAccessor();

//Add repositories
builder.Services.AddScoped<BankAccountRepository>();
builder.Services.AddScoped<CardRepository>();
builder.Services.AddScoped<TransactionRepository>();
builder.Services.AddScoped<CreditRepository>();
builder.Services.AddScoped<OfficeRepository>();
builder.Services.AddScoped<CurrencyRepository>();
builder.Services.AddScoped<NotificationRepository>();
builder.Services.AddScoped<AuditLogRepository>();


//Add services
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IBankAccountService, BankAccountService>();
builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<ICreditService, CreditService>();
builder.Services.AddScoped<IOfficeService, OfficeService>();
builder.Services.AddScoped<ICurrencyService, CurrencyService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IAuditLogService, AuditLogService>();
builder.Services.AddScoped<IUserService, UserService>();




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



// Optionally, configure additional Rotativa options here if needed
// For example, set a different path or other options.
//app.UseRotativa(); // Enables middleware to handle PDF generation routes.
//RotativaConfiguration.Setup(app.Environment.WebRootPath, "/wwwroot/Rotativa/wkhtmltopdf.exe");

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
    DataSeed.SeedUserRoles(app);
    app.MapStaticAssets();

    app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}")
        .WithStaticAssets();

    app.Run();
}


