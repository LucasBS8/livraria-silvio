using Microsoft.EntityFrameworkCore;

namespace livrariaDB.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
            livro = Set<Livro>();
            emprestimo = Set<Emprestimo>();
        }
        public DbSet<Livro> livro { get; set; }
        public DbSet<Emprestimo> emprestimo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Livro>().HasKey(l => l.livroId);
            modelBuilder.Entity<Emprestimo>().HasKey(e => e.emprestimoId);

            modelBuilder.Entity<Emprestimo>().HasOne(e => e.livroEmprestimo).WithMany().HasForeignKey(e => e.livroId);

        }
    }
}
