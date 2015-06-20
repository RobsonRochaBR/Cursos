using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agenda.Dados
{
    public partial class Turma
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nome { get; set; }

        [Required]
        public DateTime DataInicio { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Local { get; set; }

        public int ProfessorId { get; set; }

        [Required]
        public Professor Professor { get; set; }

        public int CursoId { get; set; }

        [Required]
        public Curso Curso { get; set; }
    }
}
