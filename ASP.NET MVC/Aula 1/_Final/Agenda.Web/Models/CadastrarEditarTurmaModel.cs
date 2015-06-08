using System.Collections.Generic;
using Agenda.Dados;

namespace Agenda.Web.Models
{
    public class CadastrarEditarTurmaModel
    {
        public TurmaModel Turma { get; set; }
        public IEnumerable<Curso> Cursos { get; set; }
        public IEnumerable<Professor> Professores { get; set; }
    }
}