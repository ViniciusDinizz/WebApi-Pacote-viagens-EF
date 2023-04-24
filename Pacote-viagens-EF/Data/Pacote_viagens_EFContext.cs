using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pacote_viagens_EF.Models;

namespace Pacote_viagens_EF.Data
{
    public class Pacote_viagens_EFContext : DbContext
    {
        public Pacote_viagens_EFContext (DbContextOptions<Pacote_viagens_EFContext> options)
            : base(options)
        {
        }

        public DbSet<Pacote_viagens_EF.Models.City> City { get; set; } = default!;

        public DbSet<Pacote_viagens_EF.Models.Address>? Address { get; set; }

        public DbSet<Pacote_viagens_EF.Models.Client>? Client { get; set; }

        public DbSet<Pacote_viagens_EF.Models.Hotel>? Hotel { get; set; }

        public DbSet<Pacote_viagens_EF.Models.Ticket>? Ticket { get; set; }

        public DbSet<Pacote_viagens_EF.Models.Package>? Package { get; set; }

    }
}
