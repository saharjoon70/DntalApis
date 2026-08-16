using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    FaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DashboardSummery",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    TodayIncome = table.Column<decimal>(type: "decimal(19,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardSummery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayrollItemType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeduction = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollItemType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReminderNotification",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    discripton = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    time = table.Column<TimeOnly>(type: "time", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReminderNotification", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TlbAccount_General_Chart",
                columns: table => new
                {
                    AccountCode = table.Column<string>(type: "char(6)", unicode: false, fixedLength: true, maxLength: 6, nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountType = table.Column<int>(type: "int", nullable: false),
                    HeadAccountCode = table.Column<string>(type: "char(6)", unicode: false, fixedLength: true, maxLength: 6, nullable: true),
                    RootHeadCode = table.Column<string>(type: "char(6)", unicode: false, fixedLength: true, maxLength: 6, nullable: true),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbAccount_General_Chart", x => x.AccountCode);
                });

            migrationBuilder.CreateTable(
                name: "TlbBank",
                columns: table => new
                {
                    BankId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbBank", x => x.BankId);
                });

            migrationBuilder.CreateTable(
                name: "TlbConsentService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeService = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbConsentService", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TlbCosts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaidCost = table.Column<double>(type: "float", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbCosts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TlbDBBackup",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PathDownload = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Method = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbDBBackup", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TlbDBPatternMessage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PtrCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbDBPatternMessage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TlbDrugs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScientificName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupDrug = table.Column<short>(type: "smallint", nullable: false),
                    Usepregnancy = table.Column<bool>(type: "bit", nullable: false),
                    Sideeffects = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Shape = table.Column<short>(type: "smallint", nullable: false),
                    ConsumeMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicalInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contraindications = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Drugdose = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbDrugs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TlbEmployee",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaryBase = table.Column<double>(type: "float", nullable: false),
                    SalaryHourly = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbEmployee", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TlbInsuranceType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbInsuranceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TlbLabService",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceLab = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbLabService", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TlbLabType",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbLabType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TlbOfficePlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    count = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ActiveDate = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbOfficePlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TlbSendedMessages",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    SendDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbSendedMessages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TlbStockGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizeGroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbStockGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TlbSystematicDiseases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Considerations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbSystematicDiseases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TlbWarehouses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisterDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbWarehouses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PayrollSetting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemTypeId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayrollSetting_PayrollItemType_ItemTypeId",
                        column: x => x.ItemTypeId,
                        principalTable: "PayrollItemType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TlbCostPaysDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CostR_id_forignKey = table.Column<int>(type: "int", nullable: false),
                    MethodPayment = table.Column<short>(type: "smallint", nullable: false),
                    AmountPayment = table.Column<double>(type: "float", nullable: false),
                    PayDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbCostPaysDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_TlbCostPaysDetails_TlbCosts_CostR_id_forignKey",
                        column: x => x.CostR_id_forignKey,
                        principalTable: "TlbCosts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TlbEmployeeCosts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CostId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsuranceAmount = table.Column<double>(type: "float", nullable: false),
                    EmployerId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbEmployeeCosts", x => x.id);
                    table.ForeignKey(
                        name: "FK_TlbEmployeeCosts_TlbCosts_CostId",
                        column: x => x.CostId,
                        principalTable: "TlbCosts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TlbEmployeeCosts_TlbEmployee_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "TlbEmployee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TlbInsurences",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PreferentialCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contribution = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    CreditLimit = table.Column<double>(type: "float", nullable: false),
                    RegisterTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbInsurences", x => x.id);
                    table.ForeignKey(
                        name: "FK_TlbInsurences_TlbInsuranceType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "TlbInsuranceType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tlblaboratory",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LabTypeid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tlblaboratory", x => x.id);
                    table.ForeignKey(
                        name: "FK_Tlblaboratory_TlbLabType_LabTypeid",
                        column: x => x.LabTypeid,
                        principalTable: "TlbLabType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TlbOfficeBuilding",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficeEName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficeAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficeLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ManagerSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Plan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbOfficeBuilding", x => x.id);
                    table.ForeignKey(
                        name: "FK_TlbOfficeBuilding_TlbOfficePlans_Plan",
                        column: x => x.Plan,
                        principalTable: "TlbOfficePlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TlbStocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Groupid = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Storage = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxInventory = table.Column<int>(type: "int", nullable: false),
                    MinInventory = table.Column<int>(type: "int", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    ExpiresionsDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductionsDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistersDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbStocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TlbStocks_TlbStockGroup_Groupid",
                        column: x => x.Groupid,
                        principalTable: "TlbStockGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TlbStocks_TlbWarehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "TlbWarehouses",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LatestActivity = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PasswordChangeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    EmpIdCode = table.Column<long>(type: "bigint", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CodeMelli = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoUploadDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VerifiedPhone = table.Column<bool>(type: "bit", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    AddressHome = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SendSMS = table.Column<bool>(type: "bit", nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: true),
                    reagent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Background = table.Column<byte>(type: "tinyint", nullable: true),
                    University = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_TlbOfficeBuilding_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "TlbOfficeBuilding",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "TlbMain_Cash",
                columns: table => new
                {
                    FundId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FundName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FundType = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SetDefault = table.Column<bool>(type: "bit", nullable: true),
                    AccountDetailCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    OfficeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbMain_Cash", x => x.FundId);
                    table.ForeignKey(
                        name: "FK_TlbMain_Cash_TlbOfficeBuilding_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "TlbOfficeBuilding",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "TlbArrivalGoods",
                columns: table => new
                {
                    RecieptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DelivererPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransfereePerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    stockId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbArrivalGoods", x => x.RecieptId);
                    table.ForeignKey(
                        name: "FK_TlbArrivalGoods_TlbStocks_stockId",
                        column: x => x.stockId,
                        principalTable: "TlbStocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplicationRoleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_ApplicationRoleId",
                        column: x => x.ApplicationRoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankAccount_staff",
                columns: table => new
                {
                    BankAccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IBAN = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CardNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    AccountDetailCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BankId = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccount_staff", x => x.BankAccountId);
                    table.ForeignKey(
                        name: "FK_BankAccount_staff_AspNetUsers_StaffId",
                        column: x => x.StaffId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BankAccount_staff_TlbBank_BankId",
                        column: x => x.BankId,
                        principalTable: "TlbBank",
                        principalColumn: "BankId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payroll",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PayrollDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    TotalEarnings = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalDeductions = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WorkingDays = table.Column<int>(type: "int", nullable: false),
                    AbsentDays = table.Column<int>(type: "int", nullable: false),
                    OverTimeHours = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HolidayHours = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    state = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payroll", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payroll_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TlbContract",
                columns: table => new
                {
                    ContractId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BaseSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PayType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HourlyRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PercentRate = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Hours = table.Column<int>(type: "int", nullable: true),
                    LeaveDays = table.Column<short>(type: "smallint", nullable: false),
                    ContractDuration = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TerminationText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfidentialityText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisputeText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LetterNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeSignature = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbContract", x => x.ContractId);
                    table.ForeignKey(
                        name: "FK_TlbContract_AspNetUsers_PersonId",
                        column: x => x.PersonId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TlbDoctors",
                columns: table => new
                {
                    PersonnelCode = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountDetailCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Expertise = table.Column<short>(type: "smallint", nullable: false),
                    TimeScheduleId = table.Column<int>(type: "int", nullable: false),
                    LicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TlbOfficeid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbDoctors", x => x.PersonnelCode);
                    table.ForeignKey(
                        name: "FK_TlbDoctors_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TlbDoctors_TlbOfficeBuilding_TlbOfficeid",
                        column: x => x.TlbOfficeid,
                        principalTable: "TlbOfficeBuilding",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "TlbLeaves",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    output = table.Column<TimeOnly>(type: "time", nullable: false),
                    input = table.Column<TimeOnly>(type: "time", nullable: false),
                    LeaveDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbLeaves", x => x.id);
                    table.ForeignKey(
                        name: "FK_TlbLeaves_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TlbLoginLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsSuccess = table.Column<bool>(type: "bit", nullable: false),
                    FailReason = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbLoginLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TlbLoginLogs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TlbOfficeAdmin",
                columns: table => new
                {
                    AdminKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SendSMSNewNotification = table.Column<bool>(type: "bit", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbOfficeAdmin", x => x.AdminKey);
                    table.ForeignKey(
                        name: "FK_TlbOfficeAdmin_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TlbRefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Token = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ReplacedByToken = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    RememberMe = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbRefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TlbRefreshTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TlbBankAccount",
                columns: table => new
                {
                    BankAccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Owenr = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IBAN = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CardNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ExpirationDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountDetailCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankId = table.Column<int>(type: "int", nullable: false),
                    FundId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbBankAccount", x => x.BankAccountId);
                    table.ForeignKey(
                        name: "FK_TlbBankAccount_TlbBank_BankId",
                        column: x => x.BankId,
                        principalTable: "TlbBank",
                        principalColumn: "BankId");
                    table.ForeignKey(
                        name: "FK_TlbBankAccount_TlbMain_Cash_FundId",
                        column: x => x.FundId,
                        principalTable: "TlbMain_Cash",
                        principalColumn: "FundId");
                });

            migrationBuilder.CreateTable(
                name: "Tlbpos_Devices",
                columns: table => new
                {
                    PosDeviceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    terminalId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MerchantName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MerchantId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountDetailCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    color = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    bankId = table.Column<int>(type: "int", nullable: false),
                    FundId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tlbpos_Devices", x => x.PosDeviceId);
                    table.ForeignKey(
                        name: "FK_Tlbpos_Devices_TlbBank_bankId",
                        column: x => x.bankId,
                        principalTable: "TlbBank",
                        principalColumn: "BankId");
                    table.ForeignKey(
                        name: "FK_Tlbpos_Devices_TlbMain_Cash_FundId",
                        column: x => x.FundId,
                        principalTable: "TlbMain_Cash",
                        principalColumn: "FundId");
                });

            migrationBuilder.CreateTable(
                name: "TlbTransaction",
                columns: table => new
                {
                    TransactionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackingCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayAmount = table.Column<double>(type: "float", nullable: false),
                    TitlePay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FundId = table.Column<int>(type: "int", nullable: false),
                    AccountDetailCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbTransaction", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_TlbTransaction_TlbMain_Cash_FundId",
                        column: x => x.FundId,
                        principalTable: "TlbMain_Cash",
                        principalColumn: "FundId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PayrollItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayrollId = table.Column<int>(type: "int", nullable: false),
                    ItemTypeId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PayrollId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayrollItem_PayrollItemType_ItemTypeId",
                        column: x => x.ItemTypeId,
                        principalTable: "PayrollItemType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PayrollItem_Payroll_PayrollId1",
                        column: x => x.PayrollId1,
                        principalTable: "Payroll",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employee_Benefits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    contractId = table.Column<int>(type: "int", nullable: false),
                    PayrollItemTypeId = table.Column<int>(type: "int", nullable: false),
                    CustomAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_Benefits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Benefits_PayrollItemType_PayrollItemTypeId",
                        column: x => x.PayrollItemTypeId,
                        principalTable: "PayrollItemType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Benefits_TlbContract_contractId",
                        column: x => x.contractId,
                        principalTable: "TlbContract",
                        principalColumn: "ContractId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TlbDoctorTimeSchedule",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    doctorId = table.Column<long>(type: "bigint", nullable: false),
                    Day = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbDoctorTimeSchedule", x => x.id);
                    table.ForeignKey(
                        name: "FK_TlbDoctorTimeSchedule_TlbDoctors_doctorId",
                        column: x => x.doctorId,
                        principalTable: "TlbDoctors",
                        principalColumn: "PersonnelCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TlbFactorsCosts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<short>(type: "smallint", nullable: false),
                    FactorId = table.Column<int>(type: "int", nullable: false),
                    CostId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SumCost = table.Column<double>(type: "float", nullable: false),
                    receiver = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    doctorId = table.Column<long>(type: "bigint", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbFactorsCosts", x => x.id);
                    table.ForeignKey(
                        name: "FK_TlbFactorsCosts_TlbCosts_CostId",
                        column: x => x.CostId,
                        principalTable: "TlbCosts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TlbFactorsCosts_TlbDoctors_doctorId",
                        column: x => x.doctorId,
                        principalTable: "TlbDoctors",
                        principalColumn: "PersonnelCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TlbPatientsFolders",
                columns: table => new
                {
                    Folderid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Family = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressHome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorId = table.Column<long>(type: "bigint", nullable: false),
                    EducationId = table.Column<short>(type: "smallint", nullable: false),
                    Job = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Married = table.Column<bool>(type: "bit", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HabitsDiscription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Badhabits = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicalHistory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrugHistory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsumeDrug = table.Column<bool>(type: "bit", nullable: false),
                    Insurance = table.Column<bool>(type: "bit", nullable: false),
                    ActiveInsurance = table.Column<bool>(type: "bit", nullable: false),
                    representative = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsuranceNumber = table.Column<int>(type: "int", nullable: false),
                    InsuranceAmount = table.Column<double>(type: "float", nullable: false),
                    Insurer = table.Column<int>(type: "int", nullable: false),
                    Pregnant = table.Column<bool>(type: "bit", nullable: false),
                    PMonth = table.Column<short>(type: "smallint", nullable: false),
                    FromInsuranceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToInsuranceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BirthDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FingerPrintUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbPatientsFolders", x => x.Folderid);
                    table.ForeignKey(
                        name: "FK_TlbPatientsFolders_TlbDoctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "TlbDoctors",
                        principalColumn: "PersonnelCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TlbServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<long>(type: "bigint", nullable: false),
                    Group = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostServices = table.Column<double>(type: "float", nullable: false),
                    Rel_DoctorPersonnelCode = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TlbServices_TlbDoctors_Rel_DoctorPersonnelCode",
                        column: x => x.Rel_DoctorPersonnelCode,
                        principalTable: "TlbDoctors",
                        principalColumn: "PersonnelCode");
                });

            migrationBuilder.CreateTable(
                name: "Salary_Payments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayrollId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salary_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Salary_Payments_Payroll_PayrollId",
                        column: x => x.PayrollId,
                        principalTable: "Payroll",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Salary_Payments_TlbTransaction_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "TlbTransaction",
                        principalColumn: "TransactionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TlbTimings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    TimeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeSchTblId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    EndTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    Slot = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbTimings", x => x.id);
                    table.ForeignKey(
                        name: "FK_TlbTimings_TlbDoctorTimeSchedule_TimeSchTblId",
                        column: x => x.TimeSchTblId,
                        principalTable: "TlbDoctorTimeSchedule",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TlbCzechBooks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IssuerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FolderId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecieveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Bank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Branch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SerialNumber = table.Column<long>(type: "bigint", nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbCzechBooks", x => x.id);
                    table.ForeignKey(
                        name: "FK_TlbCzechBooks_TlbPatientsFolders_FolderId",
                        column: x => x.FolderId,
                        principalTable: "TlbPatientsFolders",
                        principalColumn: "Folderid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TlbExitGoods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DelivererPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransfereePerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExitTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    stockId = table.Column<int>(type: "int", nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: false),
                    PatientsFolderFolderid = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbExitGoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TlbExitGoods_TlbPatientsFolders_PatientsFolderFolderid",
                        column: x => x.PatientsFolderFolderid,
                        principalTable: "TlbPatientsFolders",
                        principalColumn: "Folderid");
                    table.ForeignKey(
                        name: "FK_TlbExitGoods_TlbStocks_stockId",
                        column: x => x.stockId,
                        principalTable: "TlbStocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TlbFolderDocsAttachments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FolderId = table.Column<long>(type: "bigint", nullable: false),
                    DocName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocDiscription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbFolderDocsAttachments", x => x.id);
                    table.ForeignKey(
                        name: "FK_TlbFolderDocsAttachments_TlbPatientsFolders_FolderId",
                        column: x => x.FolderId,
                        principalTable: "TlbPatientsFolders",
                        principalColumn: "Folderid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TlbLabOrders",
                columns: table => new
                {
                    OrderId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocttorId = table.Column<long>(type: "bigint", nullable: false),
                    Patientd = table.Column<long>(type: "bigint", nullable: false),
                    LabId = table.Column<int>(type: "int", nullable: false),
                    WorkType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReadyDays = table.Column<short>(type: "smallint", nullable: false),
                    Color = table.Column<short>(type: "smallint", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CostOffice = table.Column<double>(type: "float", nullable: false),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cancel = table.Column<bool>(type: "bit", nullable: false),
                    CostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbLabOrders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_TlbLabOrders_TlbCosts_CostId",
                        column: x => x.CostId,
                        principalTable: "TlbCosts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TlbLabOrders_TlbDoctors_DocttorId",
                        column: x => x.DocttorId,
                        principalTable: "TlbDoctors",
                        principalColumn: "PersonnelCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TlbLabOrders_TlbPatientsFolders_Patientd",
                        column: x => x.Patientd,
                        principalTable: "TlbPatientsFolders",
                        principalColumn: "Folderid");
                    table.ForeignKey(
                        name: "FK_TlbLabOrders_Tlblaboratory_LabId",
                        column: x => x.LabId,
                        principalTable: "Tlblaboratory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TlbPatientsDiseases",
                columns: table => new
                {
                    PatientId = table.Column<long>(type: "bigint", nullable: false),
                    DiseaseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbPatientsDiseases", x => new { x.PatientId, x.DiseaseId });
                    table.ForeignKey(
                        name: "FK_TlbPatientsDiseases_TlbPatientsFolders_PatientId",
                        column: x => x.PatientId,
                        principalTable: "TlbPatientsFolders",
                        principalColumn: "Folderid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TlbPatientsDiseases_TlbSystematicDiseases_DiseaseId",
                        column: x => x.DiseaseId,
                        principalTable: "TlbSystematicDiseases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TlbTreatment_Drugs",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Directions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FolderId = table.Column<long>(type: "bigint", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DrugId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbTreatment_Drugs", x => x.id);
                    table.ForeignKey(
                        name: "FK_TlbTreatment_Drugs_TlbDrugs_DrugId",
                        column: x => x.DrugId,
                        principalTable: "TlbDrugs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TlbTreatment_Drugs_TlbPatientsFolders_FolderId",
                        column: x => x.FolderId,
                        principalTable: "TlbPatientsFolders",
                        principalColumn: "Folderid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TlbTreatmentPlan",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FolderId = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbTreatmentPlan", x => x.id);
                    table.ForeignKey(
                        name: "FK_TlbTreatmentPlan_TlbPatientsFolders_FolderId",
                        column: x => x.FolderId,
                        principalTable: "TlbPatientsFolders",
                        principalColumn: "Folderid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TlbInsurence_Srvice",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceType = table.Column<int>(type: "int", nullable: false),
                    InsuranceId = table.Column<int>(type: "int", nullable: false),
                    DentalServicesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbInsurence_Srvice", x => x.id);
                    table.ForeignKey(
                        name: "FK_TlbInsurence_Srvice_TlbInsurences_InsuranceId",
                        column: x => x.InsuranceId,
                        principalTable: "TlbInsurences",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TlbInsurence_Srvice_TlbServices_DentalServicesId",
                        column: x => x.DentalServicesId,
                        principalTable: "TlbServices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TlbReservedDate",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_TimingId = table.Column<int>(type: "int", nullable: false),
                    ReserveDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbReservedDate", x => x.id);
                    table.ForeignKey(
                        name: "FK_TlbReservedDate_TlbTimings_Fk_TimingId",
                        column: x => x.Fk_TimingId,
                        principalTable: "TlbTimings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TlbLabServiceOrder",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceLabId = table.Column<int>(type: "int", nullable: false),
                    ServiceDiscription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbLabServiceOrder", x => x.id);
                    table.ForeignKey(
                        name: "FK_TlbLabServiceOrder_TlbLabOrders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "TlbLabOrders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TlbLabServiceOrder_TlbLabService_ServiceLabId",
                        column: x => x.ServiceLabId,
                        principalTable: "TlbLabService",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TlbReserves",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanId = table.Column<long>(type: "bigint", nullable: true),
                    priority = table.Column<int>(type: "int", nullable: false),
                    ReserveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CancelDatetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartReserveTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    EndReserveTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    PatientId = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisterStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Consent = table.Column<bool>(type: "bit", nullable: false),
                    TypeConsent = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    CancelReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalCost = table.Column<double>(type: "float", nullable: false),
                    Off = table.Column<double>(type: "float", nullable: false),
                    InsuranceContribution = table.Column<double>(type: "float", nullable: false),
                    PaidAmount = table.Column<double>(type: "float", nullable: false),
                    SMSDoctor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SMSPatient = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbReserves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TlbReserves_TlbPatientsFolders_PatientId",
                        column: x => x.PatientId,
                        principalTable: "TlbPatientsFolders",
                        principalColumn: "Folderid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TlbReserves_TlbTreatmentPlan_PlanId",
                        column: x => x.PlanId,
                        principalTable: "TlbTreatmentPlan",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "TlbTreatment_Services",
                columns: table => new
                {
                    tServiceId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TreatmentId = table.Column<long>(type: "bigint", nullable: false),
                    ServicesId = table.Column<int>(type: "int", nullable: false),
                    AgeGroup = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbTreatment_Services", x => x.tServiceId);
                    table.ForeignKey(
                        name: "FK_TlbTreatment_Services_TlbServices_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "TlbServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TlbTreatment_Services_TlbTreatmentPlan_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "TlbTreatmentPlan",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TlbTeethLab",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    teethKey = table.Column<short>(type: "smallint", nullable: false),
                    serviceKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbTeethLab", x => x.id);
                    table.ForeignKey(
                        name: "FK_TlbTeethLab_TlbLabServiceOrder_serviceKey",
                        column: x => x.serviceKey,
                        principalTable: "TlbLabServiceOrder",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tlb_V_Treatment_Services",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReserveId = table.Column<long>(type: "bigint", nullable: false),
                    ServicesId = table.Column<int>(type: "int", nullable: false),
                    AgeGroup = table.Column<short>(type: "smallint", nullable: false),
                    InsuranceCost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tlb_V_Treatment_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tlb_V_Treatment_Services_TlbReserves_ReserveId",
                        column: x => x.ReserveId,
                        principalTable: "TlbReserves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tlb_V_Treatment_Services_TlbServices_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "TlbServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TlbInsurence_Consume",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReserveCode = table.Column<long>(type: "bigint", nullable: false),
                    AmountComsume = table.Column<double>(type: "float", nullable: false),
                    DateComsume = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClinicName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbInsurence_Consume", x => x.id);
                    table.ForeignKey(
                        name: "FK_TlbInsurence_Consume_TlbReserves_ReserveCode",
                        column: x => x.ReserveCode,
                        principalTable: "TlbReserves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TlbPayments",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Key = table.Column<long>(type: "bigint", nullable: false),
                    RsvId = table.Column<long>(type: "bigint", nullable: true),
                    FolderId = table.Column<long>(type: "bigint", nullable: false),
                    PayAmount = table.Column<double>(type: "float", nullable: false),
                    PayMethod = table.Column<short>(type: "smallint", nullable: false),
                    PayDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TitlePay = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbPayments", x => x.id);
                    table.ForeignKey(
                        name: "FK_TlbPayments_TlbPatientsFolders_FolderId",
                        column: x => x.FolderId,
                        principalTable: "TlbPatientsFolders",
                        principalColumn: "Folderid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TlbPayments_TlbReserves_RsvId",
                        column: x => x.RsvId,
                        principalTable: "TlbReserves",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TlbTreatment_Items",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tServiceId = table.Column<long>(type: "bigint", nullable: false),
                    TeethId = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlbTreatment_Items", x => x.id);
                    table.ForeignKey(
                        name: "FK_TlbTreatment_Items_TlbTreatment_Services_tServiceId",
                        column: x => x.tServiceId,
                        principalTable: "TlbTreatment_Services",
                        principalColumn: "tServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tlb_V_Treatment_Items",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    V_Treat_Service_Id = table.Column<long>(type: "bigint", nullable: false),
                    TeethId = table.Column<short>(type: "smallint", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tlb_V_Treatment_Items", x => x.id);
                    table.ForeignKey(
                        name: "FK_Tlb_V_Treatment_Items_Tlb_V_Treatment_Services_V_Treat_Service_Id",
                        column: x => x.V_Treat_Service_Id,
                        principalTable: "Tlb_V_Treatment_Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_Name",
                table: "AspNetRoles",
                column: "Name",
                unique: true,
                filter: "([Name] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex1",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "([NormalizedName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_ApplicationRoleId",
                table: "AspNetUserRoles",
                column: "ApplicationRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_ApplicationUserId",
                table: "AspNetUserRoles",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_Email",
                table: "AspNetUsers",
                column: "Email",
                unique: true,
                filter: "([Email] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_OfficeId",
                table: "AspNetUsers",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_UserName",
                table: "AspNetUsers",
                column: "UserName",
                unique: true,
                filter: "([UserName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex1",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "([NormalizedUserName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_staff_BankId",
                table: "BankAccount_staff",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_staff_StaffId",
                table: "BankAccount_staff",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Benefits_contractId",
                table: "Employee_Benefits",
                column: "contractId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Benefits_PayrollItemTypeId",
                table: "Employee_Benefits",
                column: "PayrollItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Payroll_EmployeeId",
                table: "Payroll",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollItem_ItemTypeId",
                table: "PayrollItem",
                column: "ItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollItem_PayrollId1",
                table: "PayrollItem",
                column: "PayrollId1");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollSetting_ItemTypeId",
                table: "PayrollSetting",
                column: "ItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Salary_Payments_PayrollId",
                table: "Salary_Payments",
                column: "PayrollId");

            migrationBuilder.CreateIndex(
                name: "IX_Salary_Payments_TransactionId",
                table: "Salary_Payments",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tlb_V_Treatment_Items_V_Treat_Service_Id",
                table: "Tlb_V_Treatment_Items",
                column: "V_Treat_Service_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tlb_V_Treatment_Services_ReserveId",
                table: "Tlb_V_Treatment_Services",
                column: "ReserveId");

            migrationBuilder.CreateIndex(
                name: "IX_Tlb_V_Treatment_Services_ServicesId",
                table: "Tlb_V_Treatment_Services",
                column: "ServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_TlbArrivalGoods_stockId",
                table: "TlbArrivalGoods",
                column: "stockId");

            migrationBuilder.CreateIndex(
                name: "IX_TlbBankAccount_BankId",
                table: "TlbBankAccount",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_TlbBankAccount_FundId",
                table: "TlbBankAccount",
                column: "FundId");

            migrationBuilder.CreateIndex(
                name: "IX_TlbContract_PersonId",
                table: "TlbContract",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_TlbCostPaysDetails_CostR_id_forignKey",
                table: "TlbCostPaysDetails",
                column: "CostR_id_forignKey");

            migrationBuilder.CreateIndex(
                name: "IX_TlbCzechBooks_FolderId",
                table: "TlbCzechBooks",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_TlbDoctors_TlbOfficeid",
                table: "TlbDoctors",
                column: "TlbOfficeid");

            migrationBuilder.CreateIndex(
                name: "IX_TlbDoctors_UserId",
                table: "TlbDoctors",
                column: "UserId",
                unique: true,
                filter: "([UserId] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_TlbDoctorTimeSchedule_doctorId",
                table: "TlbDoctorTimeSchedule",
                column: "doctorId");

            migrationBuilder.CreateIndex(
                name: "IX_TlbEmployeeCosts_CostId",
                table: "TlbEmployeeCosts",
                column: "CostId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TlbEmployeeCosts_EmployerId",
                table: "TlbEmployeeCosts",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_TlbExitGoods_PatientsFolderFolderid",
                table: "TlbExitGoods",
                column: "PatientsFolderFolderid");

            migrationBuilder.CreateIndex(
                name: "IX_TlbExitGoods_stockId",
                table: "TlbExitGoods",
                column: "stockId");

            migrationBuilder.CreateIndex(
                name: "IX_TlbFactorsCosts_CostId",
                table: "TlbFactorsCosts",
                column: "CostId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TlbFactorsCosts_doctorId",
                table: "TlbFactorsCosts",
                column: "doctorId");

            migrationBuilder.CreateIndex(
                name: "IX_TlbFolderDocsAttachments_FolderId",
                table: "TlbFolderDocsAttachments",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_TlbInsurence_Consume_ReserveCode",
                table: "TlbInsurence_Consume",
                column: "ReserveCode");

            migrationBuilder.CreateIndex(
                name: "IX_TlbInsurence_Srvice_DentalServicesId",
                table: "TlbInsurence_Srvice",
                column: "DentalServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_TlbInsurence_Srvice_InsuranceId",
                table: "TlbInsurence_Srvice",
                column: "InsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_TlbInsurences_TypeId",
                table: "TlbInsurences",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tlblaboratory_LabTypeid",
                table: "Tlblaboratory",
                column: "LabTypeid");

            migrationBuilder.CreateIndex(
                name: "IX_TlbLabOrders_CostId",
                table: "TlbLabOrders",
                column: "CostId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TlbLabOrders_DocttorId",
                table: "TlbLabOrders",
                column: "DocttorId");

            migrationBuilder.CreateIndex(
                name: "IX_TlbLabOrders_LabId",
                table: "TlbLabOrders",
                column: "LabId");

            migrationBuilder.CreateIndex(
                name: "IX_TlbLabOrders_Patientd",
                table: "TlbLabOrders",
                column: "Patientd");

            migrationBuilder.CreateIndex(
                name: "IX_TlbLabServiceOrder_OrderId",
                table: "TlbLabServiceOrder",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_TlbLabServiceOrder_ServiceLabId",
                table: "TlbLabServiceOrder",
                column: "ServiceLabId");

            migrationBuilder.CreateIndex(
                name: "IX_TlbLeaves_UserId",
                table: "TlbLeaves",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TlbLoginLogs_Timestamp",
                table: "TlbLoginLogs",
                column: "Timestamp");

            migrationBuilder.CreateIndex(
                name: "IX_TlbLoginLogs_UserId",
                table: "TlbLoginLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TlbMain_Cash_OfficeId",
                table: "TlbMain_Cash",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_TlbOfficeAdmin_UserId",
                table: "TlbOfficeAdmin",
                column: "UserId",
                unique: true,
                filter: "([UserId] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_TlbOfficeBuilding_Plan",
                table: "TlbOfficeBuilding",
                column: "Plan");

            migrationBuilder.CreateIndex(
                name: "IX_TlbPatientsDiseases_DiseaseId",
                table: "TlbPatientsDiseases",
                column: "DiseaseId");

            migrationBuilder.CreateIndex(
                name: "IX_TlbPatientsFolders_DoctorId",
                table: "TlbPatientsFolders",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_TlbPayments_FolderId",
                table: "TlbPayments",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_TlbPayments_RsvId",
                table: "TlbPayments",
                column: "RsvId");

            migrationBuilder.CreateIndex(
                name: "IX_Tlbpos_Devices_bankId",
                table: "Tlbpos_Devices",
                column: "bankId");

            migrationBuilder.CreateIndex(
                name: "IX_Tlbpos_Devices_FundId",
                table: "Tlbpos_Devices",
                column: "FundId");

            migrationBuilder.CreateIndex(
                name: "IX_TlbRefreshTokens_Token",
                table: "TlbRefreshTokens",
                column: "Token");

            migrationBuilder.CreateIndex(
                name: "IX_TlbRefreshTokens_UserId",
                table: "TlbRefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TlbReservedDate_Fk_TimingId",
                table: "TlbReservedDate",
                column: "Fk_TimingId");

            migrationBuilder.CreateIndex(
                name: "IX_TlbReserves_PatientId",
                table: "TlbReserves",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_TlbReserves_PlanId",
                table: "TlbReserves",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_TlbServices_Rel_DoctorPersonnelCode",
                table: "TlbServices",
                column: "Rel_DoctorPersonnelCode");

            migrationBuilder.CreateIndex(
                name: "IX_TlbStocks_Groupid",
                table: "TlbStocks",
                column: "Groupid");

            migrationBuilder.CreateIndex(
                name: "IX_TlbStocks_WarehouseId",
                table: "TlbStocks",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_TlbTeethLab_serviceKey",
                table: "TlbTeethLab",
                column: "serviceKey");

            migrationBuilder.CreateIndex(
                name: "IX_TlbTimings_TimeSchTblId",
                table: "TlbTimings",
                column: "TimeSchTblId");

            migrationBuilder.CreateIndex(
                name: "IX_TlbTransaction_FundId",
                table: "TlbTransaction",
                column: "FundId");

            migrationBuilder.CreateIndex(
                name: "IX_TlbTreatment_Drugs_DrugId",
                table: "TlbTreatment_Drugs",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_TlbTreatment_Drugs_FolderId",
                table: "TlbTreatment_Drugs",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_TlbTreatment_Items_tServiceId",
                table: "TlbTreatment_Items",
                column: "tServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_TlbTreatment_Services_ServicesId",
                table: "TlbTreatment_Services",
                column: "ServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_TlbTreatment_Services_TreatmentId",
                table: "TlbTreatment_Services",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TlbTreatmentPlan_FolderId",
                table: "TlbTreatmentPlan",
                column: "FolderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BankAccount_staff");

            migrationBuilder.DropTable(
                name: "DashboardSummery");

            migrationBuilder.DropTable(
                name: "Employee_Benefits");

            migrationBuilder.DropTable(
                name: "PayrollItem");

            migrationBuilder.DropTable(
                name: "PayrollSetting");

            migrationBuilder.DropTable(
                name: "ReminderNotification");

            migrationBuilder.DropTable(
                name: "Salary_Payments");

            migrationBuilder.DropTable(
                name: "Tlb_V_Treatment_Items");

            migrationBuilder.DropTable(
                name: "TlbAccount_General_Chart");

            migrationBuilder.DropTable(
                name: "TlbArrivalGoods");

            migrationBuilder.DropTable(
                name: "TlbBankAccount");

            migrationBuilder.DropTable(
                name: "TlbConsentService");

            migrationBuilder.DropTable(
                name: "TlbCostPaysDetails");

            migrationBuilder.DropTable(
                name: "TlbCzechBooks");

            migrationBuilder.DropTable(
                name: "TlbDBBackup");

            migrationBuilder.DropTable(
                name: "TlbDBPatternMessage");

            migrationBuilder.DropTable(
                name: "TlbEmployeeCosts");

            migrationBuilder.DropTable(
                name: "TlbExitGoods");

            migrationBuilder.DropTable(
                name: "TlbFactorsCosts");

            migrationBuilder.DropTable(
                name: "TlbFolderDocsAttachments");

            migrationBuilder.DropTable(
                name: "TlbInsurence_Consume");

            migrationBuilder.DropTable(
                name: "TlbInsurence_Srvice");

            migrationBuilder.DropTable(
                name: "TlbLeaves");

            migrationBuilder.DropTable(
                name: "TlbLoginLogs");

            migrationBuilder.DropTable(
                name: "TlbOfficeAdmin");

            migrationBuilder.DropTable(
                name: "TlbPatientsDiseases");

            migrationBuilder.DropTable(
                name: "TlbPayments");

            migrationBuilder.DropTable(
                name: "Tlbpos_Devices");

            migrationBuilder.DropTable(
                name: "TlbRefreshTokens");

            migrationBuilder.DropTable(
                name: "TlbReservedDate");

            migrationBuilder.DropTable(
                name: "TlbSendedMessages");

            migrationBuilder.DropTable(
                name: "TlbTeethLab");

            migrationBuilder.DropTable(
                name: "TlbTreatment_Drugs");

            migrationBuilder.DropTable(
                name: "TlbTreatment_Items");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "TlbContract");

            migrationBuilder.DropTable(
                name: "PayrollItemType");

            migrationBuilder.DropTable(
                name: "Payroll");

            migrationBuilder.DropTable(
                name: "TlbTransaction");

            migrationBuilder.DropTable(
                name: "Tlb_V_Treatment_Services");

            migrationBuilder.DropTable(
                name: "TlbEmployee");

            migrationBuilder.DropTable(
                name: "TlbStocks");

            migrationBuilder.DropTable(
                name: "TlbInsurences");

            migrationBuilder.DropTable(
                name: "TlbSystematicDiseases");

            migrationBuilder.DropTable(
                name: "TlbBank");

            migrationBuilder.DropTable(
                name: "TlbTimings");

            migrationBuilder.DropTable(
                name: "TlbLabServiceOrder");

            migrationBuilder.DropTable(
                name: "TlbDrugs");

            migrationBuilder.DropTable(
                name: "TlbTreatment_Services");

            migrationBuilder.DropTable(
                name: "TlbMain_Cash");

            migrationBuilder.DropTable(
                name: "TlbReserves");

            migrationBuilder.DropTable(
                name: "TlbStockGroup");

            migrationBuilder.DropTable(
                name: "TlbWarehouses");

            migrationBuilder.DropTable(
                name: "TlbInsuranceType");

            migrationBuilder.DropTable(
                name: "TlbDoctorTimeSchedule");

            migrationBuilder.DropTable(
                name: "TlbLabOrders");

            migrationBuilder.DropTable(
                name: "TlbLabService");

            migrationBuilder.DropTable(
                name: "TlbServices");

            migrationBuilder.DropTable(
                name: "TlbTreatmentPlan");

            migrationBuilder.DropTable(
                name: "TlbCosts");

            migrationBuilder.DropTable(
                name: "Tlblaboratory");

            migrationBuilder.DropTable(
                name: "TlbPatientsFolders");

            migrationBuilder.DropTable(
                name: "TlbLabType");

            migrationBuilder.DropTable(
                name: "TlbDoctors");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TlbOfficeBuilding");

            migrationBuilder.DropTable(
                name: "TlbOfficePlans");
        }
    }
}
