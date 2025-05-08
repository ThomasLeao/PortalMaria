using System.ComponentModel.DataAnnotations;

namespace PortalMaria.Models
{
    public class Aluno
    {
        public int Id { get; set; }

        [Required]
        public string? Nome { get; set; }

        [Required]
        public int Idade { get; set; }

        [Required]
        public string ?Responsavel { get; set; }

        [Required]
        public string ?Telefone { get; set; }

        public string? Observacao { get; set; }
    }
}
