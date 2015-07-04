using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RobsonROX.Util.Extensions;

namespace Agenda.Dados
{
    public partial class Aluno //TODO: : IValidatableObject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Nome do Aluno")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Endereço de EMail")]
        public string EMail { get; set; }

        [Required]
        [DataType(DataType.Date)]
        //TODO: [CustomValidation(typeof(Aluno), "ValidarMaioridade")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Endereço Principal")]
        public Endereco EnderecoPrincipal { get; set; }

        [Display(Name = "Endereços Adicionais")]
        public IList<Endereco> EnderecosAdicionais { get; set; }

        public static ValidationResult ValidarMaioridade(DateTime dataNascimento)
        {
            return dataNascimento == DateTime.MinValue || dataNascimento.GetAge() < 18
                ? new ValidationResult("O aluno deve ter pelo menos 18 anos", new[] {"DataNascimento"})
                : ValidationResult.Success;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return new[] {ValidarMaioridade(DataNascimento)};
        }
    }
}
