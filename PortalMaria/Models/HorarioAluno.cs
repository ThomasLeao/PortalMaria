using System;
using System.Collections.Generic;

namespace PortalMaria.Models;

public partial class HorarioAluno
{
    public int Id { get; set; }

    public int? IdAluno { get; set; }


    public string? NomeAluno { get; set; }


    public TimeOnly? HorarioInicio { get; set; }

    public TimeOnly? HorarioFim { get; set; }

    public string? DiaSemana { get; set; }

    public string? Materias { get; set; }

    public string? NivelEscolar { get; set; }

    public string? Observacoes { get; set; }

    public string? Status { get; set; }

    public bool? Presenca { get; set; }

    public DateTime? CriadoEm { get; set; }

    public virtual Aluno? IdAlunoNavigation { get; set; }
}
