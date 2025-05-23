using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asugaksharp.Model
{
    internal class AppDbContext : DbContext
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

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PeriodZasedania>()
                .HasMany(g => g.Gaks)
                .WithOne(pz => pz.PeriodZasedania)
                .HasForeignKey(pz => pz.PeriodZasedaniaId);
        }

    }
}
