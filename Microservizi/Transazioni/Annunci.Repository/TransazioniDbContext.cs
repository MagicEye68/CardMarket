using Transazioni.Repository.Model;
using Microsoft.EntityFrameworkCore;


namespace Transazioni.Repository
{
    public class TransazioniDbContext:DbContext
    {
        public DbSet<TransactionalOutbox> TransactionalOutboxList { get; set; }
        public DbSet<Annuncio> Annunci { get; set; }
        public DbSet<Pagamento> Pagamenti { get; set; }
        public DbSet<Utente> Utente { get; set; }

        public TransazioniDbContext(DbContextOptions<TransazioniDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Annuncio>().HasKey(a => a.Id);
            modelBuilder.Entity<Pagamento>().HasKey(p => p.Id);
            modelBuilder.Entity<Utente>().HasKey(u => u.Id);

            
            modelBuilder.Entity<Pagamento>().Property(p => p.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Annuncio>().HasOne(a => a.Venditorefk).WithMany(u =>u.Annunci).HasForeignKey(a => a.Venditore).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Pagamento>().HasOne(p => p.Annunciofk).WithMany(a => a.Pagamenti).HasForeignKey(p => p.Annuncio).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Pagamento>().HasOne(p => p.Compratorefk).WithMany(u => u.Pagamenti).HasForeignKey(p => p.Compratore).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<TransactionalOutbox>().HasKey(e => new { e.Id });
            modelBuilder.Entity<TransactionalOutbox>().Property(e => e.Id).ValueGeneratedOnAdd();

        }


    }
}

