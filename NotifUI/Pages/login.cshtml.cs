using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static NotifUI.Pages.registrModel;
using Notiflib;
using Features;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace NotifUI.Pages
{
    public class loginModel : PageModel
    {
        public string message = "";
		[BindProperty]
		public User_p userp { get; set; } = new User_p("", "");
        Notiflib.AppContext context = new Notiflib.AppContext();
        
		public async void OnPost()
        {
            User user = context.users.FirstOrDefault(u => u.email == userp.email && u.Password == Feature.Hash(userp.password));
            if(user != null)
            {
                var claims = new List<Claim>{ new Claim(ClaimTypes.Name, user.id.ToString())};
                ClaimsIdentity identity = new ClaimsIdentity(claims, "Cookies");
                await PageContext.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                RedirectToPage("account");
                PageContext.HttpContext.Response.Cookies.Append("id", user.id.ToString());
            }
            else
            {
                message = $"Неверное имя или пароль";
            }
        }
    }
    public record class User_p(string email, string password);
}
