using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Notiflib;

namespace NotifUI.Pages
{
    public class eventModel : PageModel
    {
		public Notiflib.AppContext context { get; set; } = new Notiflib.AppContext();
		public string mess { get; set; } = "";
		public Event Curent_event { get; set; }
		public User curent_user { get; set; }
		public User owner { get; set; }
		public Privacy privacy { get; set; }
		public bool isYours { get; set; } = false;
		public List<User> participants { get; set; } = new List<User>();
		public List<User> applications { get; set; } = new List<User>();
		public List<Notification> notifications { get; set; } = new List<Notification>();
		public bool isNotPart { get; set; } = false;
		public bool isNotAppl { get; set; } = false;
		public bool isPart { get; set; } = false;
		[BindProperty]
		public EventData eventData { get; set; } = new EventData(
			new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
			new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
			"", "", "", "", 1);
		[BindProperty]
		public NotifData notifData { get; set; } = new NotifData(new DateTime(
			DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), "");
		public void OnGet(int id)
        {
			Update(id);
		}
		public void OnPostDataInput(int id)
		{
			Update(id);
			Curent_event.start = eventData.start;
			Curent_event.end = eventData.end;
			Curent_event.title = eventData.title;
			Curent_event.type = eventData.type;
			Curent_event.discription = eventData.discription;
			Curent_event.place = eventData.place;
			Update(id);
		}
		public void OnGetParticipant(int id)
		{
			Update(id);
			if(participants.Where(p => p.id == curent_user.id).ToList().Count == 0)
			{
				Participant participant = new Participant(Curent_event, curent_user, "");
				context.participants.Add(participant);
				context.SaveChanges();
			}
			Update(id);isNotPart = false;
		}
		public void OnGetApplication(int id)
		{
			Update(id);
			if(applications.Where(u => u.id == curent_user.id).ToList().Count == 0)
			{
				Application application = new Application(curent_user, Curent_event, context.applicationTypes.Where(a => a.id == 1).First());
				application.accepted = false;
				context.applications.Add(application);
				context.SaveChanges();
			}
			Update(id);isNotAppl = false;
		}
		public void OnGetAcceptAplication(int id, int user)
		{
			Update(id);
			Application application = (from a in context.applications
									   join u in context.users on a.user.id equals u.id
									   join e in context.events on a.ewent.id equals e.id
									   where e.id == Curent_event.id && u.id == user
									   select a).FirstOrDefault();
			if (application != null)
			{
				application.accepted = true;
				context.SaveChanges();
			}
			User user_apl = context.users.FirstOrDefault(us => us.id == user);
			if (participants.Where(p => p.id == user).ToList().Count == 0 && user_apl != null)
			{
				Participant participant = new Participant(Curent_event, user_apl, "");
				context.participants.Add(participant);
				context.SaveChanges();
			}
			Update(id);
		}
		public void OnPostNotifInput(int id)
		{
			Update(id);
			mess = notifData.ToString();
			Participant participant = (from p in context.participants
									   join e in context.events on p.ewent.id equals e.id
									   join u in context.users on p.user.id equals u.id
									   where e.id == Curent_event.id && u.id == curent_user.id
									   select p).FirstOrDefault();
			if (participant != null)
			{
				Notification notification = new Notification(participant, 
					new DateOnly(notifData.date.Year, notifData.date.Month, notifData.date.Day), notifData.discr);
				context.Add(notification);
				context.SaveChanges();
			}
			Update(id);
		}
		public void Update(int id)
		{
			Curent_event = context.events.FirstOrDefault(e => e.id == id);
			curent_user = context.users.FirstOrDefault(u => u.id.ToString() == PageContext.HttpContext.Request.Cookies["id"]);
			owner = (from u in context.users
					 join e in context.events on u.id equals e.creator.id
					 where e.id == Curent_event.id
					 select u).FirstOrDefault();
			privacy = (from p in context.privacies
					   join e in context.events on p.id equals e.privacy.id
					   where e.id == Curent_event.id
					   select p).FirstOrDefault();
			if (Curent_event != null && curent_user != null && owner != null && privacy != null)
			{
				if (curent_user.id == owner.id)
				{
					isYours = true;
				}
				participants = (from p in context.participants
								join e in context.events on p.ewent.id equals e.id
								join u in context.users on p.user.id equals u.id
								where e.id == Curent_event.id
								select u).ToList();
				if(participants.Where(u => u.id == curent_user.id).ToList().Count > 0)
				{
					isPart = true;
				}
				if (participants.Where(u => u.id == curent_user.id).ToList().Count == 0 && !isYours)
				{
					isNotPart = true;
				}
				applications = (from a in context.applications
								join e in context.events on a.ewent.id equals e.id
								join u in context.users on a.user.id equals u.id
								where e.id == Curent_event.id && !a.accepted 
								select u).ToList();
				if(!isYours && applications.Where(u => u.id == curent_user.id).ToList().Count == 0)
				{
					isNotAppl = true;
				}
				notifications = (from p in context.participants
								 join e in context.events on p.ewent.id equals e.id
								 join u in context.users on p.user.id equals u.id
								 join n in context.notifications on
								 new { eid = p.ewent.id, uid = p.user.id } equals new { eid = n.participant.ewent.id, uid = n.participant.user.id }
								 where e.id == Curent_event.id && u.id == curent_user.id
								 select n).ToList();
			}
			else { RedirectToPage("account"); }
		}
		public record class EventData(DateTime start, DateTime end, string type, string title, string discription
			 , string place, int privacy);
		public record class NotifData(DateTime date, string discr);
	}
}
