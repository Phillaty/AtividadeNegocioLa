using Microsoft.EntityFrameworkCore;

namespace Atividade.Models
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> opcoes) : base(opcoes)
        {

        }

        public DbSet<DtoCadastro> Cadastro { get; set; }
    }
}
