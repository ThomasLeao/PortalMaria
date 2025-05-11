using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PortalMaria.Models;

public partial class Aluno
{
    public int Id { get; set; }
    [Required]
    public string Nome { get; set; } = null!;

    public int Idade { get; set; }
    [Required]
    public string Responsavel { get; set; } = null!;

    public string? Telefone { get; set; } = null!;

    public string? Observacao { get; set; }

    public virtual ICollection<HorarioAluno> HorarioAlunos { get; set; } = new List<HorarioAluno>();
}
