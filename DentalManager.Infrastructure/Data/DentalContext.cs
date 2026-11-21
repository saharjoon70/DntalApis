using DentalManager.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DentalManager.Infrastructure.Data;

public partial class DentalContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
{
    public DentalContext() { }
    public DentalContext(DbContextOptions<DentalContext> options) : base(options) { }

    public virtual DbSet<ApplicationRole> AppRoles { get; set; } = null!;
    public virtual DbSet<ApplicationUser> AppUsers { get; set; } = null!;
    public virtual DbSet<ApplicationUserRole> AppUserRoles { get; set; } = null!;

    public virtual DbSet<TlbRefreshToken> TlbRefreshTokens { get; set; } = null!;
    public virtual DbSet<TlbLoginLog> TlbLoginLogs { get; set; } = null!;

    public virtual DbSet<Contract> Contracts { get; set; } = null!;
    public virtual DbSet<Doctor> Doctors { get; set; } = null!;
    public virtual DbSet<Employee> Employees { get; set; } = null!;
    public virtual DbSet<UserAbsence> UserAbsences { get; set; } = null!;
    public virtual DbSet<UserShift> UserShifts { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // ---------- Role ----------
        modelBuilder.Entity<ApplicationRole>(entity =>
        {
            entity.ToTable("AspNetRoles");
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
            entity.Property(e => e.FaName).HasMaxLength(256);
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex").IsUnique().HasFilter("([NormalizedName] IS NOT NULL)");
        });

        // ---------- User ----------
        modelBuilder.Entity<ApplicationUser>(entity =>
        {
            entity.ToTable("AspNetUsers");
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");
            entity.HasIndex(e => e.Email, "IX_AspNetUsers_Email").IsUnique().HasFilter("([Email] IS NOT NULL)");
            entity.HasIndex(e => e.UserName, "IX_AspNetUsers_UserName").IsUnique().HasFilter("([UserName] IS NOT NULL)");
            entity.HasIndex(e => e.OfficeId, "IX_AspNetUsers_OfficeId");
            entity.Property(e => e.Address).HasMaxLength(450);
            entity.Property(e => e.AddressHome).HasMaxLength(450);
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FirstName).HasMaxLength(450);
            entity.Property(e => e.LastName).HasMaxLength(450);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);
            entity.Property(e => e.Reagent).HasColumnName("reagent");
            entity.Property(e => e.SendSms).HasColumnName("SendSMS");
        });

        // ---------- UserRole ----------
        modelBuilder.Entity<ApplicationUserRole>(entity =>
        {
            entity.ToTable("AspNetUserRoles");
            entity.HasKey(ur => new { ur.UserId, ur.RoleId });
            entity.HasOne(ur => ur.User).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.UserId).OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(ur => ur.Role).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.RoleId).OnDelete(DeleteBehavior.Cascade);
        });

        // ---------- Doctor ----------
        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasIndex(e => e.UserId).IsUnique();
            entity.Property(e => e.MedicalCode).HasMaxLength(50);
            entity.Property(e => e.Specialty).HasMaxLength(200);
            entity.HasOne(e => e.User).WithOne(u => u.Doctor!).HasForeignKey<Doctor>(e => e.UserId).OnDelete(DeleteBehavior.Cascade);
        });

        // ---------- Employee ----------
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasIndex(e => e.UserId).IsUnique();
            entity.Property(e => e.Position).HasMaxLength(100);
            entity.HasOne(e => e.User).WithOne(u => u.Employee!).HasForeignKey<Employee>(e => e.UserId).OnDelete(DeleteBehavior.Cascade);
        });

        // ---------- Contract ----------
        modelBuilder.Entity<Contract>(entity =>
        {
            entity.Property(e => e.StartDate).HasColumnType("date");
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.BaseSalary).HasPrecision(18, 2);
            entity.Property(e => e.Commission).HasPrecision(18, 2);
            entity.Property(e => e.Bonus).HasPrecision(18, 2);
            entity.Property(e => e.Transport).HasPrecision(18, 2);
            entity.Property(e => e.Overtime).HasPrecision(18, 2);
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.Insurance).HasMaxLength(50);
            entity.Property(e => e.Tax).HasMaxLength(20);
            entity.Property(e => e.CardNumber).HasMaxLength(30);
            entity.Property(e => e.Duration).HasMaxLength(10);
            entity.Property(e => e.ContractType).HasMaxLength(30);
            entity.Property(e => e.PaymentType).HasMaxLength(30);
            entity.HasIndex(e => e.UserId);
            entity.HasOne(e => e.User).WithMany(u => u.Contracts).HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Cascade);
        });

        // ---------- UserAbsence ----------
        modelBuilder.Entity<UserAbsence>(entity =>
        {
            entity.Property(e => e.Date).HasColumnType("date");
            entity.HasIndex(e => new { e.UserId, e.Date }).IsUnique();
            entity.HasOne(e => e.User).WithMany(u => u.Absences).HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Cascade);
        });

        // ---------- UserShift ----------
        modelBuilder.Entity<UserShift>(entity =>
        {
            entity.HasIndex(e => new { e.UserId, e.DayOfWeek }).IsUnique();
            entity.HasOne(e => e.User).WithMany(u => u.Shifts).HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Cascade);
        });

        // ---------- RefreshToken ----------
        modelBuilder.Entity<TlbRefreshToken>(entity =>
        {
            entity.HasIndex(e => e.Token).IsUnique();
            entity.HasOne(e => e.User).WithMany(u => u.RefreshTokens).HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Cascade);
        });

        // ---------- LoginLog ----------
        modelBuilder.Entity<TlbLoginLog>(entity =>
        {
            entity.HasOne(e => e.User).WithMany(u => u.LoginLogs).HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Cascade);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}