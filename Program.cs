using Microsoft.EntityFrameworkCore;
using OzzyWeb1.Models;
// Imports de Identity
using Microsoft.AspNetCore.Identity;
using OzzyWeb1.Data;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// 1. MVC + Razor Pages
builder.Services.AddRazorPages();

// 2. Cadena de conexi�n 
var conString = builder.Configuration.GetConnectionString("conexion") ??
    throw new InvalidOperationException("Connection string 'conexion' not found");

// 3. DbContext del CRUD
builder.Services.AddDbContext<SabormasterclassContext>(options =>
    options.UseMySql(conString, ServerVersion.AutoDetect(conString))
);

// 4. DbContext de Identity (NUEVO)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(conString, ServerVersion.AutoDetect(conString)));

// 5. Identity (NUEVO)
builder.Services
    .AddDefaultIdentity<ApplicationUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;

        // Reglas de contrase�a relajadas para desarrollo:
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredLength = 6;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();


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

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
