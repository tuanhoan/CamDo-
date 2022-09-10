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
            var roleShopManagerId = (new Guid("3a1cf1ce-83be-44ed-a5fe-6b2f25ffae32")).ToString();
            var staff = (new Guid("ffded6b0-37d9-4676-241b-69459029a622")).ToString();

            modelBuilder.Entity<AppRole>().HasData(
                new AppRole
                {
                    Id = roleAdminId,
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Description = "Administrator role"
                });
            modelBuilder.Entity<AppRole>().HasData(
                new AppRole
                {
                    Id = roleShopManagerId,
                    Name = "ShopManager",
                    NormalizedName = "ShopManager",
                    Description = "Shop Manager role"
                });
            modelBuilder.Entity<AppRole>().HasData(
                new AppRole
                {
                    Id = staff,
                    Name = "Staff",
                    NormalizedName = "Staff",
                    Description = "Staff"
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

            modelBuilder.Entity<UserProfile>().HasData(
               new UserProfile
               {
                   UserId = userAdminId,
                   CustomId = userAdminId,
                   FullName = "Nguyễn Giàu",
                   JoinedDate = new DateTime(2022, 1, 1)
               });
            modelBuilder.Entity<MoTaHinhThucLai>().HasData(
               new MoTaHinhThucLai
               {
                   Id = 99,
                   HinhThucLai = null,
                   MoTaKyLai = "Đầu tư",
                   ThoiGian = 0,
                   TyLeLai = "Không tính lãi"
               });
        }
    }
}
