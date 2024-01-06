
using WPR23_24B.Chat.Hubs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WPR23_24B.Controllers;
using WPR23_24B.Data;
using WPR23_24B.Models.Authenticatie;
using WPR23_24B.Services;






var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ChatContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ChatContext") ?? throw new InvalidOperationException("Connection string 'ChatContext' not found.")));


// Services for registration and authentication purposes

if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
{
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("AzureDB")
            )
        );
}
else
{
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("SQLSERVER")
            )
        );
}




//SQLite database connection
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("RegistrationAuthenticationConnection")));

//Automatically perform database migration
builder.Services.BuildServiceProvider().GetService<ApplicationDbContext>().Database.Migrate();


//Add services to the container.
builder.Services.AddIdentity<Gebruiker, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddAuthentication();

builder.Services.AddScoped<RoleManager<IdentityRole>>();
builder.Services.AddScoped<IRegistrationService, RegistrationService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IRolService, RolService>();

builder.Services.AddControllersWithViews();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();





//Voeg CORS toe zodat SignalR en andere functionaliteiten goed werken.
var policyName = "ClientPermission";
builder.Services.AddCors(options =>
{
    options.AddPolicy(policyName, policy =>
    {
        policy
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            .WithOrigins( "https://localhost:44443", "https://localhost:7180");
    });
});


//Voeg SignalR toe voor chatfunctionaliteit
builder.Services.AddSignalR();





var app = builder.Build();

//Initialize roles during application startup
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    var rolService = serviceProvider.GetRequiredService<IRolService>();

    await rolService.InitializeRoles();
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();


    

}




app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors(policyName);



app.UseRouting();

// Enable Authentication
app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");



//Map de klas ChatHub naar URI website/chatHub
app.MapHub<ChatHub>("/hubs/chathub");
//app.UseEndpoints(endpoints =>
//    { endpoints.MapHub<ChatHub>("/hubs/chathub"); }
//    );

app.Run();
