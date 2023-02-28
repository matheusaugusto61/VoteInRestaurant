using Microsoft.EntityFrameworkCore;

namespace VoteInRestaurant.Model.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }

        public DbSet<Restaurante> Restaurantes { get; set; }
        public DbSet<Voto> Votos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Voto>()
                .HasOne(r => r.Restaurante)
                .WithMany()
                .HasForeignKey(r => r.RestauranteID);
            modelBuilder.Entity<Voto>()
                .HasOne(r => r.Pessoa)
                .WithMany()
                .HasForeignKey(r => r.IdPessoa);
        }
    }
}
