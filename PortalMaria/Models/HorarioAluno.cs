using System.ComponentModel.DataAnnotations;

namespace PortalMaria.Models
{
    public class HorarioAluno
    {
        public int Id { get; set; }
        public string? NomeAluno { get; set; }
        public string? Responsavel { get; set; }
        public string? ContatoResponsavel { get; set; }
        public TimeSpan? HorarioInicio { get; set; }
        public TimeSpan? HorarioFim { get; set; }
        public string? DiaSemana { get; set; }
        public string? Materias { get; set; }
        public string? NivelEscolar { get; set; }
        public string? Observacoes { get; set; }
        public string? Status { get; set; }
        public bool? Presenca { get; set; }
        public DateTime? CriadoEm { get; set; }
    }
}
