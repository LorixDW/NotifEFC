using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Notiflib;

namespace NotifUI.Pages
{
    public class esearchModel : PageModel
    {
        public List<Event> eventsList;
        public Notiflib.AppContext context { get; set; } = new Notiflib.AppContext();
        public void OnGet()
        {
            Update();
        }
        public void Update()
        {
            eventsList = (from e in context.events join p in context.privacies
                          on e.privacy.id equals p.id where p.id != 3 select e).ToList();
        }
    }
}
