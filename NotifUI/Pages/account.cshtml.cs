using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Notiflib;
namespace NotifUI.Pages
{
    public class accountModel : PageModel
    {
        public string message = "";
        public string message1 = "";
		public string message2 = "";
		public Notiflib.AppContext context = new Notiflib.AppContext();
        public User user;
		public List<String> userResurses = new List<String>();
		public List<Event> events = new List<Event>();
		public List<Event> events_entered = new List<Event>();
		[BindProperty]
		public string href { get; set; }
        [BindProperty]
		public string res_type { get; set; }
		[BindProperty]
		public bool isShownRes { get; set; } = false;
		[BindProperty]
		public UserData userData { get; set; } = new UserData("", "", "", "", "");
		[BindProperty]
		public EventData eventData { get; set; } = new EventData(
			new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), 
			new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), 
			"", "", "", "", 1);
		
        public void OnGet()
        {
			Update();
        }
        public void OnPostRes()
        {
			Update();
			Resourse res = context.resourses.FirstOrDefault(r => r.name == res_type);
			if(user != null && href != null && res != null)
			{
				UserResourse ur = context.userResourses.FirstOrDefault(ur => ur.user == user && ur.resourse == res);
				if(ur == null)
				{
					context.userResourses.AddRange(new UserResourse(user, res, href));
					context.SaveChanges();
					message1 = "Успешно сохранён ресурс";
				}
				else
				{
					ur.link = href;
					context.SaveChanges();
					message1 = "Успешно обновлён ресурс";
				}

			}
			else
			{
				message1 = "Внутренняя ошибка";
			}
			Update();
		}
		public void OnPostDataInput()
		{
			Update();		
			if(user != null)
			{
				user.l_name = userData.F;
				user.f_name = userData.I;
				user.patronimic = userData.O;
				user.number = userData.number;
				user.email = userData.email;
				context.SaveChanges();
			}
			Update();
		}
		public void OnPostEvent()
		{
			Update();
			Privacy privacy = context.privacies.FirstOrDefault(p => p.id == eventData.privacy);
			if(user != null && privacy != null)
			{
				if(eventData.start < eventData.end)
				{
					Event ewent = new Event(eventData.start, eventData.end, eventData.type, user, privacy
					, eventData.discription, eventData.place);
					ewent.title = eventData.title;
					context.events.Add(ewent );
					Participant participant = new Participant(ewent, user, "Владелец");
					context.participants.Add(participant);
					context.SaveChanges();
				}
				else
				{
					message2 = "Начало должно быть раньше конца";
				}
			}
			Update();
		}
		private void Update()
        {
			if (PageContext.HttpContext.Request.Cookies.ContainsKey("id"))
			{
				user = context.users.FirstOrDefault(u => u.id.ToString() == PageContext.HttpContext.Request.Cookies["id"]);
				if (user != null)
				{
					message = $"{user.l_name} {user.f_name} {user.patronimic} <BR>{user.email} {user.number}";
					userResurses = (from u in context.users
									join ur in context.userResourses on u.id equals ur.user.id
									join res in context.resourses on ur.resourse.id equals res.id
									where u.id == user.id
									select $"{ur.link} ({res.name})").ToList();
					events = (from e in context.events
							  where e.creator.id == user.id select e).ToList();
					events_entered = (from p in context.participants
									  join e in context.events on p.ewent.id equals e.id
									  join u in context.users on p.user.id equals u.id
									  where u.id == user.id && e.creator.id != 
									  user.id
									  select e).ToList();
				}
				else
				{
					RedirectToPage("login");
				}
			}
			else
			{
				RedirectToPage("login");
			}
		}
		public record class UserData(string F, string I, string O, string email, string number);
		public record class EventData(DateTime start, DateTime end, string type, string title, string discription
			 ,string place, int privacy);
    }
}
