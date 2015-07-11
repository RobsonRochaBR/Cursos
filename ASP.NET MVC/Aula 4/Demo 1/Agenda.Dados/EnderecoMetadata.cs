using System.ComponentModel.DataAnnotations;

namespace Agenda.Dados
{
    public class EnderecoMetadata
    {
        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }

        [Display(Name = "Número")]
        public string Numero { get; set; }

        [Display(Name = "Complemento")]
        public string Complemento { get; set; }

        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [StringLength(2, MinimumLength = 2)]
        [Display(Name = "Estado")]
        public string UF { get; set; }

        [StringLength(9, MinimumLength = 9)]
        [RegularExpression(@"\d{5}-\d{3}")]
        [Display(Name = "CEP")]
        public string CEP { get; set; }
    }
}