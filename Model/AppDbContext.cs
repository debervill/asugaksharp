using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace asugaksharp.Model
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        [Required]    
        public DbSet<Diplomnik> Diplomnik { get; set; } 
        public DbSet<Docs> Docs { get; set; }
        public DbSet<Gak> Gak { get; set; }
        public DbSet<Kafedra> Kafedra { get; set; } 
        public DbSet<Oplata> Oplata { get; set; }
        public DbSet<PeriodZasedania> PeriodZasedania { get; set; }
        public DbSet<Person> Person { get; set; }   
        public DbSet<Zasedanie> Zasedanie  { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Diplomnik - Person (many-to-one)
            modelBuilder.Entity<Diplomnik>()
                .HasOne(d => d.Person)
                .WithMany(p => p.Diplomniks)
                .HasForeignKey(d => d.PersonId);

            // Docs - Person (many-to-one)
            modelBuilder.Entity<Docs>()
                .HasOne(d => d.Person)
                .WithMany(p => p.Docs)
                .HasForeignKey(d => d.PersonId);

            // Oplata - Person (many-to-one)
            modelBuilder.Entity<Oplata>()
                .HasOne(o => o.Person)
                .WithMany(p => p.Oplatas)
                .HasForeignKey(o => o.PersonId);

            // Gak - Kafedra (many-to-one)
            modelBuilder.Entity<Gak>()
                .HasOne(g => g.Kafedra)
                .WithMany(k => k.Gaks)
                .HasForeignKey(g => g.KafedraID);

            // Gak - PeriodZasedania (many-to-one)
            modelBuilder.Entity<Gak>()
                .HasOne(g => g.PeriodZasedania)
                .WithMany(pz => pz.Gaks)
                .HasForeignKey(g => g.PeriodZasedaniaId);

            // Gak - Person (many-to-many)
            modelBuilder.Entity<Gak>()
                .HasMany(g => g.Persons)
                .WithMany(); // No explicit navigation on Person

            // Zasedanie - Gak (many-to-one)
            modelBuilder.Entity<Zasedanie>()
                .HasOne(z => z.Gak)
                .WithMany(g => g.Zasedanies)
                .HasForeignKey(z => z.GakID);

            // Zasedanie - Person (many-to-many)
            modelBuilder.Entity<Zasedanie>()
                .HasMany(z => z.Persons)
                .WithMany(p => p.Zasedanies);

            // Пример: Если нужно явно задать join-таблицы:
            // Gak-Person many-to-many join table (если нужен доступ к join-сущности — иначе можно не явно)
            // modelBuilder.Entity<Gak>()
            //     .HasMany(g => g.Persons)
            //     .WithMany()
            //     .UsingEntity(j => j.ToTable("GakPersons"));

            // Zasedanie-Person many-to-many join table
            // modelBuilder.Entity<Zasedanie>()
            //     .HasMany(z => z.Persons)
            //     .WithMany(p => p.Zasedanies)
            //     .UsingEntity(j => j.ToTable("ZasedaniePersons"));

            // Остальные сущности не требуют дополнительной настройки, EF сам их разберёт.
        }


    }
}
