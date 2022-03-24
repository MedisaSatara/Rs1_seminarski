using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Seminarski_Turisticka_Agencija_Rs1.Data;
using Seminarski_Turisticka_Agencija_Rs1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seminarski_Turisticka_Agencija_Rs1
{

    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {

        public DbSet<Administrator> Administrator { get; set; }
        public DbSet<Destinacija> Destinacija { get; set; }
        public DbSet<KorisnickaPodrska> KorisnickaPodrska { get; set; }
        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<Organizator> Organizator { get; set; }
        public DbSet<Ponuda> Ponuda { get; set; }
        public DbSet<Poruka> Poruka { get; set; }
        public DbSet<Prodavac> Prodavac { get; set; }
        public DbSet<Rezervacija> Rezervacija { get; set; }
        public DbSet<TuristickiVodic> TuristickiVodic { get; set; }
        public DbSet<RentAcar> RentAcar { get; set; }
        public DbSet<Jezik> Jezik { get; set; }
        public DbSet<Login> Login { get; set; }
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VodicJezik>()
            .HasKey(x => new { x.TuristickiVodicId, x.JezikId });

            modelBuilder.Entity<VodicJezik>()
                .HasOne(x => x.TuristickiVodic)
                .WithMany(y => y.VodicJezik)
                .HasForeignKey(y => y.JezikId);

            modelBuilder.Entity<VodicJezik>()
                .HasOne(x => x.Jezik)
                .WithMany(y => y.JezikVodic)
                .HasForeignKey(y => y.TuristickiVodicId);
        }
        public DbSet<VodicJezik> VodicJezik { get; set; }

    }

}
