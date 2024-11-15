using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autenticazione.Repository.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Autenticazione.Repository
{
    public class AutenticazioneDbContext : IdentityDbContext
    {

        public DbSet<TransactionalOutbox> TransactionalOutboxList { get; set; }
        public DbSet<AspNetUsers> Usernames { get; set; }


        public AutenticazioneDbContext(DbContextOptions<AutenticazioneDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);;

            modelBuilder.Entity<TransactionalOutbox>().HasKey(e => new { e.Id });
            modelBuilder.Entity<TransactionalOutbox>().Property(e => e.Id).ValueGeneratedOnAdd();

        }

    }
}
