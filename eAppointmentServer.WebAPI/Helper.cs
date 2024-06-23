using eAppointmentServer.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace eAppointmentServer.WebAPI;

public static class Helper
{
    public static async Task CreateUserAsync(WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            if (!userManager.Users.Any())
            {
                await userManager.CreateAsync(new()
                {
                    FirstName = "Hüseyin",
                    LastName = "Aydın",
                    Email = "huseyinaydin99@gmail.com",
                    UserName = "huseyin.aydin"
                }, "1");
            }
        }
    }
}