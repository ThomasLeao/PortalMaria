using Microsoft.EntityFrameworkCore;
using PortalMaria.Data;
using PortalMaria.Models;
using PortalMaria.Services.Interfaces;

namespace PortalMaria.Services.Implementations
{
    public class AlunoService : IAlunoService
    {
        private readonly ApplicationDbContext _context;
        public AlunoService(ApplicationDbContext context) 
        { 
            _context = context;
        }

        public async Task<List<Aluno>> GetAllAsync(string search = null)
        {
            var query = _context.Alunos.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(a => a.Nome.Contains(search));
            }
            return await query.ToListAsync();
        }

        public async Task<Aluno> GetByIdAsync(int id)
        {
            return await _context.Alunos.FindAsync(id);
        }

        public async Task CreateAsync(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Aluno aluno)
        {
            _context.Alunos.Update(aluno);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno != null)
            {
                _context.Alunos.Remove(aluno);
                await _context.SaveChangesAsync();
            }
        }
    }
}
