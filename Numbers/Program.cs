using Numbers.Hubs;
using Numbers.Interfaces;
using Numbers.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();
builder.Services.AddScoped<IManagerAPI, ManagerAPI>();
builder.Services.AddScoped<ISignalRManager, SignalRManager>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapHub<NumberGeneratorHub>("/NumberGeneratorHub");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
