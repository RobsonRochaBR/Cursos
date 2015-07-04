using System;
using System.Data.Entity;

namespace Agenda.Dados
{
    public class AgendaDbInitializer : DropCreateDatabaseAlways<AgendaContext>
    {
        protected override void Seed(AgendaContext context)
        {
            //Criação do Professor
            var professor = new Professor
            {
                Id = 1,
                Nome = "Robson Rocha",
                EMail = "contato@robsonrocha.com.br"
            };
            context.Professores.Add(professor);

            //Criação dos Cursos
            var cursoMvc = new Curso
            {
                Nome = "ASP.NET MVC",
                Descricao = "Lorem ipsum dolor sit amet consectetuer adipiscin elit",
                CargaHorariaHoras = 30,
            };

            var cursoAgil = new Curso
            {
                Nome = "Codificação Ágil",
                Descricao = "Lorem ipsum dolor sit amet consectetuer adipiscin elit",
                CargaHorariaHoras = 30,
            };
            context.Cursos.AddRange(new[] { cursoMvc, cursoAgil });

            //Criação das Turmas
            var turmaMvc = new Turma
            {
                Nome = "Turma 1",
                Curso = cursoMvc,
                Professor = professor,
                DataInicio = DateTime.Today,
                Local = "Online"
            };

            var turmaAgil = new Turma
            {
                Nome = "Turma 1",
                Curso = cursoAgil,
                Professor = professor,
                DataInicio = DateTime.Today.AddDays(30),
                Local = "Online"
            };
            context.Turmas.AddRange(new[] { turmaMvc, turmaAgil });

            context.SaveChanges();
            base.Seed(context);
        }
    }

    public class AgendaContext : DbContext
    {
        public AgendaContext()
            : base("Agenda")
        {
            Database.SetInitializer(new AgendaDbInitializer());
        }

        public DbSet<Professor> Professores { get; set; }

        public DbSet<Turma> Turmas { get; set; }

        public DbSet<Curso> Cursos { get; set; }

        public DbSet<Aluno> Alunos { get; set; }
    }
}
