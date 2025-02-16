using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Online_voting.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Online_votingContextConnection") ?? throw new InvalidOperationException("Connection string 'Online_votingContextConnection' not found.");

builder.Services.AddDbContext<Online_votingContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<Online_votingUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<Online_votingContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddApplicationInsightsTelemetry();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
