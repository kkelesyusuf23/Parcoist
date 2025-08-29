using Parcoist.DataAccess.Concrete;
using Parcoist.UI.Entities;

public static class SeedData
{
    public static void Initialize(ParcoContext context)
    {
        if (!context.Roles.Any())
        {
            context.Roles.AddRange(
                new Role { RoleName = "SuperAdmin", Description = "Tüm yetkiler", IsActive = true, CreatedAt = DateTime.Now },
                new Role { RoleName = "Admin", Description = "Sınırlı yetkiler", IsActive = true, CreatedAt = DateTime.Now }
            );
            context.SaveChanges();
        }

        if (!context.Users.Any())
        {
            string password = "SuperAdmin123!"; // Default şifre
            PasswordHelper.CreatePasswordHash(password, out string hash, out string salt);

            var superAdmin = new User
            {
                Name = "Default",
                Surname = "SuperAdmin",
                Email = "superadmin@parcoist.com",
                PasswordHash = hash,
                PasswordSalt = salt,
                RoleID = context.Roles.First(r => r.RoleName == "SuperAdmin").RoleID,
                IsActive = true,
                IsEmailConfirmed = true,
                EmailConfirmationToken = Guid.NewGuid().ToString(),
                //RefreshToken = hash,
                //RefreshTokenExpiry = null,
                CreatedAt = DateTime.Now
            };

            context.Users.Add(superAdmin);
            context.SaveChanges();

            context.Admins.Add(new Admin
            {
                UserID = superAdmin.UserID,
                IsActive = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });
            context.SaveChanges();
        }
    }
}
