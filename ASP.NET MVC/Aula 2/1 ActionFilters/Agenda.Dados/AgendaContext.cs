using System.Data.Entity;

namespace Agenda.Dados
{
    public class AgendaContext : DbContext
    {
        public AgendaContext()
            : base("Agenda")
        {
        }

        public DbSet<Professor> Professores { get; set; }

        public DbSet<Turma> Turmas { get; set; }

        public DbSet<Curso> Cursos { get; set; }
    }
}
