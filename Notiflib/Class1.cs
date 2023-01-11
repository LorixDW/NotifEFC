using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Migrations;
using Features;
namespace Notiflib
{
    public class User
    {
        [Key]
        [Required]
        [Column("user_id")]
        public int id { get; set; }
        [Required]
        public String l_name { get; set; }
        [Required]
        public String f_name { get; set; }
        public String? patronimic { get; set; }
        [Required]
        public String number { get; set; }
        [Required]
        public String email { get; set; }
        [Required]
        [ForeignKey("role_fk")]
        public Role role { get; set; }
        [Required]
        public String Password { get; set; }
        public List<UserResourse> userResourses { get; set; } = new();
        public List<Event> eventsCreated { get; set; } = new();
        public List<Participant> eventPart { get; set; } = new();
        public List<Application> applications { get; set; } = new();
        public User() { }
        public User(String l_name, String f_name, String number, String email, Role role, String password, String patronimic = "")
        {
            this.l_name = l_name;
            this.f_name = f_name;
            this.number = number;
            this.email = email;
            this.role = role;
            this.Password = Feature.Hash(password);
            if (patronimic != "")
            {
                this.patronimic = patronimic;
            }
        }
        public override string ToString()
        {
            return this.role.name;
        }
    }
    public class Event 
    {
        [Key]
        [Required]
        [Column("event_id")]
        public int id { get; set; }
        [Required]
        [Column(TypeName ="timestamp")]
        public DateTime start { get; set; }
        [Required]
        [Column(TypeName = "timestamp")]
        public DateTime end { get; set; }
        [Required]
        public string title { get; set; }
        [Column("event_type")]
        [Required]
        public String type { get; set; }
        public String? discription { get; set; }
        [Required]
        [ForeignKey("creator_fk")]
        public User creator { get; set; }
        public String? place { get; set; }
        [Required]
        [ForeignKey("privacy_fk")]
        public Privacy privacy { get; set; }
        public List<Application> applications { get; set; } = new();
        public List<Participant> participants { get; set; } = new();
        public Event() { }
        public Event(DateTime start, DateTime end, String type, User user, Privacy privacy, String discription = "", String place = "")
        {
            this.start = start;
            this.end = end;
            this.type = type;
            this.creator = user;
            this.privacy = privacy;
            if(discription != "")
            {
                this.discription = discription;
            }
        }
    }
    public class Participant
    {
        [Required]
        [ForeignKey("event_fk")]
        public Event ewent { get; set; }
        [Required]
        [ForeignKey("user_fk")]
        public User user { get; set; }
        [Required]
        public String type { get; set; }
        public List<Notification> notifications { get; set; } = new();
        public Participant() { }
        public Participant(Event ewent, User user, String type)
        {
            this.ewent = ewent;
            this.user = user;
            this.type = type;
        }
    }
    public class Notification
    {
        [Key]
        [Required]
        [Column("notif_id")]
        public int id { get; set; }
        [Required]
        public Participant participant { get; set; }
        public DateOnly date { get; set; }
        public String? discription { get; set; }
        [Required]
        public bool sended { get; set; } = false;
        public Notification() { }
        public Notification(Participant participant, DateOnly date, String discription = "")
        {
            this.participant = participant;
            this.date = date;
            if(discription != "")
            {
                this.discription = discription;
            }
        }
    }
    public class Role 
    {
        [Key]
        [Required]
        [Column("role_id")]
        public int id { get; set; }
        [Required]
        public String name { get; set; } = null!;
        public List<User> users { get; set; } = new();
        public Role() { }
        public Role(String name)
        {
            this.name = name;
        }
    }
    public class Resourse
    {
        [Key]
        [Required]
        [Column("resourse_id")]
        public int id { get; set; }
        [Required]
        public String name { get; set; }
        public List<UserResourse> userResourses { get; set; } = new();
        public Resourse() { }
        public Resourse(String name)
        {
            this.name = name;
        }
    }
    public class UserResourse
    {
        [Required]
        [ForeignKey("user_res_fk")]
        public User user { get; set; }
        [Required]
        [ForeignKey("restype_res_fk")]
        public Resourse resourse { get; set; }
        [Required]
        public String link { get; set; }
        public UserResourse() { }
        public UserResourse(User user, Resourse resourse, String link)
        {
            this.user = user;
            this.resourse = resourse;
            this.link = link;
        }
    }
    public class Privacy
    {
        [Key]
        [Required]
        [Column("privacy_id")]
        public int id { get; set; }
        [Required]
        public String name { get; set; }
        public List<Event> events { get; set; } = new();
        public Privacy() { }
        public Privacy(String name)
        {
            this.name = name;
        }
    }
    public class ApplicationType
    {
        [Key]
        [Required]
        [Column("application_type_id")]
        public int id { get; set; }
        [Required]
        public String name { get; set; }
        public List<Application> applications { get; set; } = new();
        public ApplicationType() { }
        public ApplicationType(String name)
        {
            this.name = name;
        }
    }
    public class Application
    {
        [Key]
        [Required]
        [Column("application_id")]
        public int id { get; set; }
        [Required]
        public bool accepted { get; set; } = false;
        [Required]
        [ForeignKey("usr_app_fk")]
        public User user { get; set; }
        [Required]
        [ForeignKey("event_app_fk")]
        public Event ewent { get; set; }
        [Required]
        [ForeignKey("app_fk")]
        public ApplicationType applicationType { get; set; }
        public Application() { }
        public Application(User user, Event ewent, ApplicationType applicationType)
        {
            this.user = user;
            this.ewent = ewent;
            this.accepted = false;
            this.applicationType = applicationType;
        }
    }
    public class AppContext: DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Event> events { get; set; }
        public DbSet<Participant> participants { get; set; }
        public DbSet<Notification> notifications { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Resourse> resourses { get; set; }
        public DbSet<UserResourse> userResourses { get; set; }
        public DbSet<Privacy> privacies { get; set; }
        public DbSet<Application> applications { get; set; }
        public DbSet<ApplicationType> applicationTypes { get; set; }
        public AppContext() : base() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=notif_efc;User Id=postgres;Password=xcvZ3412;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notification>()
                .HasOne(nameof(Notification.participant))
                .WithMany(nameof(Participant.notifications))
                .HasForeignKey("event_fk", "user_fk");
            modelBuilder.Entity<UserResourse>().HasKey("user_res_fk", "restype_res_fk");
            modelBuilder.Entity<Participant>().HasKey("event_fk", "user_fk");
        }
    }
}