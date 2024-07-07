using Emprestimos.Models;
using Microsoft.EntityFrameworkCore;

namespace Emprestimos.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
        }
        //dentro do dbset mostrar a estrutura da tabela
        public DbSet<EmprestimosModel> Emprestimos { get; set; }
    }
}
