using Recensioni.Repository.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recensioni.Repository
{
    public class RecensioniDbContext:DbContext
    {
        public DbSet<Annuncio> Annunci { get; set; }
        public DbSet<Pagamento> Pagamenti { get; set; }
        public DbSet<Recensione> Recensione { get; set; }
        public DbSet<Utente> Utente { get; set; }

        public RecensioniDbContext(DbContextOptions<RecensioniDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Annuncio>().HasKey(a => a.Id);
            modelBuilder.Entity<Pagamento>().HasKey(p => p.Id);
            modelBuilder.Entity<Recensione>().HasKey(r => r.Id);
            modelBuilder.Entity<Utente>().HasKey(u => u.Id);


            
            modelBuilder.Entity<Recensione>().Property(r => r.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Annuncio>().HasOne(a => a.Venditorefk).WithMany(u =>u.Annunci).HasForeignKey(a => a.Venditore).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Pagamento>().HasOne(p => p.Annunciofk).WithMany(a => a.Pagamenti).HasForeignKey(p => p.Annuncio).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Pagamento>().HasOne(p => p.Compratorefk).WithMany(u => u.Pagamenti).HasForeignKey(p => p.Compratore).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Recensione>().HasOne(r => r.Pagamentofk).WithOne(p => p.Recensione).HasForeignKey<Recensione>(r => r.Pagamento).OnDelete(DeleteBehavior.Cascade);

        }


    }
}

