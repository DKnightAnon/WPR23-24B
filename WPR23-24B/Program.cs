using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WPR23_24B.Controllers;
using WPR23_24B.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<OnderzoekContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("OnderzoekContext") ?? throw new InvalidOperationException("Connection string 'OnderzoekContext' not found.")));
builder.Services.AddDbContext<BeperkingContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("BeperkingContext") ?? throw new InvalidOperationException("Connection string 'BeperkingContext' not found.")));
builder.Services.AddDbContext<HulpmiddelContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("HulpmiddelContext") ?? throw new InvalidOperationException("Connection string 'HulpmiddelContext' not found.")));
builder.Services.AddDbContext<OnderzoekResultaatContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("OnderzoekResultaatContext") ?? throw new InvalidOperationException("Connection string 'OnderzoekResultaatContext' not found.")));
builder.Services.AddDbContext<BedrijfsContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("WPR23_24BContext") ?? throw new InvalidOperationException("Connection string 'WPR23_24BContext' not found.")));

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

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
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
