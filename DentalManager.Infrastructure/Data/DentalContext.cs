using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DentalManager.Domain.Entities;

namespace DentalManager.Infrastructure.Data;

public partial class DentalContext : DbContext
{
    public DentalContext()
    {
    }

    public DentalContext(DbContextOptions<DentalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AggregatedCounter> AggregatedCounters { get; set; }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<BankAccountStaff> BankAccountStaffs { get; set; }

    public virtual DbSet<Counter> Counters { get; set; }

    public virtual DbSet<DashboardSummery> DashboardSummeries { get; set; }

    public virtual DbSet<EmployeeBenefit> EmployeeBenefits { get; set; }

    public virtual DbSet<Hash> Hashes { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<JobParameter> JobParameters { get; set; }

    public virtual DbSet<JobQueue> JobQueues { get; set; }

    public virtual DbSet<List> Lists { get; set; }

    public virtual DbSet<Payroll> Payrolls { get; set; }

    public virtual DbSet<PayrollItem> PayrollItems { get; set; }

    public virtual DbSet<PayrollItemType> PayrollItemTypes { get; set; }

    public virtual DbSet<PayrollSetting> PayrollSettings { get; set; }

    public virtual DbSet<ReminderNotification> ReminderNotifications { get; set; }

    public virtual DbSet<SalaryPayment> SalaryPayments { get; set; }

    public virtual DbSet<Schema> Schemas { get; set; }

    public virtual DbSet<Server> Servers { get; set; }

    public virtual DbSet<Set> Sets { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<TlbAccountGeneralChart> TlbAccountGeneralCharts { get; set; }

    public virtual DbSet<TlbArrivalGood> TlbArrivalGoods { get; set; }

    public virtual DbSet<TlbBank> TlbBanks { get; set; }

    public virtual DbSet<TlbBankAccount> TlbBankAccounts { get; set; }

    public virtual DbSet<TlbConsentService> TlbConsentServices { get; set; }

    public virtual DbSet<TlbContract> TlbContracts { get; set; }

    public virtual DbSet<TlbCost> TlbCosts { get; set; }

    public virtual DbSet<TlbCostPaysDetail> TlbCostPaysDetails { get; set; }

    public virtual DbSet<TlbCzechBook> TlbCzechBooks { get; set; }

    public virtual DbSet<TlbDbbackup> TlbDbbackups { get; set; }

    public virtual DbSet<TlbDbpatternMessage> TlbDbpatternMessages { get; set; }

    public virtual DbSet<TlbDoctor> TlbDoctors { get; set; }

    public virtual DbSet<TlbDoctorTimeSchedule> TlbDoctorTimeSchedules { get; set; }

    public virtual DbSet<TlbDrug> TlbDrugs { get; set; }

    public virtual DbSet<TlbEmployee> TlbEmployees { get; set; }

    public virtual DbSet<TlbEmployeeCost> TlbEmployeeCosts { get; set; }

    public virtual DbSet<TlbExitGood> TlbExitGoods { get; set; }

    public virtual DbSet<TlbFactorsCost> TlbFactorsCosts { get; set; }

    public virtual DbSet<TlbFolderDocsAttachment> TlbFolderDocsAttachments { get; set; }

    public virtual DbSet<TlbInsuranceType> TlbInsuranceTypes { get; set; }

    public virtual DbSet<TlbInsurence> TlbInsurences { get; set; }

    public virtual DbSet<TlbInsurenceConsume> TlbInsurenceConsumes { get; set; }

    public virtual DbSet<TlbInsurenceSrvice> TlbInsurenceSrvices { get; set; }

    public virtual DbSet<TlbLabOrder> TlbLabOrders { get; set; }

    public virtual DbSet<TlbLabService> TlbLabServices { get; set; }

    public virtual DbSet<TlbLabServiceOrder> TlbLabServiceOrders { get; set; }

    public virtual DbSet<TlbLabType> TlbLabTypes { get; set; }

    public virtual DbSet<TlbLeaf> TlbLeaves { get; set; }

    public virtual DbSet<TlbMainCash> TlbMainCashes { get; set; }

    public virtual DbSet<TlbOfficeAdmin> TlbOfficeAdmins { get; set; }

    public virtual DbSet<TlbOfficeBuilding> TlbOfficeBuildings { get; set; }

    public virtual DbSet<TlbOfficePlan> TlbOfficePlans { get; set; }

    public virtual DbSet<TlbPatientsFolder> TlbPatientsFolders { get; set; }

    public virtual DbSet<TlbPayment> TlbPayments { get; set; }

    public virtual DbSet<TlbReserf> TlbReserves { get; set; }

    public virtual DbSet<TlbReservedDate> TlbReservedDates { get; set; }

    public virtual DbSet<TlbSendedMessage> TlbSendedMessages { get; set; }

    public virtual DbSet<TlbService> TlbServices { get; set; }

    public virtual DbSet<TlbStock> TlbStocks { get; set; }

    public virtual DbSet<TlbStockGroup> TlbStockGroups { get; set; }

    public virtual DbSet<TlbSystematicDisease> TlbSystematicDiseases { get; set; }

    public virtual DbSet<TlbTeethLab> TlbTeethLabs { get; set; }

    public virtual DbSet<TlbTiming> TlbTimings { get; set; }

    public virtual DbSet<TlbTransaction> TlbTransactions { get; set; }

    public virtual DbSet<TlbTreatmentDrug> TlbTreatmentDrugs { get; set; }

    public virtual DbSet<TlbTreatmentItem> TlbTreatmentItems { get; set; }

    public virtual DbSet<TlbTreatmentPlan> TlbTreatmentPlans { get; set; }

    public virtual DbSet<TlbTreatmentService> TlbTreatmentServices { get; set; }

    public virtual DbSet<TlbVTreatmentItem> TlbVTreatmentItems { get; set; }

    public virtual DbSet<TlbVTreatmentService> TlbVTreatmentServices { get; set; }

    public virtual DbSet<TlbWarehouse> TlbWarehouses { get; set; }

    public virtual DbSet<Tlblaboratory> Tlblaboratories { get; set; }

    public virtual DbSet<TlbposDevice> TlbposDevices { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AggregatedCounter>(entity =>
        {
            entity.HasKey(e => e.Key).HasName("PK_HangFire_CounterAggregated");

            entity.ToTable("AggregatedCounter", "HangFire");

            entity.HasIndex(e => e.ExpireAt, "IX_HangFire_AggregatedCounter_ExpireAt").HasFilter("([ExpireAt] IS NOT NULL)");

            entity.Property(e => e.Key).HasMaxLength(100);
            entity.Property(e => e.ExpireAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.Name, "IX_AspNetRoles_Name")
                .IsUnique()
                .HasFilter("([Name] IS NOT NULL)");

            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.Email, "IX_AspNetUsers_Email")
                .IsUnique()
                .HasFilter("([Email] IS NOT NULL)");

            entity.HasIndex(e => e.OfficeId, "IX_AspNetUsers_OfficeId");

            entity.HasIndex(e => e.UserName, "IX_AspNetUsers_UserName")
                .IsUnique()
                .HasFilter("([UserName] IS NOT NULL)");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Address).HasMaxLength(450);
            entity.Property(e => e.AddressHome).HasMaxLength(450);
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FirstName).HasMaxLength(450);
            entity.Property(e => e.LastName).HasMaxLength(450);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.Reagent).HasColumnName("reagent");
            entity.Property(e => e.SendSms).HasColumnName("SendSMS");
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasOne(d => d.Office).WithMany(p => p.AspNetUsers).HasForeignKey(d => d.OfficeId);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<BankAccountStaff>(entity =>
        {
            entity.HasKey(e => e.BankAccountId);

            entity.ToTable("BankAccount_staff");

            entity.HasIndex(e => e.BankId, "IX_BankAccount_staff_BankId");

            entity.HasIndex(e => e.StaffId, "IX_BankAccount_staff_StaffId");

            entity.Property(e => e.AccountDetailCode).HasMaxLength(6);
            entity.Property(e => e.AccountNumber).HasMaxLength(30);
            entity.Property(e => e.CardNumber).HasMaxLength(30);
            entity.Property(e => e.Iban)
                .HasMaxLength(30)
                .HasColumnName("IBAN");

            entity.HasOne(d => d.Bank).WithMany(p => p.BankAccountStaffs).HasForeignKey(d => d.BankId);

            entity.HasOne(d => d.Staff).WithMany(p => p.BankAccountStaffs).HasForeignKey(d => d.StaffId);
        });

        modelBuilder.Entity<Counter>(entity =>
        {
            entity.HasKey(e => new { e.Key, e.Id }).HasName("PK_HangFire_Counter");

            entity.ToTable("Counter", "HangFire");

            entity.Property(e => e.Key).HasMaxLength(100);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ExpireAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<DashboardSummery>(entity =>
        {
            entity.ToTable("DashboardSummery");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.TodayIncome).HasColumnType("decimal(19, 2)");
        });

        modelBuilder.Entity<EmployeeBenefit>(entity =>
        {
            entity.ToTable("Employee_Benefits");

            entity.HasIndex(e => e.PayrollItemTypeId, "IX_Employee_Benefits_PayrollItemTypeId");

            entity.HasIndex(e => e.ContractId, "IX_Employee_Benefits_contractId");

            entity.Property(e => e.ContractId).HasColumnName("contractId");
            entity.Property(e => e.CustomAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Contract).WithMany(p => p.EmployeeBenefits).HasForeignKey(d => d.ContractId);

            entity.HasOne(d => d.PayrollItemType).WithMany(p => p.EmployeeBenefits).HasForeignKey(d => d.PayrollItemTypeId);
        });

        modelBuilder.Entity<Hash>(entity =>
        {
            entity.HasKey(e => new { e.Key, e.Field }).HasName("PK_HangFire_Hash");

            entity.ToTable("Hash", "HangFire");

            entity.HasIndex(e => e.ExpireAt, "IX_HangFire_Hash_ExpireAt").HasFilter("([ExpireAt] IS NOT NULL)");

            entity.Property(e => e.Key).HasMaxLength(100);
            entity.Property(e => e.Field).HasMaxLength(100);
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_HangFire_Job");

            entity.ToTable("Job", "HangFire");

            entity.HasIndex(e => e.ExpireAt, "IX_HangFire_Job_ExpireAt").HasFilter("([ExpireAt] IS NOT NULL)");

            entity.HasIndex(e => e.StateName, "IX_HangFire_Job_StateName").HasFilter("([StateName] IS NOT NULL)");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.ExpireAt).HasColumnType("datetime");
            entity.Property(e => e.StateName).HasMaxLength(20);
        });

        modelBuilder.Entity<JobParameter>(entity =>
        {
            entity.HasKey(e => new { e.JobId, e.Name }).HasName("PK_HangFire_JobParameter");

            entity.ToTable("JobParameter", "HangFire");

            entity.Property(e => e.Name).HasMaxLength(40);

            entity.HasOne(d => d.Job).WithMany(p => p.JobParameters)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK_HangFire_JobParameter_Job");
        });

        modelBuilder.Entity<JobQueue>(entity =>
        {
            entity.HasKey(e => new { e.Queue, e.Id }).HasName("PK_HangFire_JobQueue");

            entity.ToTable("JobQueue", "HangFire");

            entity.Property(e => e.Queue).HasMaxLength(50);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.FetchedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<List>(entity =>
        {
            entity.HasKey(e => new { e.Key, e.Id }).HasName("PK_HangFire_List");

            entity.ToTable("List", "HangFire");

            entity.HasIndex(e => e.ExpireAt, "IX_HangFire_List_ExpireAt").HasFilter("([ExpireAt] IS NOT NULL)");

            entity.Property(e => e.Key).HasMaxLength(100);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ExpireAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<Payroll>(entity =>
        {
            entity.ToTable("Payroll");

            entity.HasIndex(e => e.EmployeeId, "IX_Payroll_EmployeeId");

            entity.Property(e => e.HolidayHours).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NetSalary).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.OverTimeHours).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.TotalDeductions).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalEarnings).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Employee).WithMany(p => p.Payrolls).HasForeignKey(d => d.EmployeeId);
        });

        modelBuilder.Entity<PayrollItem>(entity =>
        {
            entity.ToTable("PayrollItem");

            entity.HasIndex(e => e.ItemTypeId, "IX_PayrollItem_ItemTypeId");

            entity.HasIndex(e => e.PayrollId1, "IX_PayrollItem_PayrollId1");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.ItemType).WithMany(p => p.PayrollItems).HasForeignKey(d => d.ItemTypeId);

            entity.HasOne(d => d.PayrollId1Navigation).WithMany(p => p.PayrollItems).HasForeignKey(d => d.PayrollId1);
        });

        modelBuilder.Entity<PayrollItemType>(entity =>
        {
            entity.ToTable("PayrollItemType");
        });

        modelBuilder.Entity<PayrollSetting>(entity =>
        {
            entity.ToTable("PayrollSetting");

            entity.HasIndex(e => e.ItemTypeId, "IX_PayrollSetting_ItemTypeId");

            entity.Property(e => e.Value).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.ItemType).WithMany(p => p.PayrollSettings).HasForeignKey(d => d.ItemTypeId);
        });

        modelBuilder.Entity<ReminderNotification>(entity =>
        {
            entity.ToTable("ReminderNotification");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Discripton).HasColumnName("discripton");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Time).HasColumnName("time");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.Userid).HasColumnName("userid");
        });

        modelBuilder.Entity<SalaryPayment>(entity =>
        {
            entity.ToTable("Salary_Payments");

            entity.HasIndex(e => e.PayrollId, "IX_Salary_Payments_PayrollId");

            entity.HasIndex(e => e.TransactionId, "IX_Salary_Payments_TransactionId");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Payroll).WithMany(p => p.SalaryPayments).HasForeignKey(d => d.PayrollId);

            entity.HasOne(d => d.Transaction).WithMany(p => p.SalaryPayments).HasForeignKey(d => d.TransactionId);
        });

        modelBuilder.Entity<Schema>(entity =>
        {
            entity.HasKey(e => e.Version).HasName("PK_HangFire_Schema");

            entity.ToTable("Schema", "HangFire");

            entity.Property(e => e.Version).ValueGeneratedNever();
        });

        modelBuilder.Entity<Server>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_HangFire_Server");

            entity.ToTable("Server", "HangFire");

            entity.HasIndex(e => e.LastHeartbeat, "IX_HangFire_Server_LastHeartbeat");

            entity.Property(e => e.Id).HasMaxLength(200);
            entity.Property(e => e.LastHeartbeat).HasColumnType("datetime");
        });

        modelBuilder.Entity<Set>(entity =>
        {
            entity.HasKey(e => new { e.Key, e.Value }).HasName("PK_HangFire_Set");

            entity.ToTable("Set", "HangFire");

            entity.HasIndex(e => e.ExpireAt, "IX_HangFire_Set_ExpireAt").HasFilter("([ExpireAt] IS NOT NULL)");

            entity.HasIndex(e => new { e.Key, e.Score }, "IX_HangFire_Set_Score");

            entity.Property(e => e.Key).HasMaxLength(100);
            entity.Property(e => e.Value).HasMaxLength(256);
            entity.Property(e => e.ExpireAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => new { e.JobId, e.Id }).HasName("PK_HangFire_State");

            entity.ToTable("State", "HangFire");

            entity.HasIndex(e => e.CreatedAt, "IX_HangFire_State_CreatedAt");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.Reason).HasMaxLength(100);

            entity.HasOne(d => d.Job).WithMany(p => p.States)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK_HangFire_State_Job");
        });

        modelBuilder.Entity<TlbAccountGeneralChart>(entity =>
        {
            entity.HasKey(e => e.AccountCode);

            entity.ToTable("TlbAccount_General_Chart");

            entity.Property(e => e.AccountCode)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.HeadAccountCode)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RootHeadCode)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<TlbArrivalGood>(entity =>
        {
            entity.HasKey(e => e.RecieptId);

            entity.HasIndex(e => e.StockId, "IX_TlbArrivalGoods_stockId");

            entity.Property(e => e.StockId).HasColumnName("stockId");

            entity.HasOne(d => d.Stock).WithMany(p => p.TlbArrivalGoods).HasForeignKey(d => d.StockId);
        });

        modelBuilder.Entity<TlbBank>(entity =>
        {
            entity.HasKey(e => e.BankId);

            entity.ToTable("TlbBank");

            entity.Property(e => e.BankName).HasMaxLength(150);
        });

        modelBuilder.Entity<TlbBankAccount>(entity =>
        {
            entity.HasKey(e => e.BankAccountId);

            entity.ToTable("TlbBankAccount");

            entity.HasIndex(e => e.BankId, "IX_TlbBankAccount_BankId");

            entity.HasIndex(e => e.FundId, "IX_TlbBankAccount_FundId");

            entity.Property(e => e.AccountDetailCode).HasMaxLength(6);
            entity.Property(e => e.AccountNumber).HasMaxLength(30);
            entity.Property(e => e.CardNumber).HasMaxLength(30);
            entity.Property(e => e.Iban)
                .HasMaxLength(30)
                .HasColumnName("IBAN");
            entity.Property(e => e.Owenr).HasMaxLength(100);
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.Bank).WithMany(p => p.TlbBankAccounts)
                .HasForeignKey(d => d.BankId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Fund).WithMany(p => p.TlbBankAccounts)
                .HasForeignKey(d => d.FundId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<TlbConsentService>(entity =>
        {
            entity.ToTable("TlbConsentService");
        });

        modelBuilder.Entity<TlbContract>(entity =>
        {
            entity.HasKey(e => e.ContractId);

            entity.ToTable("TlbContract");

            entity.HasIndex(e => e.PersonId, "IX_TlbContract_PersonId");

            entity.Property(e => e.BaseSalary).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HourlyRate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.JobTitle).HasMaxLength(100);
            entity.Property(e => e.LetterNumber).HasMaxLength(50);
            entity.Property(e => e.PayType).HasMaxLength(50);
            entity.Property(e => e.PercentRate).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.Person).WithMany(p => p.TlbContracts).HasForeignKey(d => d.PersonId);
        });

        modelBuilder.Entity<TlbCost>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
        });

        modelBuilder.Entity<TlbCostPaysDetail>(entity =>
        {
            entity.HasIndex(e => e.CostRIdForignKey, "IX_TlbCostPaysDetails_CostR_id_forignKey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CostRIdForignKey).HasColumnName("CostR_id_forignKey");

            entity.HasOne(d => d.CostRIdForignKeyNavigation).WithMany(p => p.TlbCostPaysDetails).HasForeignKey(d => d.CostRIdForignKey);
        });

        modelBuilder.Entity<TlbCzechBook>(entity =>
        {
            entity.HasIndex(e => e.FolderId, "IX_TlbCzechBooks_FolderId");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.Folder).WithMany(p => p.TlbCzechBooks).HasForeignKey(d => d.FolderId);
        });

        modelBuilder.Entity<TlbDbbackup>(entity =>
        {
            entity.ToTable("TlbDBBackup");

            entity.Property(e => e.Id).HasColumnName("id");
        });

        modelBuilder.Entity<TlbDbpatternMessage>(entity =>
        {
            entity.ToTable("TlbDBPatternMessage");
        });

        modelBuilder.Entity<TlbDoctor>(entity =>
        {
            entity.HasKey(e => e.PersonnelCode);

            entity.HasIndex(e => e.TlbOfficeid, "IX_TlbDoctors_TlbOfficeid");

            entity.HasIndex(e => e.UserId, "IX_TlbDoctors_UserId")
                .IsUnique()
                .HasFilter("([UserId] IS NOT NULL)");

            entity.Property(e => e.AccountDetailCode).HasMaxLength(6);

            entity.HasOne(d => d.TlbOffice).WithMany(p => p.TlbDoctors).HasForeignKey(d => d.TlbOfficeid);

            entity.HasOne(d => d.User).WithOne(p => p.TlbDoctor).HasForeignKey<TlbDoctor>(d => d.UserId);
        });

        modelBuilder.Entity<TlbDoctorTimeSchedule>(entity =>
        {
            entity.ToTable("TlbDoctorTimeSchedule");

            entity.HasIndex(e => e.DoctorId, "IX_TlbDoctorTimeSchedule_doctorId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DoctorId).HasColumnName("doctorId");

            entity.HasOne(d => d.Doctor).WithMany(p => p.TlbDoctorTimeSchedules).HasForeignKey(d => d.DoctorId);
        });

        modelBuilder.Entity<TlbEmployee>(entity =>
        {
            entity.ToTable("TlbEmployee");

            entity.Property(e => e.Id).HasColumnName("id");
        });

        modelBuilder.Entity<TlbEmployeeCost>(entity =>
        {
            entity.HasIndex(e => e.CostId, "IX_TlbEmployeeCosts_CostId").IsUnique();

            entity.HasIndex(e => e.EmployerId, "IX_TlbEmployeeCosts_EmployerId");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.Cost).WithOne(p => p.TlbEmployeeCost).HasForeignKey<TlbEmployeeCost>(d => d.CostId);

            entity.HasOne(d => d.Employer).WithMany(p => p.TlbEmployeeCosts).HasForeignKey(d => d.EmployerId);
        });

        modelBuilder.Entity<TlbExitGood>(entity =>
        {
            entity.HasIndex(e => e.PatientsFolderFolderid, "IX_TlbExitGoods_PatientsFolderFolderid");

            entity.HasIndex(e => e.StockId, "IX_TlbExitGoods_stockId");

            entity.Property(e => e.StockId).HasColumnName("stockId");

            entity.HasOne(d => d.PatientsFolderFolder).WithMany(p => p.TlbExitGoods).HasForeignKey(d => d.PatientsFolderFolderid);

            entity.HasOne(d => d.Stock).WithMany(p => p.TlbExitGoods).HasForeignKey(d => d.StockId);
        });

        modelBuilder.Entity<TlbFactorsCost>(entity =>
        {
            entity.HasIndex(e => e.CostId, "IX_TlbFactorsCosts_CostId").IsUnique();

            entity.HasIndex(e => e.DoctorId, "IX_TlbFactorsCosts_doctorId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DoctorId).HasColumnName("doctorId");
            entity.Property(e => e.Receiver).HasColumnName("receiver");

            entity.HasOne(d => d.Cost).WithOne(p => p.TlbFactorsCost).HasForeignKey<TlbFactorsCost>(d => d.CostId);

            entity.HasOne(d => d.Doctor).WithMany(p => p.TlbFactorsCosts).HasForeignKey(d => d.DoctorId);
        });

        modelBuilder.Entity<TlbFolderDocsAttachment>(entity =>
        {
            entity.HasIndex(e => e.FolderId, "IX_TlbFolderDocsAttachments_FolderId");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.Folder).WithMany(p => p.TlbFolderDocsAttachments).HasForeignKey(d => d.FolderId);
        });

        modelBuilder.Entity<TlbInsuranceType>(entity =>
        {
            entity.ToTable("TlbInsuranceType");
        });

        modelBuilder.Entity<TlbInsurence>(entity =>
        {
            entity.HasIndex(e => e.TypeId, "IX_TlbInsurences_TypeId");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.Type).WithMany(p => p.TlbInsurences)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<TlbInsurenceConsume>(entity =>
        {
            entity.ToTable("TlbInsurence_Consume");

            entity.HasIndex(e => e.ReserveCode, "IX_TlbInsurence_Consume_ReserveCode");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.ReserveCodeNavigation).WithMany(p => p.TlbInsurenceConsumes).HasForeignKey(d => d.ReserveCode);
        });

        modelBuilder.Entity<TlbInsurenceSrvice>(entity =>
        {
            entity.ToTable("TlbInsurence_Srvice");

            entity.HasIndex(e => e.DentalServicesId, "IX_TlbInsurence_Srvice_DentalServicesId");

            entity.HasIndex(e => e.InsuranceId, "IX_TlbInsurence_Srvice_InsuranceId");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.DentalServices).WithMany(p => p.TlbInsurenceSrvices).HasForeignKey(d => d.DentalServicesId);

            entity.HasOne(d => d.Insurance).WithMany(p => p.TlbInsurenceSrvices).HasForeignKey(d => d.InsuranceId);
        });

        modelBuilder.Entity<TlbLabOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId);

            entity.HasIndex(e => e.CostId, "IX_TlbLabOrders_CostId").IsUnique();

            entity.HasIndex(e => e.DocttorId, "IX_TlbLabOrders_DocttorId");

            entity.HasIndex(e => e.LabId, "IX_TlbLabOrders_LabId");

            entity.HasIndex(e => e.Patientd, "IX_TlbLabOrders_Patientd");

            entity.Property(e => e.Cancel).HasColumnName("cancel");

            entity.HasOne(d => d.Cost).WithOne(p => p.TlbLabOrder).HasForeignKey<TlbLabOrder>(d => d.CostId);

            entity.HasOne(d => d.Docttor).WithMany(p => p.TlbLabOrders).HasForeignKey(d => d.DocttorId);

            entity.HasOne(d => d.Lab).WithMany(p => p.TlbLabOrders).HasForeignKey(d => d.LabId);

            entity.HasOne(d => d.PatientdNavigation).WithMany(p => p.TlbLabOrders)
                .HasForeignKey(d => d.Patientd)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<TlbLabService>(entity =>
        {
            entity.ToTable("TlbLabService");

            entity.Property(e => e.Id).HasColumnName("id");
        });

        modelBuilder.Entity<TlbLabServiceOrder>(entity =>
        {
            entity.ToTable("TlbLabServiceOrder");

            entity.HasIndex(e => e.OrderId, "IX_TlbLabServiceOrder_OrderId");

            entity.HasIndex(e => e.ServiceLabId, "IX_TlbLabServiceOrder_ServiceLabId");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.Order).WithMany(p => p.TlbLabServiceOrders).HasForeignKey(d => d.OrderId);

            entity.HasOne(d => d.ServiceLab).WithMany(p => p.TlbLabServiceOrders).HasForeignKey(d => d.ServiceLabId);
        });

        modelBuilder.Entity<TlbLabType>(entity =>
        {
            entity.ToTable("TlbLabType");

            entity.Property(e => e.Id).HasColumnName("id");
        });

        modelBuilder.Entity<TlbLeaf>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_TlbLeaves_UserId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Input).HasColumnName("input");
            entity.Property(e => e.Output).HasColumnName("output");

            entity.HasOne(d => d.User).WithMany(p => p.TlbLeaves).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<TlbMainCash>(entity =>
        {
            entity.HasKey(e => e.FundId);

            entity.ToTable("TlbMain_Cash");

            entity.HasIndex(e => e.OfficeId, "IX_TlbMain_Cash_OfficeId");

            entity.Property(e => e.AccountDetailCode).HasMaxLength(6);
            entity.Property(e => e.FundName).HasMaxLength(50);

            entity.HasOne(d => d.Office).WithMany(p => p.TlbMainCashes)
                .HasForeignKey(d => d.OfficeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<TlbOfficeAdmin>(entity =>
        {
            entity.HasKey(e => e.AdminKey);

            entity.ToTable("TlbOfficeAdmin");

            entity.HasIndex(e => e.UserId, "IX_TlbOfficeAdmin_UserId")
                .IsUnique()
                .HasFilter("([UserId] IS NOT NULL)");

            entity.Property(e => e.SendSmsnewNotification).HasColumnName("SendSMSNewNotification");

            entity.HasOne(d => d.User).WithOne(p => p.TlbOfficeAdmin).HasForeignKey<TlbOfficeAdmin>(d => d.UserId);
        });

        modelBuilder.Entity<TlbOfficeBuilding>(entity =>
        {
            entity.ToTable("TlbOfficeBuilding");

            entity.HasIndex(e => e.Plan, "IX_TlbOfficeBuilding_Plan");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.OfficeEname).HasColumnName("OfficeEName");

            entity.HasOne(d => d.PlanNavigation).WithMany(p => p.TlbOfficeBuildings).HasForeignKey(d => d.Plan);
        });

        modelBuilder.Entity<TlbOfficePlan>(entity =>
        {
            entity.Property(e => e.Count).HasColumnName("count");
        });

        modelBuilder.Entity<TlbPatientsFolder>(entity =>
        {
            entity.HasKey(e => e.Folderid);

            entity.HasIndex(e => e.DoctorId, "IX_TlbPatientsFolders_DoctorId");

            entity.Property(e => e.Pmonth).HasColumnName("PMonth");
            entity.Property(e => e.Representative).HasColumnName("representative");

            entity.HasOne(d => d.Doctor).WithMany(p => p.TlbPatientsFolders).HasForeignKey(d => d.DoctorId);

            entity.HasMany(d => d.Diseases).WithMany(p => p.Patients)
                .UsingEntity<Dictionary<string, object>>(
                    "TlbPatientsDisease",
                    r => r.HasOne<TlbSystematicDisease>().WithMany().HasForeignKey("DiseaseId"),
                    l => l.HasOne<TlbPatientsFolder>().WithMany().HasForeignKey("PatientId"),
                    j =>
                    {
                        j.HasKey("PatientId", "DiseaseId");
                        j.ToTable("TlbPatientsDiseases");
                        j.HasIndex(new[] { "DiseaseId" }, "IX_TlbPatientsDiseases_DiseaseId");
                    });
        });

        modelBuilder.Entity<TlbPayment>(entity =>
        {
            entity.HasIndex(e => e.FolderId, "IX_TlbPayments_FolderId");

            entity.HasIndex(e => e.RsvId, "IX_TlbPayments_RsvId");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.Folder).WithMany(p => p.TlbPayments).HasForeignKey(d => d.FolderId);

            entity.HasOne(d => d.Rsv).WithMany(p => p.TlbPayments).HasForeignKey(d => d.RsvId);
        });

        modelBuilder.Entity<TlbReserf>(entity =>
        {
            entity.HasIndex(e => e.PatientId, "IX_TlbReserves_PatientId");

            entity.HasIndex(e => e.PlanId, "IX_TlbReserves_PlanId");

            entity.Property(e => e.Priority).HasColumnName("priority");
            entity.Property(e => e.Smsdoctor).HasColumnName("SMSDoctor");
            entity.Property(e => e.Smspatient).HasColumnName("SMSPatient");

            entity.HasOne(d => d.Patient).WithMany(p => p.TlbReserves).HasForeignKey(d => d.PatientId);

            entity.HasOne(d => d.Plan).WithMany(p => p.TlbReserves).HasForeignKey(d => d.PlanId);
        });

        modelBuilder.Entity<TlbReservedDate>(entity =>
        {
            entity.ToTable("TlbReservedDate");

            entity.HasIndex(e => e.FkTimingId, "IX_TlbReservedDate_Fk_TimingId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FkTimingId).HasColumnName("Fk_TimingId");

            entity.HasOne(d => d.FkTiming).WithMany(p => p.TlbReservedDates).HasForeignKey(d => d.FkTimingId);
        });

        modelBuilder.Entity<TlbSendedMessage>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
        });

        modelBuilder.Entity<TlbService>(entity =>
        {
            entity.HasIndex(e => e.RelDoctorPersonnelCode, "IX_TlbServices_Rel_DoctorPersonnelCode");

            entity.Property(e => e.RelDoctorPersonnelCode).HasColumnName("Rel_DoctorPersonnelCode");

            entity.HasOne(d => d.RelDoctorPersonnelCodeNavigation).WithMany(p => p.TlbServices).HasForeignKey(d => d.RelDoctorPersonnelCode);
        });

        modelBuilder.Entity<TlbStock>(entity =>
        {
            entity.HasIndex(e => e.Groupid, "IX_TlbStocks_Groupid");

            entity.HasIndex(e => e.WarehouseId, "IX_TlbStocks_WarehouseId");

            entity.HasOne(d => d.Group).WithMany(p => p.TlbStocks).HasForeignKey(d => d.Groupid);

            entity.HasOne(d => d.Warehouse).WithMany(p => p.TlbStocks)
                .HasForeignKey(d => d.WarehouseId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<TlbStockGroup>(entity =>
        {
            entity.ToTable("TlbStockGroup");
        });

        modelBuilder.Entity<TlbTeethLab>(entity =>
        {
            entity.ToTable("TlbTeethLab");

            entity.HasIndex(e => e.ServiceKey, "IX_TlbTeethLab_serviceKey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ServiceKey).HasColumnName("serviceKey");
            entity.Property(e => e.TeethKey).HasColumnName("teethKey");

            entity.HasOne(d => d.ServiceKeyNavigation).WithMany(p => p.TlbTeethLabs).HasForeignKey(d => d.ServiceKey);
        });

        modelBuilder.Entity<TlbTiming>(entity =>
        {
            entity.HasIndex(e => e.TimeSchTblId, "IX_TlbTimings_TimeSchTblId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.TimeSchTbl).WithMany(p => p.TlbTimings).HasForeignKey(d => d.TimeSchTblId);
        });

        modelBuilder.Entity<TlbTransaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId);

            entity.ToTable("TlbTransaction");

            entity.HasIndex(e => e.FundId, "IX_TlbTransaction_FundId");

            entity.Property(e => e.AccountDetailCode).HasMaxLength(6);

            entity.HasOne(d => d.Fund).WithMany(p => p.TlbTransactions).HasForeignKey(d => d.FundId);
        });

        modelBuilder.Entity<TlbTreatmentDrug>(entity =>
        {
            entity.ToTable("TlbTreatment_Drugs");

            entity.HasIndex(e => e.DrugId, "IX_TlbTreatment_Drugs_DrugId");

            entity.HasIndex(e => e.FolderId, "IX_TlbTreatment_Drugs_FolderId");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.Drug).WithMany(p => p.TlbTreatmentDrugs).HasForeignKey(d => d.DrugId);

            entity.HasOne(d => d.Folder).WithMany(p => p.TlbTreatmentDrugs).HasForeignKey(d => d.FolderId);
        });

        modelBuilder.Entity<TlbTreatmentItem>(entity =>
        {
            entity.ToTable("TlbTreatment_Items");

            entity.HasIndex(e => e.TServiceId, "IX_TlbTreatment_Items_tServiceId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.TServiceId).HasColumnName("tServiceId");

            entity.HasOne(d => d.TService).WithMany(p => p.TlbTreatmentItems).HasForeignKey(d => d.TServiceId);
        });

        modelBuilder.Entity<TlbTreatmentPlan>(entity =>
        {
            entity.ToTable("TlbTreatmentPlan");

            entity.HasIndex(e => e.FolderId, "IX_TlbTreatmentPlan_FolderId");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.Folder).WithMany(p => p.TlbTreatmentPlans).HasForeignKey(d => d.FolderId);
        });

        modelBuilder.Entity<TlbTreatmentService>(entity =>
        {
            entity.HasKey(e => e.TServiceId);

            entity.ToTable("TlbTreatment_Services");

            entity.HasIndex(e => e.ServicesId, "IX_TlbTreatment_Services_ServicesId");

            entity.HasIndex(e => e.TreatmentId, "IX_TlbTreatment_Services_TreatmentId");

            entity.Property(e => e.TServiceId).HasColumnName("tServiceId");

            entity.HasOne(d => d.Services).WithMany(p => p.TlbTreatmentServices).HasForeignKey(d => d.ServicesId);

            entity.HasOne(d => d.Treatment).WithMany(p => p.TlbTreatmentServices).HasForeignKey(d => d.TreatmentId);
        });

        modelBuilder.Entity<TlbVTreatmentItem>(entity =>
        {
            entity.ToTable("Tlb_V_Treatment_Items");

            entity.HasIndex(e => e.VTreatServiceId, "IX_Tlb_V_Treatment_Items_V_Treat_Service_Id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.VTreatServiceId).HasColumnName("V_Treat_Service_Id");

            entity.HasOne(d => d.VTreatService).WithMany(p => p.TlbVTreatmentItems).HasForeignKey(d => d.VTreatServiceId);
        });

        modelBuilder.Entity<TlbVTreatmentService>(entity =>
        {
            entity.ToTable("Tlb_V_Treatment_Services");

            entity.HasIndex(e => e.ReserveId, "IX_Tlb_V_Treatment_Services_ReserveId");

            entity.HasIndex(e => e.ServicesId, "IX_Tlb_V_Treatment_Services_ServicesId");

            entity.HasOne(d => d.Reserve).WithMany(p => p.TlbVTreatmentServices).HasForeignKey(d => d.ReserveId);

            entity.HasOne(d => d.Services).WithMany(p => p.TlbVTreatmentServices).HasForeignKey(d => d.ServicesId);
        });

        modelBuilder.Entity<TlbWarehouse>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
        });

        modelBuilder.Entity<Tlblaboratory>(entity =>
        {
            entity.ToTable("Tlblaboratory");

            entity.HasIndex(e => e.LabTypeid, "IX_Tlblaboratory_LabTypeid");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.LabType).WithMany(p => p.Tlblaboratories).HasForeignKey(d => d.LabTypeid);
        });

        modelBuilder.Entity<TlbposDevice>(entity =>
        {
            entity.HasKey(e => e.PosDeviceId);

            entity.ToTable("Tlbpos_Devices");

            entity.HasIndex(e => e.FundId, "IX_Tlbpos_Devices_FundId");

            entity.HasIndex(e => e.BankId, "IX_Tlbpos_Devices_bankId");

            entity.Property(e => e.AccountDetailCode).HasMaxLength(6);
            entity.Property(e => e.BankId).HasColumnName("bankId");
            entity.Property(e => e.Color)
                .HasMaxLength(6)
                .HasColumnName("color");
            entity.Property(e => e.MerchantName).HasMaxLength(100);
            entity.Property(e => e.TerminalId)
                .HasMaxLength(50)
                .HasColumnName("terminalId");
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.Bank).WithMany(p => p.TlbposDevices)
                .HasForeignKey(d => d.BankId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Fund).WithMany(p => p.TlbposDevices)
                .HasForeignKey(d => d.FundId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
