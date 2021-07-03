using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TGV.Model;

namespace TGV.DataAcess.Entity.Context
{
    public class TGVContext : DbContext
    {
        public TGVContext() : base()
        {

        }

        public DbSet<Motorista> Motorista {get; set;}
        public DbSet<Caminhao> Caminhao { get; set; }
        public DbSet<Viagem> Viagem { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           
      //     builder.Entity<Motorista>().Property(e => e.Codigo).HasConversion<decimal>();
       //    builder.Entity<Caminhao>().Property(e => e.Peso).HasConversion<double>();
        //   builder.Entity<Viagem>().Property(e => e.KmPercurso).HasConversion<double>();
            base.OnModelCreating(builder);


        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseOracle(@"User Id=tgvasp;Password=tgvasp1234;Data Source=localhost;");
            base.OnConfiguring(builder);
        }

    }
}
