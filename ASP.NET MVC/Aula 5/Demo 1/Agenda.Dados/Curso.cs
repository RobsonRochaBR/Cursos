using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agenda.Dados
{
    public partial class Curso
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [Required]
        public decimal CargaHorariaHoras { get; set; }

        public ICollection<Turma> Turmas { get; set; }

        public ICollection<Professor> Professores { get; set; }
    }
}
