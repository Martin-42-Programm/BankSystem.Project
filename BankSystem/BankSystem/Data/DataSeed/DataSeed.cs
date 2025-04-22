namespace BankSystem.Data.DataSeed;

public class DataSeed
{
    public static void SeedUserRoles(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider.GetService<ProjectDbContext>();
        
        var roles = Enum.GetValues(typeof(Roles));
        foreach (var role in roles)
        {
            var roleName = role.ToString();
            var roleExists = services.Roles.Any(x => x.Name == roleName);
            if (!roleExists)
            {
                var identityRole = new IdentityRole(roleName)
                {
                    NormalizedName = roleName.ToUpper()
                };
                services.Roles.Add(identityRole);
            }
        }

        services.SaveChanges();
    }
}