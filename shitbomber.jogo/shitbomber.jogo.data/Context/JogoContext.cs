using Microsoft.EntityFrameworkCore;
using shitbomber.jogo.data.Entidades;
using shitbomber.jogo.data.EntityConfig;
using System;
using System.Collections.Generic;
using System.Text;

namespace shitbomber.jogo.data.Context
{
    public class JogoContext : DbContext
    {
        public JogoContext(DbContextOptions<JogoContext> options) : base(options)
        {
        }

        public DbSet<Teste> Teste { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TesteConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
