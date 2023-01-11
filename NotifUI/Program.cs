using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages(options => { 
	options.RootDirectory = "/Pages";
	options.Conventions.AuthorizePage("/account");
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
	options.LoginPath = "/login";
});
builder.Services.AddAuthorization();
var app = builder.Build();

app.UseAuthentication();
app.UseStaticFiles();
app.UseAuthorization();
app.MapRazorPages();
app.Run();
