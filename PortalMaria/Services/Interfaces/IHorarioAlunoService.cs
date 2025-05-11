using PortalMaria.Models;

namespace PortalMaria.Services.Interfaces
{
    public interface IHorarioAlunoService
    {
        Task<List<HorarioAluno>> ListarHorarioAlunos(string search = null);
        Task UpdateAsync(HorarioAluno alunoHoario);
        Task<HorarioAluno> GetByIdAsync(int id);
    }
}
