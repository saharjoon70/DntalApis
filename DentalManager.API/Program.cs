using DentalManager.API.Extensions;
using DentalManager.Domain.Entities;
using DentalManager.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// ========== Database ==========
builder.Services.AddDbContext<DentalContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

// ========== Identity ==========
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Lockout.AllowedForNewUsers = true;
    options.Lockout.MaxFailedAccessAttempts = 10;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
})
.AddEntityFrameworkStores<DentalContext>()
.AddDefaultTokenProviders();

// ========== Services ==========
builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("login", config =>
    {
        config.PermitLimit = 5; // ۵ درخواست
        config.Window = TimeSpan.FromMinutes(1); // در هر ۱ دقیقه
        config.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
    });
});
builder.Services.AddApplicationServices();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerWithJwt();
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddMemoryCache();
// قبل از builder.Services.AddControllers()
// ========== CORS ==========
builder.Services.AddCors(options =>
{
    options.AddPolicy("VueApp", policy =>
    {
        policy.WithOrigins("http://localhost:5173", "http://localhost:5174")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});
// قبل از app.UseAuthentication()

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("VueApp");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();