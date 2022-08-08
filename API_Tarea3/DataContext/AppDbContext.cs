using API_Tarea3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace API_Tarea3.DataContext
{
    public class AppDbContext: DbContext
    {
        /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=JEF\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                //.EnableSensitiveDataLogging(true)
                //.UseLoggerFactory(new LoggerFactory().AddConsole((category, level) => level == LogLevel.Information && DbLoggerCategory == DbLoggerCategory.Database.Command.Name));
        }*/

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Agenda> Agendas { get; set;}
    }
}
