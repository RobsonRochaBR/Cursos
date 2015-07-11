using System;
using System.ComponentModel.DataAnnotations;

namespace Agenda.Web.Models
{
    public class CursoMetadata
    {
        [Required]
        [MaxLength(200)]
        [StringLength(200, MinimumLength = 5)]
        [Display(Name = "Nome do Curso")]
        public string Nome { get; set; }

        [Display(Name = "Descrição do Curso")]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Carga Horária (em horas)")]
        [DataType(DataType.Duration)]
        public TimeSpan CargaHorariaHoras { get; set; }
    }
}