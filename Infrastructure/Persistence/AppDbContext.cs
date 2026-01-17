using asugaksharp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace asugaksharp.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // DbSets для всех сущностей
    public DbSet<Kafedra> Kafedra { get; set; }
    public DbSet<Person> Person { get; set; }
    public DbSet<Diplomnik> Diplomnik { get; set; }
    public DbSet<Gak> Gak { get; set; }
    public DbSet<Zasedanie> Zasedanie { get; set; }
    public DbSet<PeriodZasedania> PeriodZasedania { get; set; }
    public DbSet<NapravleniePodgotovki> NapravleniePodgotovki { get; set; }
    public DbSet<ProfilPodgotovki> ProfilPodgotovki { get; set; }
    public DbSet<Oplata> Oplata { get; set; }
    public DbSet<Docs> Docs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Применяем все конфигурации из сборки
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}