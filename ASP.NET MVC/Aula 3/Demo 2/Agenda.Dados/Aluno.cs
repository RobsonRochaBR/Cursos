using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agenda.Dados
{
    public partial class Aluno
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(255)]
        public string EMail { get; set; }

        public Endereco EnderecoPrincipal { get; set; }

        public IList<Endereco> EnderecosAdicionais { get; set; }
    }
}
