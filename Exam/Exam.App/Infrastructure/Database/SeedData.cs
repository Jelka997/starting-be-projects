using Exam.App.Domain;
using Microsoft.AspNetCore.Identity;

namespace Exam.App.Infrastructure.Database;

public static class SeedData
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        // Seed Administrators
        await SeedUser(userManager, "john", "john.doe@example.com", "John", "Doe", "John123!", "Administrator");
        await SeedUser(userManager, "jane", "jane.doe@example.com", "Jane", "Doe", "Jane123!", "Administrator");

        // Seed Users
        await SeedUser(userManager, "alice", "alice.smith@example.com", "Alice", "Smith", "Alice123!", "User");
        await SeedUser(userManager, "bob", "bob.jones@example.com", "Bob", "Jones", "Bobj123!", "User");
        await SeedUser(userManager, "charlie", "charlie.brown@example.com", "Charlie", "Brown", "Charlie123!", "User");
        await SeedUser(userManager, "diana", "diana.prince@example.com", "Diana", "Prince", "Diana123!", "User");
        await SeedUser(userManager, "edward", "edward.norton@example.com", "Edward", "Norton", "Edward123!", "User");
        await SeedUser(userManager, "fiona", "fiona.apple@example.com", "Fiona", "Apple", "Fiona123!", "User");
        await SeedUser(userManager, "george", "george.lucas@example.com", "George", "Lucas", "George123!", "User");
        await SeedUser(userManager, "hannah", "hannah.montana@example.com", "Hannah", "Montana", "Hannah123!", "User");
        await SeedUser(userManager, "ivan", "ivan.petrov@example.com", "Ivan", "Petrov", "Ivanp123!", "User");
        await SeedUser(userManager, "julia", "julia.roberts@example.com", "Julia", "Roberts", "Julia123!", "User");
        await SeedUser(userManager, "kevin", "kevin.hart@example.com", "Kevin", "Hart", "Kevin123!", "User");
        await SeedUser(userManager, "laura", "laura.palmer@example.com", "Laura", "Palmer", "Laura123!", "User");
        await SeedUser(userManager, "mike", "mike.tyson@example.com", "Mike", "Tyson", "Miket123!", "User");
        await SeedUser(userManager, "nina", "nina.simone@example.com", "Nina", "Simone", "Ninas123!", "User");
        await SeedUser(userManager, "oscar", "oscar.wilde@example.com", "Oscar", "Wilde", "Oscar123!", "User");
    }

    private static async Task SeedUser(UserManager<ApplicationUser> userManager, string username, string email, string name, string surname, string password, string role)
    {
        if (await userManager.FindByNameAsync(username) == null)
        {
            var user = new ApplicationUser
            {
                UserName = username,
                Email = email,
                Name = name,
                Surname = surname,
                EmailConfirmed = true
            };
            await userManager.CreateAsync(user, password);
            await userManager.AddToRoleAsync(user, role);
        }
    }
}
