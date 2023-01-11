using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Features;
using Notiflib;
using System.Text.RegularExpressions;

namespace NotifUI.Pages
{
    public class registrModel : PageModel
    {
        [BindProperty]
        public Person person { get; set; } = new Person("", "", "", "", "", "");
        public Regex phone = new Regex("^\\d{11,13}$");
        public Regex emailr = new Regex("^.+@.+$");
        public Notiflib.AppContext context = new Notiflib.AppContext();
        
        public string message = "Запрос не получен";
        public void OnGet()
        {
            
        }
        public IActionResult OnPost()
        {
			Role role = context.roles.ToList().Last();
            if(context.users.Where(u => u.email == person.email).ToList().Count > 0)
            {
                message = "email уже занят";
                return null;
            }
			Notiflib.User user = new Notiflib.User(person.l_name, person.f_name, person.number, person.email, role, Feature.Hash(person.password), person.patronimic);
			context.Add(user);
			context.SaveChanges();
			return RedirectToPage("/account");
        }
        public record class Person
        (
			string l_name,
			string f_name,
		    string patronimic,
			string number,
			string email,
			string password
		);
    }
}
