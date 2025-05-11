using PortalMaria.Models;

namespace PortalMaria.Services.Interfaces
{
    public interface IAlunoService
    {
        Task<List<Aluno>> GetAllAsync(string search = null);
        Task<Aluno> GetByIdAsync(int id);
        Task CreateAsync(Aluno aluno);
        Task UpdateAsync(Aluno aluno);
        Task DeleteAsync(int id);
    }
}
