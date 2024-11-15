using Annunci.Repository.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annunci.Repository
{
    public class AnnunciDbContext: DbContext
    {
        public DbSet<TransactionalOutbox> TransactionalOutboxList { get; set; }
        public DbSet<Carta> Carte { get; set; }
        public DbSet<Inserzione> Inserzioni { get; set; }
        public DbSet<TipoRarita> Rarita { get; set; }
        public DbSet<Utente> Utenti { get; set; }

        public AnnunciDbContext(DbContextOptions<AnnunciDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carta>().HasKey(c => c.Id);
            modelBuilder.Entity<Inserzione>().HasKey(i => i.Id);
            modelBuilder.Entity<TipoRarita>().HasKey(r => r.Rarita);
            modelBuilder.Entity<Utente>().HasKey(u => u.Id);

            modelBuilder.Entity<Inserzione>().Property(i => i.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<TransactionalOutbox>().HasKey(e => new { e.Id });
            modelBuilder.Entity<TransactionalOutbox>().Property(e => e.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Inserzione>().HasOne(i => i.Venditorefk).WithMany(v =>v.Inserzioni ).HasForeignKey(i => i.Venditore).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Inserzione>().HasOne(c => c.Cartafk).WithMany(c => c.Inserzioni).HasForeignKey(c => c.Carta).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Inserzione>().HasOne(r => r.Raritafk).WithMany(r => r.Inserzioni).HasForeignKey(c => c.Rarita).OnDelete(DeleteBehavior.Cascade);
 
        }


    }
}

