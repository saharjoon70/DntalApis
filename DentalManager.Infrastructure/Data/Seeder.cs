using DentalManager.Domain.Entities;
using DentalManager.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class DbSeeder
{
    // لیست نقش‌ها (Id، Name، NormalizedName)
    private static readonly (string Id, string Name)[] Roles =
    {
        ("015522", "SuperAdmin"),
        ("197852", "WebSupport"),
        ("223845", "ServiceManager"),
        ("341743f1-asd2-42de-afbg-59kmkkmk72cf6", "Admin"),
        ("569771", "FinancialOfficer"),
        ("665989", "Doctor"),
        ("772974", "Asistant"),
        ("989815", "Secretary"),
    };

    public static async Task SeedAsync(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var ctx = scope.ServiceProvider.GetRequiredService<DentalContext>();

        // ---------- 1) درج نقش‌ها ----------
        // از AppRoles استفاده می‌کنیم چون در Context تعریف شده و همان جدول AspNetRoles است
        var existingNames = await ctx.AppRoles
            .Select(r => r.NormalizedName)
            .ToListAsync();

        foreach (var (id, name) in Roles)
        {
            var normalized = name.ToUpperInvariant();
            if (existingNames.Contains(normalized))
                continue;

            ctx.AppRoles.Add(new ApplicationRole
            {
                Id = id,
                Name = name,
                NormalizedName = normalized,
                ConcurrencyStamp = Guid.NewGuid().ToString()
            });
        }

        await ctx.SaveChangesAsync();

        // ---------- 2) درج کاربر Admin ----------
        var adminUser = await EnsureUserAsync(ctx,
            userName: "admin",
            email: "admin@dental.local",
            password: "Admin@12345",
            firstName: "مدیر",
            lastName: "مطب",
            roleName: "Admin");

        // ---------- 3) درج کاربر Secretary ----------
        var secUser = await EnsureUserAsync(ctx,
            userName: "secretary",
            email: "secretary@dental.local",
            password: "Secretary@12345",
            firstName: "منشی",
            lastName: "مطب",
            roleName: "Secretary");
    }

    private static async Task<ApplicationUser> EnsureUserAsync(
        DentalContext ctx,
        string userName, string email, string password,
        string firstName, string lastName, string roleName)
    {
        var normalizedEmail = email.ToUpperInvariant();
        var normalizedUserName = userName.ToUpperInvariant();

        // آیا کاربر هست؟
        var user = await ctx.AppUsers
            .FirstOrDefaultAsync(u => u.NormalizedUserName == normalizedUserName);

        if (user == null)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            user = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = userName,
                NormalizedUserName = normalizedUserName,
                Email = email,
                NormalizedEmail = normalizedEmail,
                EmailConfirmed = true,
                FirstName = firstName,
                LastName = lastName,
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            };
            user.PasswordHash = hasher.HashPassword(user, password);

            ctx.AppUsers.Add(user);
            await ctx.SaveChangesAsync();
        }

        // نقش را پیدا کن (از AppRoles)
        var normalizedRole = roleName.ToUpperInvariant();
        var role = await ctx.AppRoles
            .FirstOrDefaultAsync(r => r.NormalizedName == normalizedRole);

        if (role == null)
            throw new InvalidOperationException(
                $"Role '{roleName}' (NormalizedName='{normalizedRole}') not found. " +
                "ابتدا مطمئن شو نقش‌ها درج شده‌اند.");

        // آیا در حال حاضر این نقش را دارد؟
        var alreadyInRole = await ctx.Set<IdentityUserRole<string>>()
            .AnyAsync(ur => ur.UserId == user.Id && ur.RoleId == role.Id);

        if (!alreadyInRole)
        {
            ctx.Set<IdentityUserRole<string>>().Add(new IdentityUserRole<string>
            {
                UserId = user.Id,
                RoleId = role.Id
            });
            await ctx.SaveChangesAsync();
        }

        return user;
    }
}