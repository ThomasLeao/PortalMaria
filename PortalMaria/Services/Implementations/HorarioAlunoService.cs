using Microsoft.EntityFrameworkCore;
using PortalMaria.Data;
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
            var query = _context.HorarioAluno;
            return await query.ToListAsync();
        }
        public async Task UpdateAsync(HorarioAluno alunoHoario)
        {
            _context.HorarioAluno.Update(alunoHoario);
            await _context.SaveChangesAsync();
        }
        public async Task<HorarioAluno> GetByIdAsync(int id)
        {
            return await _context.HorarioAluno.FindAsync(id);
        }

    }
}
