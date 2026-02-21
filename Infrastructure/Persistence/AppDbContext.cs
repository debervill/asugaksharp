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
    public DbSet<Student> Student { get; set; }
    public DbSet<Diplomnik> Diplomnik { get; set; }
    public DbSet<Gak> Gak { get; set; }
    public DbSet<Zasedanie> Zasedanie { get; set; }
    public DbSet<PeriodZasedania> PeriodZasedania { get; set; }
    public DbSet<NapravleniePodgotovki> NapravleniePodgotovki { get; set; }
    public DbSet<ProfilPodgotovki> ProfilPodgotovki { get; set; }
    public DbSet<Oplata> Oplata { get; set; }
    public DbSet<Docs> Docs { get; set; }
    public DbSet<PersonZasedanie> PersonZasedanie { get; set; }
    public DbSet<Normativ> Normativ { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Применяем все конфигурации из сборки
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        // Настройка связей Gak с Person
        modelBuilder.Entity<Gak>()
            .HasOne(g => g.Predsedatel)
            .WithMany()
            .HasForeignKey(g => g.PredsedatelId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Gak>()
            .HasOne(g => g.Sekretar)
            .WithMany()
            .HasForeignKey(g => g.SekretarId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Gak>()
            .HasMany(g => g.Persons)
            .WithMany(p => p.Gaks);

        modelBuilder.Entity<Diplomnik>()
            .HasOne(d => d.Student)
            .WithOne(s => s.Diplomnik)
            .HasForeignKey<Diplomnik>(d => d.StudentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
