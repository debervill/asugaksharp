using asugaksharp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace asugaksharp.Infrastructure.Persistanse 
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Kafedra> Kafedras { get; set; }
        public DbSet<Diplomnik> Diplomniks { get; set; }
        public DbSet<Docs> Docs { get; set; }
        public DbSet<Gak> Gaks { get; set; }
        public DbSet<NapravleniePodgotovki> NapravleniaPodgotovki { get; set; }
        public DbSet<Oplata> Oplatas { get; set; }
        public DbSet<PeriodZasedania> PeriodZasedanias { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<ProfilPodgotovki> ProfilPodgotovkis { get; set; }
        public DbSet<Zasedanie> Zasedanies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // TODO: Добавить конфигурации
        }
    }
}