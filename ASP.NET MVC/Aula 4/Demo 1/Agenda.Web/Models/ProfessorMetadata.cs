using System.ComponentModel.DataAnnotations;

namespace Agenda.Web.Models
{
    public class ProfessorMetadata
    {
        [StringLength(50, MinimumLength = 5)]
        [Display(Name = "Nome do Professor")]
        public string Nome { get; set; }

        [EmailAddress]
        [Display(Name = "Endereço de EMail")]
        public string EMail { get; set; }
    }
}