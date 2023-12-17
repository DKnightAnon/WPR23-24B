using WPR23_24B.Chat.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

//Voeg SignalR toe voor chatfunctionaliteit
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseCors(x => 
        x.AllowAnyMethod()
         .AllowAnyHeader()
         .SetIsOriginAllowed(origin=>true)
         .AllowCredentials()
       );

}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

//Map de klas ChatHub naar URI website/chatHub
app.MapHub<ChatHub>("hubs/chatHub");
app.MapHub<OnderzoekHub>("hubs/onderzoek");

app.Run();
