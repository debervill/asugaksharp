using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace asugaksharp.Model
{
    public class AppDbContext : DbContext
    {
        public DbSet<Diplomnik> Diplomnik { get; set; }
        public DbSet<Docs> Docs { get; set; }
        public DbSet<Gak> Gak { get; set; }
        public DbSet<Kafedra> Kafedra { get; set; }
        public DbSet<Oplata> Oplata { get; set; }
        public DbSet<PeriodZasedania> PeriodZasedania { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Zasedanie> Zasedanie { get; set; }
        public DbSet<NapravleniePodgotovki> NapravleniePodgotovki { get; set; }
        public DbSet<ProfilPodgotovki> ProfilPodgotovki { get; set; }

        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                SQLitePCL.Batteries.Init();

                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true)
                    .Build();

                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlite(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // ваши связи — остаются без изменений
        }
    }
}
