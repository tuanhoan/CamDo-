using BaseSource.Data.Configurations;
using BaseSource.Data.Entities;
using BaseSource.Data.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.Data.EF
{
    public class BaseSourceDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public BaseSourceDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure using Fluent API

            #region Identity
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());

            modelBuilder.ApplyConfiguration(new SettingConfiguration());
            modelBuilder.ApplyConfiguration(new UserProfileConfiguration());
            modelBuilder.ApplyConfiguration(new CuaHangConfiguration());
            modelBuilder.ApplyConfiguration(new KhachHangConfiguration());
            modelBuilder.ApplyConfiguration(new CauHinhHangHoaConfiguration());
            modelBuilder.ApplyConfiguration(new MoTaHinhThucLaiConfiguration());
            modelBuilder.ApplyConfiguration(new ReportCustomerConfiguration());
            modelBuilder.ApplyConfiguration(new FeedBackConfiguration());
            modelBuilder.ApplyConfiguration(new HopDongConfiguration());
            modelBuilder.ApplyConfiguration(new NotifySystemConfiguration());
            modelBuilder.ApplyConfiguration(new GoiSanPhamConfiguration());
            modelBuilder.ApplyConfiguration(new HopDong_AlarmLogConfiguration());
            modelBuilder.ApplyConfiguration(new HopDong_VayRutGocConfiguration());
            modelBuilder.ApplyConfiguration(new HopDong_GiaHanConfiguration());
            modelBuilder.ApplyConfiguration(new HopDong_PaymentLogConfiguration());
            modelBuilder.ApplyConfiguration(new HopDong_PaymentLogNoteConfiguration());
            modelBuilder.ApplyConfiguration(new CuaHang_TransactionLogConfiguration());
            modelBuilder.ApplyConfiguration(new CuaHang_QuyTienLogConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorFunctionConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorUserFunctionConfiguration());

            //modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("AppUserClaims").HasKey(x => x.Id);
            modelBuilder.Entity<IdentityUserClaim<string>>().Property(x => x.UserId).HasMaxLength(128);

            //modelBuilder.Entity<IdentityUserRole<string>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserRole<string>>().Property(x => x.UserId).HasMaxLength(128);
            modelBuilder.Entity<IdentityUserRole<string>>().Property(x => x.RoleId).HasMaxLength(128);

            //modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("AppUserLogins").HasKey(x => new { x.LoginProvider, x.ProviderKey });
            modelBuilder.Entity<IdentityUserLogin<string>>().Property(x => x.UserId).HasMaxLength(128);
            //modelBuilder.Entity<IdentityUserLogin<string>>().Property(x => x.LoginProvider).HasMaxLength(128);
            //modelBuilder.Entity<IdentityUserLogin<string>>().Property(x => x.ProviderKey).HasMaxLength(128);

            //modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("AppRoleClaims").HasKey(x => x.Id);
            modelBuilder.Entity<IdentityRoleClaim<string>>().Property(x => x.RoleId).HasMaxLength(128);

            //modelBuilder.Entity<IdentityUserToken<string>>().ToTable("AppUserTokens").HasKey(x => new { x.UserId, x.LoginProvider, x.Name });
            modelBuilder.Entity<IdentityUserToken<string>>().Property(x => x.UserId).HasMaxLength(128);
            //modelBuilder.Entity<IdentityUserToken<string>>().Property(x => x.LoginProvider).HasMaxLength(128);

            #endregion


            //Data seeding
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Setting> Settings { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<CuaHang> CuaHangs { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<LienHe> LienHes { get; set; }
        public DbSet<CauHinhHangHoa> CauHinhHangHoas { get; set; }
        public DbSet<MoTaHinhThucLai> MoTaHinhThucLais { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<ReportCustomer> ReportCustomers { get; set; }
        public DbSet<HopDong> HopDongs { get; set; }
        public DbSet<GoiSanPham> GoiSanPhams { get; set; }
        public DbSet<NotifySystem> NotifySystems { get; set; }
        public DbSet<HopDong_AlarmLog> HopDong_AlarmLogs { get; set; }
        public DbSet<HopDong_VayRutGoc> HopDong_VayRutGocs { get; set; }
        public DbSet<HopDong_GiaHan> HopDong_GiaHans { get; set; }
        public DbSet<HopDong_PaymentLog> HopDong_PaymentLogs { get; set; }
        public DbSet<HopDong_PaymentLogNote> HopDong_PaymentLogNotes { get; set; }
        public DbSet<CuaHang_TransactionLog> CuaHang_TransactionLogs { get; set; }
        public DbSet<HopDong_DebtNote> HopDong_DebtNotes { get; set; }
        public DbSet<CuaHang_QuyTienLog> CuaHang_QuyTienLogs { get; set; }
        public DbSet<DanhMucBaiViet> DanhMucBaiViets { get; set; }
        public DbSet<BaiViet> BaiViets { get; set; }
        public DbSet<AuthorFunction> AuthorFunctions { get; set; }
        public DbSet<AuthorUserFunction> AuthorUserFunctions { get; set; }
    }
}

