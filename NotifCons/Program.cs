using Features;
using Notiflib;
Console.WriteLine();
Notiflib.AppContext AC = new Notiflib.AppContext();

Privacy privacy = (from p in AC.privacies join e in AC.events on p.id equals e.privacy.id where e.id == 2 select p).FirstOrDefault();
if(privacy != null)
{
	Console.WriteLine(privacy.name);
}
AC.SaveChanges();