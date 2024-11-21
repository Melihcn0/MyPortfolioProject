using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
{
    option.LoginPath = "/Login/Index";
    option.LogoutPath = "/Login/Logout"; // Çýkýþ yap sayfasý
    option.AccessDeniedPath = "/Login/Index";
});

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10); // Session süresi (30 dakika)
    options.Cookie.HttpOnly = true; // Güvenlik için
    options.Cookie.IsEssential = true; // GDPR uyumluluðu
});
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
app.UseSession();
app.UseAuthorization();
app.MapControllerRoute(

    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");


app.Run();