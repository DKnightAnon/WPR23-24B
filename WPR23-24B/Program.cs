using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WPR23_24B.Controllers;
using WPR23_24B.Data;
using WPR23_24B.Models.Authenticatie;
using WPR23_24B.Services;






var builder = WebApplication.CreateBuilder(args);


// Services for registration and authentication purposes
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("RegistrationAuthenticationConnection")));
////Add services to the container.
////builder.Services.AddIdentity<Gebruiker, IdentityRole>()
////    .AddEntityFrameworkStores<ApplicationDbContext>()
////    .AddDefaultTokenProviders();
////builder.Services.AddAuthentication();

////builder.Services.AddScoped<RoleManager<IdentityRole>>();
////builder.Services.AddScoped<IRegistrationService, RegistrationService>();
////builder.Services.AddScoped<IAuthService, AuthService>();
////builder.Services.AddScoped<IRolService, RolService>();

builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Initialize roles during application startup
////using (var scope = app.Services.CreateScope())
////{
////    var serviceProvider = scope.ServiceProvider;
////    var rolService = serviceProvider.GetRequiredService<IRolService>();

////    await rolService.InitializeRoles();
////}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
};

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors(builder =>
{
    builder.WithOrigins("https://localhost:44443/") // Verander de URL naar de server URL
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowAnyOrigin();
});

app.UseRouting();

// Enable Authentication
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
