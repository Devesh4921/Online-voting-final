using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Online_voting.Areas.Identity.Data;
using Online_voting.Data;

var builder = WebApplication.CreateBuilder(args);

// Get the connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("Online_votingContextConnection")
                       ?? throw new InvalidOperationException("Connection string 'Online_votingContextConnection' not found.");

// Register the ApplicationDbContext with the connection string
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Register Identity with the custom user class (Online_votingUser)
builder.Services.AddDefaultIdentity<Online_votingUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Add services for MVC and Razor Pages
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); // Required for Identity pages

// Add Application Insights telemetry (optional)
builder.Services.AddApplicationInsightsTelemetry();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // Enable HTTP Strict Transport Security (HSTS) in production
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Enable authentication and authorization
app.UseAuthentication(); // Ensure this is before UseAuthorization
app.UseAuthorization();

// Map default routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Map Razor Pages for Identity
app.MapRazorPages();

app.Run();