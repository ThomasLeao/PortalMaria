using Microsoft.EntityFrameworkCore;
using PortalMaria.Models;
using PortalMaria.Services.Interfaces;
using System.Linq;

namespace PortalMaria.Services.Implementations
{
    public class HorarioAlunoService : IHorarioAlunoService
    {
        private readonly ApplicationDbContext _context;
        public HorarioAlunoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<HorarioAluno>> ListarHorarioAlunos(string search = null)
        {
            var query = _context.HorarioAlunos.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(a => a.NomeAluno.Contains(search));
            }
            return await query.ToListAsync();
        }
        public async Task UpdateAsync(HorarioAluno alunoHoario)
        {
            _context.HorarioAlunos.Update(alunoHoario);
            await _context.SaveChangesAsync();
        }
        public async Task<HorarioAluno> GetByIdAsync(int id)
        {
            return await _context.HorarioAlunos.FindAsync(id);
        }

        public async Task CreateAsync(HorarioAluno horarioAluno)
        {
            _context.HorarioAlunos.Add(horarioAluno);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var idAluno = _context.HorarioAlunos.Where(a => a.IdAluno == id)
                                                .Select(a => a.Id)
                                                .FirstOrDefault();

            var aluno = await _context.HorarioAlunos.FindAsync(idAluno);
            if (aluno != null)
            {
                _context.HorarioAlunos.Remove(aluno);
                await _context.SaveChangesAsync();
            }
        }
    }
}
