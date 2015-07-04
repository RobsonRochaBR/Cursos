using System;
using System.ComponentModel.DataAnnotations;
using Agenda.Dados;

namespace Agenda.Web.Models
{
    public class TurmaModel
    {
        public TurmaModel() { }

        public TurmaModel(Turma turma)
        {
            Id = turma.Id;
            Nome = turma.Nome;
            DataInicio = turma.DataInicio;
            Local = turma.Local;
            ProfessorId = turma.Professor.Id;
            CursoId = turma.Curso.Id;
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nome { get; set; }

        [Required]
        public DateTime DataInicio { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Local { get; set; }

        [Required]
        public int ProfessorId { get; set; }

        [Required]
        public int CursoId { get; set; }

        public Turma ToTurma(AgendaContext contexto)
        {
            return new Turma
            {
                Id = Id,
                Nome = Nome,
                DataInicio = DataInicio,
                Local = Local,
                ProfessorId = ProfessorId,
                Professor = contexto.Professores.Find(ProfessorId),
                CursoId = CursoId,
                Curso = contexto.Cursos.Find(CursoId)
            };
        }
    }
}