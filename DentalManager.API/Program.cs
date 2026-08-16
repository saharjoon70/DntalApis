using DentalManager.API.Extensions;
using DentalManager.Domain.Entities;
using DentalManager.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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

// ========== CORS ==========
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod()
              .SetPreflightMaxAge(TimeSpan.FromHours(24));
    });
});

// ========== Services ==========
builder.Services.AddApplicationServices();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerWithJwt();
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddMemoryCache();

// ========== Pipeline ==========
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ⏱️ زمان‌سنج
app.Use(async (context, next) =>
{
    var sw = Stopwatch.StartNew();
    await next();
    Console.WriteLine($"⏱️ [{context.Request.Method}] {context.Request.Path} → {sw.ElapsedMilliseconds}ms");
});

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();