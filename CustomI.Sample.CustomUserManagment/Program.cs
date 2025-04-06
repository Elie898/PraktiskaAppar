using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CustomI.Sample.CustomUserManagment.Data;
using CustomI.Sample.CustomUserManagment.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("CustomISampleCustomUserManagmentContextConnection") ?? throw new InvalidOperationException("Connection string 'CustomISampleCustomUserManagmentContextConnection' not found.");;

builder.Services.AddDbContext<CustomISampleCustomUserManagmentContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<CustomISampleCustomUserManagmentContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();
builder.Services.AddRazorPages();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
