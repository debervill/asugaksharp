using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;

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
        public DbSet<Zasedanie> Zasedanie  { get; set; }
        public DbSet<NapravleniePodgotovki> NapravleniePodgotovki { get; set; }
        public DbSet<ProfilPodgotovki> ProfilPodgotovki { get; set; }
        







        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Diplomnik - Person (many-to-one)
            modelBuilder.Entity<Diplomnik>()
                .HasOne(d => d.Person)
                .WithMany(p => p.Diplomniks)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            // Docs - Person (many-to-one)
            modelBuilder.Entity<Docs>()
                .HasOne(d => d.Person)
                .WithMany(p => p.Docs)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            // Oplata - Person (many-to-one)
            modelBuilder.Entity<Oplata>()
                .HasOne(o => o.Person)
                .WithMany(p => p.Oplatas)
                .HasForeignKey(o => o.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            // Gak - Kafedra (many-to-one)
            modelBuilder.Entity<Gak>()
                .HasOne(g => g.Kafedra)
                .WithMany(k => k.Gaks)
                .HasForeignKey(g => g.KafedraID)
                .OnDelete(DeleteBehavior.Restrict);

            // Gak - PeriodZasedania (many-to-one)
            modelBuilder.Entity<Gak>()
                .HasOne(g => g.PeriodZasedania)
                .WithMany(pz => pz.Gaks)
                .HasForeignKey(g => g.PeriodZasedaniaId)
                .OnDelete(DeleteBehavior.Restrict);

            // Gak - Person (many-to-many)
            modelBuilder.Entity<Gak>()
                .HasMany(g => g.Persons)
                .WithMany(p => p.Gaks);

            // Zasedanie - Gak (many-to-one)
            modelBuilder.Entity<Zasedanie>()
                .HasOne(z => z.Gak)
                .WithMany(g => g.Zasedanies)
                .HasForeignKey(z => z.GakID)
                .OnDelete(DeleteBehavior.Cascade);

            // Zasedanie - Person (many-to-many)
            modelBuilder.Entity<Zasedanie>()
                .HasMany(z => z.Persons)
                .WithMany(p => p.Zasedanies);

            // Person - Kafedra (many-to-one)
            modelBuilder.Entity<Person>()
                .HasOne(p => p.Kafedra)
                .WithMany(k => k.Persons)
                .HasForeignKey(p => p.KafedraID)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}