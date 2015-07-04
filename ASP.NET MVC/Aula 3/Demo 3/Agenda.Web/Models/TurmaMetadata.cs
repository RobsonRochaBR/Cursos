using System;
using System.ComponentModel.DataAnnotations;

namespace Agenda.Web.Models
{
    public class TurmaMetadata
    {
        [Display(Name = "Nome da Turma")]
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de Início")]
        public DateTime DataInicio { get; set; }

        [Url]
        [Display(Name = "Endereço de acesso")]
        public string Local { get; set; }

        [Display(Name = "Professor")]
        public int ProfessorId { get; set; }

        [Display(Name = "Curso")]
        public int CursoId { get; set; }
    }
}