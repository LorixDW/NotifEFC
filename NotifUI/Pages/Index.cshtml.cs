using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Notiflib;
using System.Reflection.Metadata;

namespace NotifUI.Pages
{
    public class IndexModel : PageModel
    {
        
        public void OnGet()
        {
            
        }
		public async void OnGetDeAuf()
		{
			await PageContext.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
		}
	}
}
