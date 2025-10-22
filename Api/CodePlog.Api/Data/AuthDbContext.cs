using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CodePlog.Api.Data;

public class AuthDbContext : IdentityDbContext
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        var readerRoleId = "b7fb7629-a554-4167-94f9-0bf97f8d5186";
        var writerRoleId = "e69fbe69-a0b0-47d6-b213-470998fc19c1";

        var roles = new List<IdentityRole>()
        {
            new IdentityRole()
            {
                Id = readerRoleId,
                Name = "Reader",
                NormalizedName = "READER"
            },
            new IdentityRole()
            {
                Id = writerRoleId,
                Name = "Writer",
                NormalizedName = "WRITER"
            }
        };

        builder.Entity<IdentityRole>().HasData(roles);  

        var adminUserId = "b05afbe2-71a2-4915-94e4-ab8552877133";
        var adminUser = new IdentityUser()
        {
            Id = adminUserId,
            UserName = "admin",
            NormalizedUserName = "ADMIN",
            Email = "admin@dud.com",
            NormalizedEmail = "ADMIN@DUD.COM",
        };

        var passwordHasher = new PasswordHasher<IdentityUser>();
        adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "Menna@123");

        builder.Entity<IdentityUser>().HasData(adminUser);

        var adminRoles = new List<IdentityUserRole<string>>()
        {
            new IdentityUserRole<string>()
            {
                RoleId = readerRoleId,
                UserId = adminUserId
            },
            new IdentityUserRole<string>()
            {
                RoleId = writerRoleId,
                UserId = adminUserId
            }
        };

        builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);
    }

}
