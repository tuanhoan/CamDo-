using BaseSource.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Identity data
            var roleAdminId = (new Guid("c1105ce5-9dbc-49a9-a7d5-c963b6daa62a")).ToString();

            modelBuilder.Entity<AppRole>().HasData(
                new AppRole
                {
                    Id = roleAdminId,
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Description = "Administrator role"
                });

            var userAdminId = (new Guid("ffded6b0-3769-4976-841b-69459049a62d")).ToString();
            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = userAdminId,
                UserName = "superadmin",
                NormalizedUserName = "superadmin",
                Email = "doangiau2006@gmail.com",
                NormalizedEmail = "doangiau2006@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Password@1"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleAdminId,
                UserId = userAdminId
            });

            //modelBuilder.Entity<UserProfile>().HasData(
            //   new UserProfile
            //   {
            //       UserId = userAdminId,
            //       CustomId = userAdminId,
            //       FullName = "Nguyễn Giàu",
            //       JoinedDate = new DateTime(2022, 1, 1)
            //   });
        }
    }
}
