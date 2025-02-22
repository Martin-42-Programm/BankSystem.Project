using Microsoft.EntityFrameworkCore;

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
    using (var context = serviceScope.ServiceProvider.GetRequiredService<ProjectDbContext>())
    {
        context.Database.Migrate();
    }
}

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