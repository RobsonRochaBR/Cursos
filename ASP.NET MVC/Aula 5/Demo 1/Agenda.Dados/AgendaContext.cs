using System;
using System.Data.Entity;
using System.Diagnostics;

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
                Local = "http://www.robsonrocha.com.br"
            };

            var turmaAgil = new Turma
            {
                Nome = "Turma 1",
                Curso = cursoAgil,
                Professor = professor,
                DataInicio = DateTime.Today.AddDays(30),
                Local = "http://www.robsonrocha.com.br"
            };
            context.Turmas.AddRange(new[] {turmaMvc, turmaAgil});

            //Criação dos alunos
            var aluno1 = new Aluno
            {
                Nome = "Lorem Ipsum",
                EMail = "lorem@ipsum.com",
                DataNascimento = new DateTime(1982, 1, 18),
                EnderecoPrincipal = new Endereco
                {
                    Logradouro = "Rua dos Bobos",
                    Numero = "190",
                    Complemento = "Fundos",
                    Bairro = "Fim do Mundo",
                    Cidade = "São Nunca",
                    UF = "SP",
                    CEP = "13326-050"
                }
            };
            context.Alunos.Add(aluno1);

            try
            {
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
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
